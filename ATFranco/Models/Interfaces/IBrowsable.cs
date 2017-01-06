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
    using System;

    /// <summary>
    /// Represents a model that participates in Microsoft.Phone.Tasks.WebBrowserTasks.
    /// </summary>
    public interface IBrowsable
    {
        /// <summary>
        /// Gets the URI to which the web browser application will navigate when it is launched.
        /// </summary>
        Uri Uri { get; }
    }
}
