using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JewelryApp.Data;
using JewelryApp.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace JewelryApp.Pages;

public class CatalogModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CatalogModel(ApplicationDbContext context)
    {
        _context = context;
    }
        
    public IPagedList<Product>? Products { get; set; }
    public List<Category>? Categories { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string FilterCategory { get; set; } = "all";

    [BindProperty(SupportsGet = true)]
    public int? PriceFrom { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? PriceTo { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string? SearchQuery { get; set; }
    
    private int _pageSize = 6;

    public void OnGet(int? pageNumber)
    {
        Categories = _context.Categories.ToList();
        
        var query = _context.Products.AsQueryable();
        
        if (!string.IsNullOrEmpty(FilterCategory) && FilterCategory.ToLower() != "all")
        {
            query = query.Where(p => p.Category.Name == FilterCategory);
        }
        
        if (PriceFrom.HasValue)
        {
            query = query.Where(p => p.Price >= PriceFrom.Value);
        }
        if (PriceTo.HasValue)
        {
            query = query.Where(p => p.Price <= PriceTo.Value);
        }
        
        if (!string.IsNullOrEmpty(SearchQuery))
        {
            query = query.Where(p => p.Name.Contains(SearchQuery));
        }
        
        Products = query.ToPagedList(pageNumber ?? 1, _pageSize);
    }
}