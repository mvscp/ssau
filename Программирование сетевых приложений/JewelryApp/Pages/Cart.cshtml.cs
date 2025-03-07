using JewelryApp.Data;
using JewelryApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryApp.Pages;

public class CartModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CartModel(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<Product> Products { get; set; }
    
    public void OnGet()
    {
        var query = _context.Products.AsQueryable();
        query = query.Where(p => new List<int>{2, 3, 8}.Contains(p.Id));
        Products = query.ToList();
    }
}