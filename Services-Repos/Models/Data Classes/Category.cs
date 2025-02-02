namespace Services_Repos.Models.Data_Classes;

public class Category(string name, string imgUrl)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public string ImgUrl { get; set; } = imgUrl;
    public List<Product> Products { get; set; } = [];

    public override string ToString()
    {
        return $"""
                {Name} 
              
                """;
    }
}

