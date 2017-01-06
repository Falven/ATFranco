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
    /// Represents a model that participates in Microsoft.Phone.Tasks.EmailComposeTasks.
    /// </summary>
    public interface IEmailable
    {
        /// <summary>
        /// Gets or sets the recipients on the Bcc line of the new email message.
        /// </summary>
        string Bcc { get; }

        /// <summary>
        /// Gets or sets the body of the new email message.
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets or sets the recipients on the Cc line of the new email message.
        /// </summary>
        string Cc { get; }

        /// <summary>
        /// Gets or sets the character set that will be used to display the message content.
        /// </summary>
        int? CodePage { get; }

        /// <summary>
        /// Gets or sets the subject of the new email message.
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// Gets or sets the recipients on the To line of the new email message.
        /// </summary>
        string To { get; }
    }
}