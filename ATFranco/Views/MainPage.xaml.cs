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

namespace ATFranco.Views
{
    using ATFranco.Models;
    using ATFranco.ViewModels;
    using DapperApps.Phone.Controls;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Tasks;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public partial class MainPage : ViewBase
    {
        private OurStudiosViewModel _ourStudiosViewModel;
        private OurTeamViewModel _ourTeamViewModel;
        private ProjectsViewModel _projectsViewModel;
        private PressAwardsViewModel _pressAwardsViewModel;
        private ContactViewModel _contactUsViewModel;
        private ContactInfo _aboutViewModel;

        /// <summary>
        /// TODO
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Studios.Loaded += Studios_Loaded;
        }

        private void Studios_Loaded(object sender, RoutedEventArgs e)
        {
            if (Pivot.SelectedIndex != 0)
            {
                ImagePreview.FreezePreviews(Studios);
            }
            else
            {
                ImagePreview.UnfreezePreviews(Studios);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                ImagePreview.FreezePreviews((FrameworkElement)Studios);
            }
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Function called when an ImagePage becomes the active page in a frame.
        /// </summary>
        /// <param name="e">The event arguments for this navigation event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                string index;
                if (NavigationContext.QueryString.TryGetValue("index", out index))
                {
                    Pivot.SelectedIndex = Convert.ToInt32(index);
                }
            }
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    if (null == _ourStudiosViewModel)
                        OurStudioPivotItem.DataContext = _ourStudiosViewModel = App.OurStudiosViewModel;
                    if (null == _ourTeamViewModel)
                        OurTeamPivotItem.DataContext = _ourTeamViewModel = App.OurTeamViewModel;
                    if (null == _aboutViewModel)
                        AboutPivotItem.DataContext = _aboutViewModel = App.AboutViewModel.DapperContactInfo;
                    break;
                case 1:
                    if (null == _ourTeamViewModel)
                        OurTeamPivotItem.DataContext = _ourTeamViewModel = App.OurTeamViewModel;
                    if (null == _projectsViewModel)
                        ProjectsPivotItem.DataContext = _projectsViewModel = App.ProjectsViewModel;
                    if (null == _ourStudiosViewModel)
                        OurStudioPivotItem.DataContext = _ourStudiosViewModel = App.OurStudiosViewModel;
                    break;
                case 2:
                    if (null == _projectsViewModel)
                        ProjectsPivotItem.DataContext = _projectsViewModel = App.ProjectsViewModel;
                    if (null == _pressAwardsViewModel)
                        PressAwardsPivotItem.DataContext = _pressAwardsViewModel = App.PressAwardsViewModel;
                    if (null == _ourTeamViewModel)
                        OurTeamPivotItem.DataContext = _ourTeamViewModel = App.OurTeamViewModel;
                    break;
                case 3:
                    if (null == _pressAwardsViewModel)
                        PressAwardsPivotItem.DataContext = _pressAwardsViewModel = App.PressAwardsViewModel;
                    if (null == _contactUsViewModel)
                        ContactPivotItem.DataContext = _contactUsViewModel = App.ContactViewModel;
                    if (null == _projectsViewModel)
                        ProjectsPivotItem.DataContext = _projectsViewModel = App.ProjectsViewModel;
                    break;
                case 4:
                    if (null == _contactUsViewModel)
                        ContactPivotItem.DataContext = _contactUsViewModel = App.ContactViewModel;
                    if (null == _aboutViewModel)
                        AboutPivotItem.DataContext = _aboutViewModel = App.AboutViewModel.DapperContactInfo;
                    if (null == _pressAwardsViewModel)
                        PressAwardsPivotItem.DataContext = _pressAwardsViewModel = App.PressAwardsViewModel;
                    break;
                case 5:
                    if (null == _aboutViewModel)
                        AboutPivotItem.DataContext = _aboutViewModel = App.AboutViewModel.DapperContactInfo;
                    if (null == _ourStudiosViewModel)
                        OurStudioPivotItem.DataContext = _ourStudiosViewModel = App.OurStudiosViewModel;
                    if (null == _contactUsViewModel)
                        ContactPivotItem.DataContext = _contactUsViewModel = App.ContactViewModel;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handler called when a user taps on a Browsable element.
        /// </summary>
        /// <param name="sender">The object that raised this event.</param>
        /// <param name="e">The arguments for this event.</param>
        private void WebSite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            AppTasks.Instance.Browse((IBrowsable)((FrameworkElement)sender).DataContext);
        }

        /// <summary>
        /// Handler called when a user taps on a Emailable element.
        /// </summary>
        /// <param name="sender">The object that raised this event.</param>
        /// <param name="e">The arguments for this event.</param>
        private void EmailLink_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            AppTasks.Instance.Email((IEmailable)((FrameworkElement)sender).DataContext);
        }

        /// <summary>
        /// Handler called when a user taps on a Callable element.
        /// </summary>
        /// <param name="sender">The object that raised this event.</param>
        /// <param name="e">The arguments for this event.</param>
        private void Telephone_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            AppTasks.Instance.Call((ICallable)((FrameworkElement)sender).DataContext);
        }

        /// <summary>
        /// Handler called when a user taps on a Mapable element.
        /// </summary>
        /// <param name="sender">The object that raised this event.</param>
        /// <param name="e">The arguments for this event.</param>
        private void Map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            AppTasks.Instance.Map((IMapable)((FrameworkElement)sender).DataContext);
        }

        protected override void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.ItemsControl_Loaded(sender, e);
        }

        protected override void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            base.Image_Tap(sender, e);
        }
    }
}