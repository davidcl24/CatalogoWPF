namespace Services_Repos.Models.Data_Classes;

public class Product(int id, Category cat, string name, string description, decimal price)
{
    public int Id { get; set; } = id;
    public int CategoryId { get; set; } = cat.Id;
    public Category Category { get; set; } = cat;
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
