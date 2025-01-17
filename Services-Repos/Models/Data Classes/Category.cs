namespace Services_Repos.Models.Data_Classes;

public class Category(string name)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public List<Product> Products { get; set; } = [];

    public override string ToString()
    {
        return $"""
                {Name} 
              
                """;
    }
}

