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
    using System.Device.Location;

    /// <summary>
    /// Represents a model that participates in Microsoft.Phone.Tasks.MapsTasks.
    /// </summary>
    public interface IMapable
    {
        /// <summary>
        /// Gets or sets the location that will be used as the center point for the map.
        /// </summary>
        GeoCoordinate Center { get; }

        /// <summary>
        /// Gets or sets the search term that is used to find and tag locations on the map.
        /// </summary>
        string SearchTerm { get; }

        /// <summary>
        /// Gets or sets the initial zoom level of the map.
        /// </summary>
        double ZoomLevel { get; }
    }
}
