﻿/*
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
    /// <summary>
    /// The base class for Singletons.
    /// </summary>
    /// <typeparam name="T">The type of the singleton.</typeparam>
    public class SingletonBase<T>
        where T : class, new()
    {
        private static T _instance;

        /// <summary>
        /// Retrieves an instance of the Singleton T.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new T();
                return _instance;
            }
        }
    }
}
