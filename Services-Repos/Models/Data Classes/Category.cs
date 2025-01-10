namespace Services_Repos.Models.Data_Classes;

public class Category(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public List<Product> Products { get; set; } = new();

    public override string ToString()
    {
        return $"""
                {Name} 
                ------------------------
                """;
    }
}

