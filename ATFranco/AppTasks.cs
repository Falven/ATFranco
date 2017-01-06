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
    using Microsoft.Phone.Tasks;
    using System;

    /// <summary>
    /// A class that performs Microsoft.Phone.Tasks for IBrowsable
    /// </summary>
    public class AppTasks : SingletonBase<AppTasks>
    {
        /// <summary>
        /// Shows a Microsoft.Phone.Tasks.WebBrowserTask of the provided model.
        /// </summary>
        /// <param name="browsable">The ATFrancoModel to browse to.</param>
        public void Browse(IBrowsable browsable)
        {
            var webBrowserTask = new WebBrowserTask();
            var uri = browsable.Uri;
            if (null != uri)
                webBrowserTask.Uri = uri;
            webBrowserTask.Show();
        }

        /// <summary>
        /// Shows a Microsoft.Phone.Tasks.EmailComposeTask of the provided model.
        /// </summary>
        /// <param name="emailable">The ATFrancoModel to email to.</param>
        public void Email(IEmailable emailable)
        {
            var emailComposeTask = new EmailComposeTask();
            var bcc = emailable.Bcc;
            var body = emailable.Body;
            var cc = emailable.Cc;
            var codePage = emailable.CodePage;
            var subject = emailable.Subject;
            var to = emailable.To;
            if (null != bcc)
                emailComposeTask.Bcc = emailable.Bcc;
            if (null != body)
                emailComposeTask.Body = emailable.Body;
            if (null != cc)
                emailComposeTask.Cc = emailable.Cc;
            if (null != codePage)
                emailComposeTask.CodePage = emailable.CodePage;
            if (null != subject)
                emailComposeTask.Subject = emailable.Subject;
            if (null != to)
                emailComposeTask.To = emailable.To;
            emailComposeTask.Show();
        }

        /// <summary>
        /// Shows a Microsoft.Phone.Tasks.PhoneCallTask of the provided model.
        /// </summary>
        /// <param name="callable">The ATFrancoModel to call.</param>
        public void Call(ICallable callable)
        {
            var phoneCallTask = new PhoneCallTask();
            var displayName = callable.DisplayName;
            var phoneNumber = callable.PhoneNumber;
            if (null != phoneNumber)
                phoneCallTask.PhoneNumber = phoneNumber;
            if (null != displayName)
                phoneCallTask.DisplayName = displayName;
            phoneCallTask.Show();
        }

        /// <summary>
        /// Shows a Microsoft.Phone.Tasks.MapsTask of the provided model.
        /// </summary>
        /// <param name="mapable"></param>
        public void Map(IMapable mapable)
        {
            var mapsTask = new MapsTask();
            var center = mapable.Center;
            var searchTerm = mapable.SearchTerm;
            var zoomLevel = mapable.ZoomLevel;
            if (null != center)
                mapsTask.Center = center;
            if (null != searchTerm)
                mapsTask.SearchTerm = searchTerm;
            if (0 != zoomLevel)
                mapsTask.ZoomLevel = zoomLevel;
            mapsTask.Show();
        }
    }
}