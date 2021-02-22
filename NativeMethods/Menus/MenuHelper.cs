using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Menus
{
    public static class MenuHelper
    {
        #region Members

        // System constants
        public const Int32 HC_ACTION = 0x00000000;
        public const Int32 WM_SYSCOMMAND = 0x00000112;
        public const Int32 WM_MENUSELECT = 0x0000011F;
        public const Int32 WM_COMMAND = 0x00000111;
        public const Int32 MFT_SEPARATOR = 0x00000800;
        public const Int32 MFT_BYPOSITION = 0x00000400;
        public const Int32 MFT_BYCOMMAND = 0x00000000;
        public const Int32 MFT_STRING = 0x00000000;
        public const Int32 MFT_BITMAP = 0x00000004;

        // Menu Item: Type
        public const Int32 MIIM_BITMAP = 0x00000080;
        public const Int32 MIIM_DATA = 0x00000020;
        public const Int32 MIIM_FTYPE = 0x00000100;
        public const Int32 MIIM_ID = 0x00000002;
        public const Int32 MIIM_STATE = 0x00000001;
        public const Int32 MIIM_STRING = 0x00000040;
        public const Int32 MIIM_SUBMENU = 0x00000004;
        public const Int32 MIIM_TYPE = 0x00000010;

        // Menu Item: State
        public const Int32 MFS_CHECKED = 0x00000008;
        public const Int32 MFS_DEFAULT = 0x00001000;
        public const Int32 MFS_DISABLED = 0x00000003;
        public const Int32 MFS_ENABLED = 0x00000000;
        public const Int32 MFS_GRAYED = 0x00000003;
        public const Int32 MFS_HILITE = 0x00000080;
        public const Int32 MFS_UNCHECKED = 0x00000000;
        public const Int32 MFS_UNHILITE = 0x00000000;

        // Menu Item: Position
        public const Int32 MF_BYCOMMAND = 0x00000000;
        public const Int32 MF_BYPOSITION = 0x00000400;
        public const Int32 MF_DISABLED = 0x00000002;
        public const Int32 MF_GRAYED = 0x00000001;
        public const Int32 MF_ENABLED = 0x00000000;

        #endregion

        #region Methods



        #endregion

        #region Externals

        /// <summary>
        /// Gets the system menu.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="revert">if set to <c>true</c> [revert].</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr windowHandle, bool revert);

        /// <summary>
        /// Gets the menu item identifier.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetMenuItemID(IntPtr menuHandle, uint position);

        /// <summary>
        /// Creates the menu.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateMenu();

        /// <summary>
        /// Deletes the menu.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <param name="position">The position.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool DeleteMenu(IntPtr menuHandle, uint position, uint flags);

        /// <summary>
        /// Gets the menu item count.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr menuHandle);

        /// <summary>
        /// Gets the menu item information.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <param name="item">The item.</param>
        /// <param name="byPosition">if set to <c>true</c> [by position].</param>
        /// <param name="menuItemInfo">The menu item information.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetMenuItemInfo(IntPtr menuHandle, uint item, bool byPosition, out MENUITEMINFO menuItemInfo);

        /// <summary>
        /// Inserts a menu item.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <param name="item">The item.</param>
        /// <param name="byPosition">if set to <c>true</c> [by position].</param>
        /// <param name="menuItemInfo">The menu item information.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool InsertMenuItem(IntPtr menuHandle, uint item, bool byPosition, ref MENUITEMINFO menuItemInfo);

        /// <summary>
        /// Enables / disables a menu item.
        /// </summary>
        /// <param name="menuHandle">The menu handle.</param>
        /// <param name="enableItemId">The enable item identifier.</param>
        /// <param name="enable">The enable.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnableMenuItem(IntPtr menuHandle, uint enableItemId, uint enable);

        #endregion
    }
}
