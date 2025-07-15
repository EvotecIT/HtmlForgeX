using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests serialization of SearchBuilder advanced features.
/// </summary>
[TestClass]
public class TestDataTablesSearchBuilder {
    [TestMethod]
    public void SearchBuilder_SerializesConditionGroupsAndCustomOperators() {
        var table = new DataTablesTable();
        table.ConfigureSearchBuilder(sb => sb
            .Group(g => g
                .Logic("AND")
                .Criterion("Amount", ">", 100))
            .CustomOperator("startsWith", "function(v,i){ return v.startsWith(i); }")
        );

        var html = table.ToString();
        StringAssert.Contains(html, "\"conditionGroups\"");
        StringAssert.Contains(html, "startsWith");
    }
}
