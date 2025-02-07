using Services_Repos.Models.Data_Classes;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Services_Repos.Rest;

public class RestClientProduct : IRestClient<Product>
{
    private readonly List<Product> _products;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    private string _endpoint;
    public RestClientProduct()
    {
        _endpoint = "products";
        _products = [];
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
        Uri uri = new Uri(string.Format(Constants.Consts.HTTP+_endpoint, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(content);
                JsonElement root = doc.RootElement;

                foreach (var jsonElement in root.EnumerateArray())
                {
                    _products.Add(new Product
                    {
                        Name = jsonElement.GetProperty("title").GetString(),
                        Description = jsonElement.GetProperty("description").GetString(),
                        ImageUrl = jsonElement.GetProperty("images")[0].GetString(),
                        Price = (decimal)jsonElement.GetProperty("price").GetDouble(),
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
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return _products;
    }

}
