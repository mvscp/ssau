using Microsoft.EntityFrameworkCore;
using JewelryApp.Models;

namespace JewelryApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category) // У продукта одна категория
            .WithMany(c => c.Products) // У категории много продуктов
            .HasForeignKey(p => p.CategoryId) // Внешний ключ
            .OnDelete(DeleteBehavior.Cascade); // Если удаляется категория — удаляются её товары
        
        modelBuilder.Entity<Product>()
            .Property(p => p.ImageUrls)
            .HasConversion(
                v => string.Join(';', v), 
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Браслеты" },
            new Category { Id = 2, Name = "Кольца" },
            new Category { Id = 3, Name = "Серьги" },
            new Category { Id = 4, Name = "Подвески" },
            new Category { Id = 5, Name = "Колье" },
            new Category { Id = 6, Name = "Цепочки" }
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "R969 - Wycca Queen", Price = 5100, Description = "The crowned triple moon of the mother goddess endowed with the principle seal of Lilith upon the onyx disc, flanked by the alchemical sigils for mercury and sulphur.\n\nDrape yourself in this extraordinary adornment, designed for the modern witch and the free-spirited soul!\n\nEmbrace the awe of divine femininity and mystical power with our exquisite 'Wycca Queen' crowned triple moon necklace. Inlaid with a stunning black onyx disc. Crafted with precision, the necklace is etched with intricate Alchemical sigils and the enigmatic seal of Lilith, connecting you to the depths of ancient wisdom and esoteric beauty. The polished pewter offers a celestial shine, while a mesmerizing grey Austrian crystal shimmers gracefully below, catching the light with every movement!", ImageUrlsSerialized = "wycca-queen.jpg;wycca-queen1.jpg", CategoryId = 4 },
            new Product { Id = 2, Name = "R222B - Black Widow", Price = 4800, Description = "The monstrous, deadly, predator is quiescent, unnervingly poised to strike and sink its fangs in whatever may sate its desire.\n\nA giant spider, black pewter ring with a large red Austrian crystal body.", ImageUrlsSerialized = "black-widow.jpg;black-widow1.jpg", CategoryId = 2 },
            new Product {Id = 3, Name = "HRWL458 - Behemoth: Logo", Price = 2200, Description = "Featuring the classic version of Behemoth's iconic logo design.\n\nA 3D sculpted pewter logo.", ImageUrlsSerialized = "behemoth-logo.jpg", CategoryId = 1},
            new Product {Id = 4, Name = "R574 - Lunar Moth", Price = 4500, Description = "This actias, nocturnal and most rare of species, bears markings uncannily akin to the lunation of our influential moon.\n\nCapture the magic of the night with our Lunar Moth necklace - a piece that is larger than life. Inspired by the dark beauty of nature, this exceptional necklace features intricately crafted moon phase cut-out details that create a stunning visual narrative of the lunar cycle. Showcasing hand-polished contrasting details that catch the light beautifully. At its heart lies a breathtaking iridescent grey mother of pearl inlaid disc, embodying the full moon's radiant glow...", ImageUrlsSerialized = "lunar-moth.jpg;lunar-moth1.jpg;lunar-moth2.jpg", CategoryId = 5},
            new Product {Id = 5, Name = "P968 - Vouivre", Price = 3900, Description = "In historic Burgundy, this legendary dragon dwelt amongst the trees and dark waters of the forest, shying from any young lovers they might encounter.\n\nExpress the magic of love and mystique with our exquisite Dragon Pendant, a captivating blend of artistry and passion. Crafted in fine English pewter with meticulous attention to detail. The Siam red eye of the dragon glimmers with intensity, drawing you in and captivating all of those that see it!", ImageUrlsSerialized = "vouivre.jpg;vouivre1.jpg;vouivre2.jpg;vouivre3.jpg", CategoryId = 4},
            new Product {Id = 6, Name = "E477A - Tears of the Moon - Amethyst", Price = 2000, Description = "The wax and wane of tidal magic moving unseen through our deepest desires and fears as the Goddesses' tears cleave the night asunder.\n\nThe amethyst tear - spirituality, creativity, and transformation.\n\nEarrings that will have you dancing in the moon light!\n\nA dreamy pair of earrings featuring a handmade pewter moons with a delicate Amethyst Austrian crystal dropper.", ImageUrlsSerialized = "tears-of-the-moon-amethyst.jpg", CategoryId = 3},
            new Product {Id = 7, Name = "P432B - Black Widow", Price = 5700, Description = "The deadly predator, poised to sink its irresistible fangs.\n\nAn eye-catching necklace that will inject gothic drama into any outfit\n\nA giant blackened pewter spider necklace set with red Austrian crystals.", ImageUrlsSerialized = "black-widow-neck.jpg;black-widow-neck1.jpg", CategoryId = 5},
            new Product {Id = 8, Name = "P432 - Emerald Venom", Price = 5400, Description = "The deadly predator, poised to sink its irresistible fangs.\n\nAn eye-catching necklace that will inject gothic drama into any outfit\n\nA giant pewter spider necklace set with green and black Austrian crystals.", ImageUrlsSerialized = "emerald-venom.jpg", CategoryId = 5},
            new Product {Id = 9, Name = "HD10 - Spider", Price = 3300, Description = "This three in one hanging decoration, wind spiral and wind chime will make a dark statement in your home or garden. Based on the alternative icon the Spider, it will certainly give your guests a fright!\n\nAdd your own unique style to any room, home or garden with these Alchemy designed hanging decorations/ wind chimes. We have designs to suit every alternative taste.\n\nSpider - Hanging decoration - Black colour. Suitable for both indoor and outdoor use.", ImageUrlsSerialized = "spider.jpg", CategoryId = 3},
            new Product {Id = 10, Name = "E428 - Emerald Venom", Price = 3800, Description = "The deadly, viridescent predatory pair are quiescent, unnervingly poised to sink their fangs into any convenient and desirable prey.\n\nEye catching earrings that will inject Gothic drama into any outfit!\n\nA pair of 40mm long antique pewter, spider earrings, their bodies set with green Austrian crystals; on surgical steel ear-wires.", ImageUrlsSerialized = "emerald-venom1.jpg", CategoryId = 3},
            new Product {Id = 11, Name = "R222- Emerald Venom", Price = 2500, Description = "The monstrous, deadly, viridescent predator is quiescent, unnervingly poised to strike and sink its fangs in whatever may sate its desire.\n\nA giant spider, polished pewter ring with a large emerald green Austrian crystal body.", ImageUrlsSerialized = "emerald-venom2.jpg", CategoryId = 2},
            new Product {Id = 12, Name = "PP526 - Behemoth: Opvs Contra Natvram", Price = 4000, Description = "Featuring the 'Contra' snake sigil from Behemoth's 2022 12th studio album 'Opvs Contra Natvram'.\n\nA 3D sculpted, antiqued English pewter pendant on 21\" trace chain.", ImageUrlsSerialized = "behemoth-opvs-contra-natvram.jpg", CategoryId = 4},
            new Product {Id = 13, Name = "R206 - The Sophia Serpent", Price = 2300, Description = "From ancient Greek philosophy, the Ouroboros, a snake-serpent eating its own tail, is the Gnostic symbol of eternity, rebirth and the unity of everything, representing both the sun and soul of the world.\n\nA pewter Ouroboros ring of a serpent swallowing its own tail, and with green Austrian crystal-set eyes.", ImageUrlsSerialized = "the-sophia-serpent.jpg", CategoryId = 2},
            new Product {Id = 14, Name = "P874 - Tercia Serpent", Price = 3100, Description = "This serpent, evincing its three coils, symbolises the pagan/Wiccan Rule of Three; that all energy transmitted into the world by somebody - positive or negative, is returned threefold to that same person.\n\nFeel wonderfully special in this spectacular serpent inspired piece!\n\nA long, intricate pewter snake in an open knot, cruciform configuration, with a lower centrally-set dark emerald, round Austrian crystal and a matching dropper below. The pendant hangs from a fine trace chain triangle with black crystal junctions, (measuring 7\" [18cm] long altogether).", ImageUrlsSerialized = "tercia-serpent.jpg", CategoryId = 4},
            new Product {Id = 15, Name = "R228 - Psalm 68", Price = 2900, Description = "\"Let God arise and His enemies be scattered\"; 'Nachash', the serpent was the embodiment of wicked power from the underworld, as evidenced in the Garden of Eden, however, the serpent conversely became a symbol of fertility, healing and life and, especially green, represented love and sexual desire.\n\nA statement ring that would site perfectly on any finger!\n\nAn easily adjustable pewter ring of a coiled serpent, with a green Austrian crystal set into its head.", ImageUrlsSerialized = "psalm-68.jpg", CategoryId = 2}
        );
    }
}