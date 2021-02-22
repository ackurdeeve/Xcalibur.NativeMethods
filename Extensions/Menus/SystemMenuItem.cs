using System;
using Xcalibur.NativeMethods.Menus;

namespace Xcalibur.NativeMethods.Extensions.Menus
{
    /// <summary>
    /// System menu item.
    /// </summary>
    public class SystemMenuItem
    {
        /// <summary>
        /// Gets or sets the system menu handle.
        /// </summary>
        /// <value>
        /// The system menu handle.
        /// </value>
        public IntPtr SystemMenuHandle { get; set; }

        /// <summary>
        /// Gets or sets the menu item information.
        /// </summary>
        /// <value>
        /// The menu item information.
        /// </value>
        public MENUITEMINFO MenuItemInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemMenuItem"/> class.
        /// </summary>
        /// <param name="systemMenuHandle">The system menu handle.</param>
        /// <param name="menuItemInfo">The menu item information.</param>
        public SystemMenuItem(IntPtr systemMenuHandle, MENUITEMINFO menuItemInfo)
        {
            SystemMenuHandle = systemMenuHandle;
            MenuItemInfo = menuItemInfo;
        }
    }
}
