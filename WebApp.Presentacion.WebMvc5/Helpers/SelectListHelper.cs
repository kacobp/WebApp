// -----------------------------------------------------------------------
// <copyright file="SelectListHelper.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Presentacion.WebMvc5
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Mvc;
    using WebGrease.Css.Extensions;

    #endregion

    /// <summary>
    /// Extension methods for HTML SelectList
    /// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Enumeration of item selection options
        /// </summary>
        public enum SelectionMode
        {
            /// <summary>
            /// No item will be selected
            /// </summary>
            None = 0,

            /// <summary>
            /// The item will be selected if it is the only item in the list
            /// </summary>
            SelectIfSingle = 1,

            /// <summary>
            /// Select the first item found in the list
            /// </summary>
            SelectFirst = 2
        }

        /// <summary>
        /// Inserts the placeholder.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="placeholderText">The placeholderText.</param>
        /// <param name="placeholderValue">The placeholderValue.</param>
        public static void InsertPlaceholder(this IList<SelectListItem> list, object placeholderText, object placeholderValue)
        {
            var item = new SelectListItem {Text = Convert.ToString(placeholderText), Value = Convert.ToString(placeholderValue)};
            if (list == null) list = new Collection<SelectListItem>();
            list.Insert(0, item);
        }

        /// <summary>
        /// Inserts the placeholder.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void InsertPlaceholder(this IList<SelectListItem> list)
        {
            InsertPlaceholder(list, string.Empty);
        }

        /// <summary>
        /// Inserts the placeholder.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="placeholderText">The placeholderText.</param>
        public static void InsertPlaceholder(this IList<SelectListItem> list, object placeholderText)
        {
            InsertPlaceholder(list, placeholderText, string.Empty);
        }

        /// <summary>
        /// Sets the Selected property for the specified item.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="findValue">The find placeholderValue.</param>
        /// <param name="defaultSelectionMode">The default item selection mode should the specified placeholderValue not exist in the list.</param>
        public static void SelectListItem(this ICollection<SelectListItem> list, object findValue, SelectionMode defaultSelectionMode = SelectionMode.SelectFirst)
        {
            // Got List?
            if (list == null || !list.Any()) return;

            // Deselect all
            list.Where(li => li.Selected)
                .ForEach(li => li.Selected = false);

            // Try find item
            var findString = Convert.ToString(findValue);
            var item = list.FirstOrDefault(li => string.Equals(li.Value, findString));
            if (item != null)
            {
                item.Selected = true;
                return;
            }

            // Apply default item selection mode
            if (defaultSelectionMode == SelectionMode.SelectFirst || (defaultSelectionMode == SelectionMode.SelectIfSingle && list.Count == 1))
            {
                list.First().Selected = true;
            }
                // 2 items, first one is placeholder?
            else if (defaultSelectionMode == SelectionMode.SelectIfSingle && list.Count == 2 && string.IsNullOrEmpty(list.First().Text))
            {
                // Select second (Only) item
                list.ElementAt(1).Selected = true;
            }

        }

        /// <summary>
        /// Returns an empty the select list.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Empty(bool listWithPlaceholder = false)
        {
            var empty = new List<SelectListItem>();
            if (listWithPlaceholder)
            {
                empty.InsertPlaceholder();
            }

            return empty;
        }

    }
}