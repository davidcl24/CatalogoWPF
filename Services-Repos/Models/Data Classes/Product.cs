namespace Services_Repos.Models.Data_Classes;

public class Product(int id, string name, int catId, string description, decimal price)
{
    public int Id { get; set; } = id;
    public int CategoryId { get; set; } = catId;
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
