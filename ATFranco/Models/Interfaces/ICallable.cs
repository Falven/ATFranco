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

namespace ATFranco.Models
{
    /// <summary>
    /// Represents a model that participates in Microsoft.Phone.Tasks.PhoneCallTasks.
    /// </summary>
    public interface ICallable
    {
        /// <summary>
        /// Gets or sets the name that is displayed when the Phone application is launched.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets or sets the phone number that is dialed when the Phone application is launched.
        /// </summary>
        string PhoneNumber { get; }
    }
}