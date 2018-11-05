/*
 This program is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program; if not, write to the Free Software
 Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

using System;

namespace ThalesSim.Core.Commands.Console
{
    /// <summary>
    /// Attribute used to decorate console commands.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ThalesConsoleCommandAttribute : Attribute
    {
        /// <summary>
        /// Get/set the command code.
        /// </summary>
        public string CommandCode { get; set; }

        /// <summary>
        /// Get/set the command description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="commandCode">Console command code.</param>
        /// <param name="description">Console command description.</param>
        public ThalesConsoleCommandAttribute (string commandCode, string description)
        {
            CommandCode = commandCode;
            Description = description;
        }
    }
}
