using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexCharts : Element {
    public string Id { get; set; }
    public string Type { get; set; }
    public List<double> Series { get; set; } = new List<double>();
    public List<string> Labels { get; set; } = new List<string>();
    public ApexChartsTitle Title { get; set; } = new ApexChartsTitle();
    public ApexChartSubtitle Subtitle { get; set; } = new ApexChartSubtitle();

    public ApexCharts() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("apexChart");
    }

    /// <summary>
    /// Registers the required libraries for ApexCharts.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.ApexCharts, 0);
    }

    public ApexCharts AddPie(string name, double value) {
        Type = "pie";
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddDonut(string name, double value) {
        Type = "donut";
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddBar(string name, double value) {
        Type = "bar";
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts Data(string name, double value) {
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public override string ToString() {
        // Generate ID using document configuration if available, otherwise use GlobalStorage as fallback
        if (string.IsNullOrEmpty(Id)) {
            Id = Document?.Configuration.GenerateRandomId("apexChart") ?? GlobalStorage.GenerateRandomId("apexChart");
        }

        var divTag = new HtmlTag("div").Attribute("id", Id);

        var options = new Dictionary<string, object> {
            ["chart"] = new Dictionary<string, string> {
                ["type"] = Type
            }
        };

        if (Title.IsSet) {
            options["title"] = Title;
        }

        if (Subtitle.IsSet) {
            options["subtitle"] = Subtitle;
        }

        if (Series.Count > 0) {
            if (Type == "bar") {
                options["series"] = new List<object> { new { data = Series } };
            } else {
                options["series"] = Series;
            }
        }

        if (Labels.Count > 0) {
            options["labels"] = Labels;
        }

        //options = options.RemoveEmptyCollections();

        var optionsJson = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var scriptTag = new HtmlTag("script").Value($@"
        var options = {optionsJson};
        var chart = new ApexCharts(document.querySelector('#{Id}'), options);
        chart.render();
    ");

        return divTag + scriptTag.ToString();
    }
}