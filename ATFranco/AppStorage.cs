/*
 * Copyright (c) Dapper Apps.  All rights reserved.
 * Use of this source code is subject to the terms of the Dapper Apps license 
 * agreement under which you licensed this sample source code and is provided AS-IS.
 * If you did not accept the terms of the license agreement, you are not authorized 
 * to use this sample source code.  For the terms of the license, please see the 
 * license agreement between you and Dapper Apps.
 *
 * To see the article about this app, visit http://www.dapper-apps.com/DapperToolkit
 */

namespace ATFranco
{
    using ATFranco.Models;
    using Microsoft.Phone.Shell;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Text;
    using System.Windows;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO
    /// </summary>
    public class AppStorage : SingletonBase<AppStorage>
    {
        // Search patterns to list all files and directories
        private const string SUB_FILES = "*.*";
        private const string SUB_DIRS = "*";
        private const string SUB_IMAGES = "*.jpg";

        // Default directories that come in WP8.
        private readonly string SHARED;
        private readonly string MEDIA;
        private readonly string SHELLCONTENT;
        private readonly string TRANSFERS;

        // Default Subdirectories e.g. \\Shared\\Media
        internal readonly string SHARED_MEDIA;
        internal readonly string SHARED_SHELLCONTENT;
        internal readonly string SHARED_TRANSFERS;

        public AppStorage()
        {
            SHARED = "Shared";
            MEDIA = "Media";
            SHELLCONTENT = "ShellContent";
            TRANSFERS = "Transfers";

            SHARED_MEDIA = Path.Combine(SHARED, MEDIA);
            SHARED_SHELLCONTENT = Path.Combine(SHARED, SHELLCONTENT);
            SHARED_TRANSFERS = Path.Combine(SHARED, TRANSFERS);
        }

        /// <summary>
        /// Prints the contents of the IsolatedStorage space recursively with nice formatting.
        /// </summary>
        /// <param name="store">TODO</param>
        /// <param name="root">TODO</param>
        /// <param name="level">TODO</param>
        private void ListTileStore(IsolatedStorageFile store, string root, int level)
        {
            var space = "\n";
            for (int i = 0; i < level; i++)
                space += '\t';
            Debug.WriteLine(space + "\'" + root + "\'" + " Directories:");
            var directories = store.GetDirectoryNames(Path.Combine(root, SUB_DIRS));
            foreach (var directory in directories)
            {
                space = "";
                for (int i = 0; i < level; i++)
                    space += '\t';
                Debug.WriteLine(space + directory);
            }
            Debug.WriteLine(space + "\'" + root + "\'" + " Files:");
            var files = store.GetFileNames(Path.Combine(root, SUB_FILES));
            foreach (var file in files)
            {
                space = "";
                for (int i = 0; i < level; i++)
                    space += '\t';
                Debug.WriteLine(space + file);
            }

            foreach (var directory in directories)
            {
                ListTileStore(store, Path.Combine(root, directory), level + 1);
            }
        }

