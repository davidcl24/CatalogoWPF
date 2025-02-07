using Services_Repos.Models.Data_Classes;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Services_Repos.Rest;

public class RestClientCategory : IRestClient<Category>
{
    private readonly List<Category> _categories;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    private string _endpoint;


    public RestClientCategory()
    {
        _endpoint = "categories";
        _categories = [];
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        _client = new();
        RefreshDataAsync();
    }
    public async Task<List<Category>> RefreshDataAsync()
    {
        Uri uri = new Uri(string.Format(Constants.Consts.HTTP + _endpoint, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                using (JsonDocument doc = JsonDocument.Parse(content))
                {
                    JsonElement root = doc.RootElement;

                    foreach (var jsonElement in root.EnumerateArray())
                    {
                        _categories.Add(new Category
                        {
                            Id = jsonElement.GetProperty("id").GetInt32(),
                            Name = jsonElement.GetProperty("name").GetString(),
                            ImgUrl = jsonElement.GetProperty("image").GetString(),
                        });
                    }
                }
         
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return _categories;
    }

  
}
