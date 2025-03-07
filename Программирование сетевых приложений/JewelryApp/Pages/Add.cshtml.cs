using System.Security.AccessControl;
using JewelryApp.Data;
using JewelryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryApp.Pages;

public class AddModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public AddModel(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }
    
    public List<Category>? Categories { get; set; }
    
    [BindProperty]
    public string Name { get; set; }
    
    [BindProperty]
    public string Telephone { get; set; }
    
    [BindProperty]
    public string Email { get; set; }
    
    [BindProperty]
    public string ProductName { get; set; }
    
    [BindProperty]
    public string Category { get; set; }
    
    [BindProperty]
    public int Price { get; set; }
    
    [BindProperty]
    public string Description { get; set; }
    
    [BindProperty]
    public List<IFormFile> Images { get; set; } = [];
    
    public void OnGet()
    {
        Categories = _context.Categories.ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var uploadFolder = Path.Combine(_env.WebRootPath, "img");
        
        List<string> imageUrls = [];

        foreach (var image in Images)
        {
            if (image.Length <= 0) continue;
            
            var uniqueFileName = $"{Guid.NewGuid()}_{image.FileName}";
            var filePath = Path.Combine(uploadFolder, uniqueFileName);
            
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            
            imageUrls.Add(uniqueFileName);
        }
        
        var product = new Product
        {
            Name = ProductName,
            Category = _context.Categories.FirstOrDefault(c => c.Name == Category),
            Price = Price,
            Description = Description,
            ImageUrls = imageUrls
        };
        
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Catalog");
    }
}