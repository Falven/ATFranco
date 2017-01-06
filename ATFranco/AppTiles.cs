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
    using System.Collections.ObjectModel;
    using System.IO;
    using System.IO.IsolatedStorage;

    /// <summary>
    /// A singleton application-level class used to handle tiles for such application.
    /// </summary>
    public class AppTiles : SingletonBase<AppTiles>
    {
        public const int MAX_CYCLE_IMAGES = 9;

        private readonly Uri CYCLE_TILE_SMALL;
        private readonly Uri CYCLE_TILE_MEDIUM;
        private readonly Uri CYCLE_TILE_LARGE;
        private readonly Uri ICONIC_TILE_MEDIUM_LARGE;
        private readonly Uri ICONIC_TILE_SMALL;

        public AppTiles()
        {
            CYCLE_TILE_SMALL = new Uri("/Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
            CYCLE_TILE_MEDIUM = new Uri("/Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative);
            CYCLE_TILE_LARGE = new Uri("/Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative);

            ICONIC_TILE_MEDIUM_LARGE = new Uri("/Assets/Tiles/IconicTileMediumLarge.png", UriKind.Relative);
            ICONIC_TILE_SMALL = new Uri("/Assets/Tiles/IconicTileSmall.png", UriKind.Relative);
        }

        /// <summary>
        /// Create a secondary tile for the provided IAppTile.
        /// </summary>
        /// <param name="tile">The tile to be linked to the start screen.</param>
        public void Pin(IAppTile tile)
        {
            var tileNav = tile.NavigationUri;
            var tileData = tile.TileData;

            var cycleData = tileData as CycleTileData;
            var flipData = tileData as FlipTileData;
            var iconicData = tileData as IconicTileData;
            var standardData = tileData as StandardTileData;

            if (null != cycleData)
            {
                cycleData.SmallBackgroundImage = CYCLE_TILE_SMALL;
                ShellTile.Create(tileNav, cycleData, true);
            }

            if (null != iconicData)
            {
                iconicData.SmallIconImage = ICONIC_TILE_SMALL;
                iconicData.IconImage = ICONIC_TILE_MEDIUM_LARGE;
                ShellTile.Create(tileNav, iconicData);
            }

            if (null != iconicData)
            {
                ShellTile.Create(tileNav, tileData);
            }
        }

        /// <summary>
        /// Returns true if the provided tile exists in the start screen.
        /// Note: for more common, non-specific checks, use the IAppTile's IsPinned property.
        /// </summary>
        /// <param name="tile">The IAppTile to check for in the start screen.</param>
        /// <returns>True if the tile exists on the start screen, false otherwise.</returns>
        public bool TileExists(IAppTile tile)
        {
            foreach (var activeTile in ShellTile.ActiveTiles)
                if (activeTile.NavigationUri == tile.NavigationUri)
                    return true;
            return false;
        }
    }
}