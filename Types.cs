using System.Collections.Generic;
using System.Text.Json.Serialization;

class Ad {
    [JsonPropertyName("company")]
    public string Company { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

class ColorMetaData {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("color")]
    public string Color { get; set; }
    [JsonPropertyName("pantone_value")]
    public string PantoneValue { get; set; }
}

class ApiMetaData {
    [JsonPropertyName("page")]
    public int Page { get; set; }
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    [JsonPropertyName("data")]
    public IEnumerable<ColorMetaData> Colors { get; set; }
    [JsonPropertyName("ad")]
    public Ad Ad { get; set; }
}