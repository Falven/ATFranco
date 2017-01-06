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
    using Microsoft.Phone.Tasks;
    using System;
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// TODO
    /// </summary>
    public class AppLogger : SingletonBase<AppLogger>
    {
        private const string DEFAULT_CAPTION = @"An error has occurred.";
        private const string DEFAULT_MESSAGE = @"Help us fix this by sending an error report, or cancel.";
        private const string DEFAULT_EMAIL = @"atfranco@outlook.com";
        private const string DEFAULT_SUBJECT = @"ATFranco Windows Phone App";

        public string Message { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public void LogException(Exception e, string message = "")
        {
            Message = message;
            var result = MessageBox.Show(string.Format("{0}\n{1}", message, DEFAULT_MESSAGE), DEFAULT_CAPTION, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var email = new EmailComposeTask
                {
                    To = DEFAULT_EMAIL,
                    Subject = string.Format("{0} {1}", DEFAULT_SUBJECT, e.GetType()),
                    Body = string.Format("{0}\n\nSource:\n{1}\nData:\n{2}\nMessage:\n{3}\nStackTrace:\n{4}", message, e.Source, e.Data, e.Message, e.StackTrace)
                };
                email.Show();
            }
        }
    }
}