namespace Services_Repos.Models.Data_Classes;

public class Category()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public List<Product> Products { get; set; } = [];

    public override string ToString()
    {
        return $"""
                {Name} 
              
                """;
    }
}

