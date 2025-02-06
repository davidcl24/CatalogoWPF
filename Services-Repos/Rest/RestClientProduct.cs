using Services_Repos.Models.Data_Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Services_Repos.Rest;

public class RestClientProduct : IRestClient<Product>
{
    private List<Product>? products;
    readonly HttpClient _client;
    readonly JsonSerializerOptions _serializerOptions;

    public string Endpoint { get; set; }

    public RestClientProduct()
    {
        products = [];
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        }; 
        _client = new();
        RefreshDataAsync();
    }

    public async Task<List<Product>> RefreshDataAsync()
    {
        Uri uri = new Uri(string.Format(Constants.Consts.HTTP+Endpoint, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                using(JsonDocument doc = JsonDocument.Parse(content))
                {
                    JsonElement root = doc.RootElement;

                    foreach (var jsonElement in root.EnumerateArray())
                    {
                        products.Add(new Product
                        {
                            Name = jsonElement.GetProperty("title").GetString(),
                            Description = jsonElement.GetProperty("description").GetString(),
                            ImageUrl = jsonElement.GetProperty("images")[0].GetString(),
                            Price = (decimal) jsonElement.GetProperty("price").GetDouble(),
                            CategoryId = jsonElement.GetProperty("category").GetProperty("id").GetInt32(),
                            Category = new Category
                            {
                                Id = jsonElement.GetProperty("category").GetProperty("id").GetInt32(),
                                Name = jsonElement.GetProperty("category").GetProperty("name").GetString(),
                                ImgUrl = jsonElement.GetProperty("category").GetProperty("name").GetString()
                            }
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return products;
    }

}