        /// <summary>
        /// Clears all image files from the Tile store.
        /// </summary>
        public void ClearTileStore()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.DirectoryExists(SHARED_SHELLCONTENT))
                {
                    ClearTileStore(store, SHARED_SHELLCONTENT);
                }
            }
        }

        private void ClearTileStore(IsolatedStorageFile store, string root)
        {
            Debug.WriteLine("Directory: " + root);
            var subDirectories = store.GetDirectoryNames(Path.Combine(root, SUB_DIRS));
            foreach (var directory in subDirectories)
            {
                Debug.WriteLine("\tSubdirectory: " + directory);
            }

            var subFiles = store.GetFileNames(Path.Combine(root, SUB_IMAGES));
            foreach (var image in subFiles)
            {
                store.DeleteFile(Path.Combine(root, image));
                Debug.WriteLine("\tImage: " + image + "\tDELETED.");
            }

            foreach (var directory in subDirectories)
            {
                ClearTileStore(store, Path.Combine(root, directory));
            }
        }

        public void SaveTileImage(WriteableBitmap image)
        {
            VerifyParameters(image);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var path = VerifyPathIntegrity(store, SHARED_SHELLCONTENT);
                SaveTileImage(store, path, image);
            }
        }

        public void SaveTileImage(IAppTile tile, WriteableBitmap image)
        {
            VerifyParameters(tile, image);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var rootTiles = Path.Combine(SHARED_SHELLCONTENT, tile.IsoDir);
                var path = VerifyPathIntegrity(store, Path.Combine(rootTiles, tile.Id.ToString()));
                SaveTileImage(store, path, image);
            }
        }

        public BitmapImage LoadTileImage(IAppTile tile, string name)
        {
            VerifyParameters(tile, name);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var rootTiles = Path.Combine(SHARED_SHELLCONTENT, tile.IsoDir);
                var path = VerifyPathIntegrity(store, Path.Combine(rootTiles, tile.Id.ToString()));
                return LoadTileImage(store, path, name);
            }
        }

        public BitmapImage LoadTileImage(string name)
        {
            VerifyParameters(name);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return LoadTileImage(store, Path.Combine(SHARED_SHELLCONTENT), name);
            }
        }

        public IList<BitmapImage> LoadTileImages(IAppTile tile)
        {
            VerifyParameters(tile);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var rootTiles = Path.Combine(SHARED_SHELLCONTENT, tile.IsoDir);
                var path = VerifyPathIntegrity(store, Path.Combine(rootTiles, tile.Id.ToString()));

                string[] bitmapNames = store.GetFileNames(Path.Combine(path, SUB_FILES));
                int length = bitmapNames.Length;

                var bitmaps = new List<BitmapImage>(length);
                for (int i = 0; i < length; i++)
                    bitmaps[i] = LoadTileImage(store, path, bitmapNames[i]);
                return bitmaps;
            }
        }

        private BitmapImage LoadTileImage(IsolatedStorageFile store, string path, string name)
        {
            string filePath = Path.Combine(path, name);

            BitmapImage bitmap = new BitmapImage();
            bitmap.SetValue(FrameworkElement.NameProperty, name);
            if (store.FileExists(filePath))
            {
                using (IsolatedStorageFileStream fileStream = store.OpenFile(filePath, FileMode.Open, FileAccess.Read))
                {
                    bitmap.SetSource(fileStream);
                    Debug.WriteLine("Loaded TileImage: " + filePath);
                    return bitmap;
                }
            }
            return null;
        }

        public IList<Uri> GetTileImagePaths(IAppTile tile)
        {
            VerifyParameters(tile);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var cycleImages = new List<Uri>();
                var randNumGen = new Random(DateTime.Now.Second);

                var rootTiles = Path.Combine(SHARED_SHELLCONTENT, tile.IsoDir);
                var path = VerifyPathIntegrity(store, Path.Combine(rootTiles, tile.Id.ToString()));

                var images = store.GetFileNames(Path.Combine(path, SUB_FILES));

                int count = Math.Min(images.Length, AppTiles.MAX_CYCLE_IMAGES);
                for (int i = 0; i < count; i++)
                {
                    int rnum = randNumGen.Next(count);
                    var imagePath = Path.Combine(path, images[rnum]);
                    var uriImagePath = new Uri(new Uri(@"isostore:/"), imagePath);
                    cycleImages.Add(uriImagePath);
                }
                return cycleImages;
            }
        }

        private void VerifyParameters(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
        }

        private void VerifyParameters(WriteableBitmap image)
        {
            if (null == image)
                throw new ArgumentNullException("image");
            if (string.IsNullOrWhiteSpace((string)image.GetValue(FrameworkElement.NameProperty)))
                throw new ArgumentNullException("FrameworkElement.NameProperty");
        }

        private void VerifyParameters(IAppTile tile)
        {
            if (null == tile)
                throw new ArgumentNullException("tile");

            var isoDir = tile.IsoDir;
            if (string.IsNullOrWhiteSpace(isoDir))
                throw new ArgumentNullException("The provided tile must have a valid IsoDir.");

            var id = tile.Id;
            if (id < 0)
                throw new ArgumentException("The provided tile must have a valid Id.");
        }

        private void VerifyParameters(IAppTile tile, WriteableBitmap image)
        {
            VerifyParameters(tile);
            VerifyParameters(image);
        }

        private void VerifyParameters(IAppTile tile, string name)
        {
            VerifyParameters(tile);
            VerifyParameters(name);
        }

        private string VerifyPathIntegrity(IsolatedStorageFile store, string path)
        {
            VerifyParameters(path);
            Debug.WriteLine("Verifying Path: " + path);
            if (!store.DirectoryExists(path))
                store.CreateDirectory(path);
            return path;
        }

        private void SaveTileImage(IsolatedStorageFile store, string path, WriteableBitmap image)
        {
            string filePath = Path.Combine(path, (string)image.GetValue(FrameworkElement.NameProperty));
            using (var fileStream = store.OpenFile(filePath, FileMode.Create, FileAccess.Write))
            {
                image.SaveJpeg(fileStream, image.PixelWidth, image.PixelHeight, 0, 100);
            }
            Debug.WriteLine("Saved TileImage: " + filePath);
        }
    }
}