using JewelryApp.Data;
using JewelryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JewelryApp.Pages;

public class ProductModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ProductModel(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Product? Product { get; set; }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
    
        if (Product == null)
        {
            return NotFound();
        }
        return Page();
    }
}