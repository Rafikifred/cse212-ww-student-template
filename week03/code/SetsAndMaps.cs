using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find all symmetric pairs of two-letter words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        var used = new HashSet<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip same letters like "aa"
            var reversed = new string(word.Reverse().ToArray());
            if (wordSet.Contains(reversed) && !used.Contains(word) && !used.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                used.Add(word);
                used.Add(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from a CSV file
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;

            string degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Check if two words are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string Clean(string w) => new string(w.ToLower().Where(c => !Char.IsWhiteSpace(c)).ToArray());

        var w1 = Clean(word1);
        var w2 = Clean(word2);

        if (w1.Length != w2.Length) return false;

        var count = new Dictionary<char, int>();
        foreach (var c in w1)
            count[c] = count.ContainsKey(c) ? count[c] + 1 : 1;

        foreach (var c in w2)
        {
            if (!count.ContainsKey(c)) return false;
            count[c]--;
            if (count[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Earthquake summary from USGS JSON feed
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties?.Place ?? "Unknown location";
                string mag = feature.Properties?.Mag?.ToString() ?? "No magnitude";
                result.Add($"{place} : {mag}");
            }
        }

        return result.ToArray();
    }
}
