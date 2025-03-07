using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    [MaxLength(500)]
    public required string Description { get; set; }
    public List<string> ImageUrls { get; set; } = [];
    [NotMapped]
    public string ImageUrlsSerialized
    {
        get => string.Join(";", ImageUrls);
        set => ImageUrls = string.IsNullOrEmpty(value) ? [] : value.Split(';').ToList(); 
    }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}