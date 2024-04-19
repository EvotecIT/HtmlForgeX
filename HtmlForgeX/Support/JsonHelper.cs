using System.Collections;
using System.Text.Json;

namespace HtmlForgeX.Support;

internal static class JsonHelper {
    //internal static Dictionary<string, object> RemoveEmptyCollections(this IDictionary<string, object> dictionary) {
    //    var keysToRemove = new List<string>();

    //    foreach (var pair in dictionary) {
    //        if (pair.Value is IDictionary<string, object> nestedDictionary) {
    //            nestedDictionary.RemoveEmptyCollections();

    //            if (nestedDictionary.Count == 0) {
    //                keysToRemove.Add(pair.Key);
    //            }
    //        } else if (pair.Value is ICollection collection && collection.Count == 0) {
    //            keysToRemove.Add(pair.Key);
    //        } else if (pair.Value == null) {
    //            keysToRemove.Add(pair.Key);
    //        } else if (pair.Value.GetType().IsClass) {
    //            try {
    //                var nestedDictionary1 = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(pair.Value));
    //                nestedDictionary1.RemoveEmptyCollections();

    //                if (nestedDictionary1.Count == 0) {
    //                    keysToRemove.Add(pair.Key);
    //                } else {
    //                    dictionary[pair.Key] = nestedDictionary1;
    //                }
    //            } catch (JsonException) {
    //                // Ignore values that can't be converted to a dictionary
    //            }
    //        }
    //    }

    //    foreach (var key in keysToRemove) {
    //        dictionary.Remove(key);
    //    }

    //    return dictionary as Dictionary<string, object>;
    //}

}
