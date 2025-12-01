using System;

public class Product:BaseEntity
{
    public string Name { get; set; }= default;
    public string Description { get; set; }= default;
    public string PictureUrl { get; set; = default;
    public decimal Price { get; set; }
}
