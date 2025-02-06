namespace Services_Repos.Models.Data_Classes;

public class Product
{
    public int Id { get; set; } 
    public int CategoryId { get; set; } 
    public Category Category { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public decimal Price { get; set; } 
    public string ImageUrl { get; set; } 

    public override string ToString()
    {
        return $"""
                {Name} 
                {Description} 
                {Price}$
                """;
    }
}
