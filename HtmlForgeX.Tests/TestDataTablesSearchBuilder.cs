using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests serialization of SearchBuilder advanced features.
/// </summary>
[TestClass]
public class TestDataTablesSearchBuilder {
    /// <summary>
    /// Ensures that complex groups and custom operators are correctly
    /// serialized into the generated HTML.
    /// </summary>
    [TestMethod]
    public void SearchBuilder_SerializesConditionGroupsAndCustomOperators() {
        var table = new DataTablesTable();
        table.ConfigureSearchBuilder(sb => sb
            .Group(g => g
                .Logic(DataTablesSearchLogic.And)
                .Criterion("Amount", DataTablesSearchCondition.GreaterThan, 100))
            .CustomOperator(DataTablesBuiltInOperator.StartsWith)
            .CustomOperator(DataTablesBuiltInOperator.Between)
        );

        var html = table.ToString();
        StringAssert.Contains(html, "\"conditionGroups\"");
        StringAssert.Contains(html, "startsWith");
        StringAssert.Contains(html, "between");
    }
}