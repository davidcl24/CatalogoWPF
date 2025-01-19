namespace Services_Repos.Models.Data_Classes;

public class Product(int CategoryId, string name, string description, decimal price)
{
    public int Id { get; set; } 
    public int CategoryId { get; set; } = CategoryId;
    public Category Category { get; set; }
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public decimal Price { get; set; } = price;

    public override string ToString()
    {
        return $"""
                Nombre: {Name} 
                Descripcion: {Description} 
                Precio: {Price}$
                """;
    }
}
