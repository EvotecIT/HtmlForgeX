using System;
using System.Collections.Generic;

namespace HtmlForgeX {
    /// <summary>
    /// Extension methods for Element class to provide enhanced table functionality
    /// </summary>
    public static class ElementTableExtensions {
        /// <summary>
        /// Creates a table with the specified data and configures it using the provided action.
        /// </summary>
        /// <param name="element">The element to add the table to.</param>
        /// <param name="objects">The data objects to display in the table.</param>
        /// <param name="tableType">Table library type.</param>
        /// <param name="configure">Action to configure the table.</param>
        /// <returns>The created and configured table element.</returns>
        public static Table Table(this Element element, IEnumerable<object> objects, TableType tableType, Action<Table> configure) {
            var table = element.Table(objects, tableType);
            configure?.Invoke(table);
            return table;
        }

        /// <summary>
        /// Creates a table with the specified data and configures it using the provided action.
        /// </summary>
        /// <param name="element">The element to add the table to.</param>
        /// <param name="objects">The data object to display in the table.</param>
        /// <param name="tableType">Table library type.</param>
        /// <param name="configure">Action to configure the table.</param>
        /// <returns>The created and configured table element.</returns>
        public static Table Table(this Element element, object objects, TableType tableType, Action<Table> configure) {
            var table = element.Table(objects, tableType);
            configure?.Invoke(table);
            return table;
        }

        /// <summary>
        /// Creates a DataTables table with the specified data and configures it using the provided action.
        /// </summary>
        /// <param name="element">The element to add the table to.</param>
        /// <param name="objects">The data objects to display in the table.</param>
        /// <param name="configure">Action to configure the DataTables table.</param>
        /// <returns>The created and configured DataTables table element.</returns>
        public static DataTablesTable DataTable(this Element element, IEnumerable<object> objects, Action<DataTablesTable> configure) {
            var table = (DataTablesTable)element.Table(objects, TableType.DataTables);
            configure?.Invoke(table);
            return table;
        }

        /// <summary>
        /// Creates a DataTables table with the specified data and configures it using the provided action.
        /// </summary>
        /// <param name="element">The element to add the table to.</param>
        /// <param name="objects">The data object to display in the table.</param>
        /// <param name="configure">Action to configure the DataTables table.</param>
        /// <returns>The created and configured DataTables table element.</returns>
        public static DataTablesTable DataTable(this Element element, object objects, Action<DataTablesTable> configure) {
            var table = (DataTablesTable)element.Table(objects, TableType.DataTables);
            configure?.Invoke(table);
            return table;
        }
    }
}