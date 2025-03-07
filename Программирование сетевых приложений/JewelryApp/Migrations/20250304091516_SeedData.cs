using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Браслеты" },
                    { 2, "Кольца" },
                    { 3, "Серьги" },
                    { 4, "Подвески" },
                    { 5, "Колье" },
                    { 6, "Цепочки" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrls", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 4, "The crowned triple moon of the mother goddess endowed with the principle seal of Lilith upon the onyx disc, flanked by the alchemical sigils for mercury and sulphur.\n\nDrape yourself in this extraordinary adornment, designed for the modern witch and the free-spirited soul!\n\nEmbrace the awe of divine femininity and mystical power with our exquisite 'Wycca Queen' crowned triple moon necklace. Inlaid with a stunning black onyx disc. Crafted with precision, the necklace is etched with intricate Alchemical sigils and the enigmatic seal of Lilith, connecting you to the depths of ancient wisdom and esoteric beauty. The polished pewter offers a celestial shine, while a mesmerizing grey Austrian crystal shimmers gracefully below, catching the light with every movement!", "wycca-queen.jpg;wycca-queen1.jpg", "R969 - Wycca Queen", 5100 },
                    { 2, 2, "The monstrous, deadly, predator is quiescent, unnervingly poised to strike and sink its fangs in whatever may sate its desire.\n\nA giant spider, black pewter ring with a large red Austrian crystal body.", "black-widow.jpg;black-widow1.jpg", "R222B - Black Widow", 4800 },
                    { 3, 1, "Featuring the classic version of Behemoth's iconic logo design.\n\nA 3D sculpted pewter logo.", "behemoth-logo.jpg", "HRWL458 - Behemoth: Logo", 2200 },
                    { 4, 5, "This actias, nocturnal and most rare of species, bears markings uncannily akin to the lunation of our influential moon.\n\nCapture the magic of the night with our Lunar Moth necklace - a piece that is larger than life. Inspired by the dark beauty of nature, this exceptional necklace features intricately crafted moon phase cut-out details that create a stunning visual narrative of the lunar cycle. Showcasing hand-polished contrasting details that catch the light beautifully. At its heart lies a breathtaking iridescent grey mother of pearl inlaid disc, embodying the full moon's radiant glow...", "lunar-moth.jpg;lunar-moth1.jpg;lunar-moth2.jpg", "R574 - Lunar Moth", 4500 },
                    { 5, 4, "In historic Burgundy, this legendary dragon dwelt amongst the trees and dark waters of the forest, shying from any young lovers they might encounter.\n\nExpress the magic of love and mystique with our exquisite Dragon Pendant, a captivating blend of artistry and passion. Crafted in fine English pewter with meticulous attention to detail. The Siam red eye of the dragon glimmers with intensity, drawing you in and captivating all of those that see it!", "vouivre.jpg;vouivre1.jpg;vouivre2.jpg;vouivre3.jpg", "P968 - Vouivre", 3900 },
                    { 6, 3, "The wax and wane of tidal magic moving unseen through our deepest desires and fears as the Goddesses' tears cleave the night asunder.\n\nThe amethyst tear - spirituality, creativity, and transformation.\n\nEarrings that will have you dancing in the moon light!\n\nA dreamy pair of earrings featuring a handmade pewter moons with a delicate Amethyst Austrian crystal dropper.", "tears-of-the-moon-amethyst.jpg", "E477A - Tears of the Moon - Amethyst", 2000 },
                    { 7, 5, "The deadly predator, poised to sink its irresistible fangs.\n\nAn eye-catching necklace that will inject gothic drama into any outfit\n\nA giant blackened pewter spider necklace set with red Austrian crystals.", "black-widow-neck.jpg;black-widow-neck1.jpg", "P432B - Black Widow", 5700 },
                    { 8, 5, "The deadly predator, poised to sink its irresistible fangs.\n\nAn eye-catching necklace that will inject gothic drama into any outfit\n\nA giant pewter spider necklace set with green and black Austrian crystals.", "emerald-venom.jpg", "P432 - Emerald Venom", 5400 },
                    { 9, 3, "This three in one hanging decoration, wind spiral and wind chime will make a dark statement in your home or garden. Based on the alternative icon the Spider, it will certainly give your guests a fright!\n\nAdd your own unique style to any room, home or garden with these Alchemy designed hanging decorations/ wind chimes. We have designs to suit every alternative taste.\n\nSpider - Hanging decoration - Black colour. Suitable for both indoor and outdoor use.", "spider.jpg", "HD10 - Spider", 3300 },
                    { 10, 3, "The deadly, viridescent predatory pair are quiescent, unnervingly poised to sink their fangs into any convenient and desirable prey.\n\nEye catching earrings that will inject Gothic drama into any outfit!\n\nA pair of 40mm long antique pewter, spider earrings, their bodies set with green Austrian crystals; on surgical steel ear-wires.", "emerald-venom1.jpg", "E428 - Emerald Venom", 3800 },
                    { 11, 2, "The monstrous, deadly, viridescent predator is quiescent, unnervingly poised to strike and sink its fangs in whatever may sate its desire.\n\nA giant spider, polished pewter ring with a large emerald green Austrian crystal body.", "emerald-venom2.jpg", "R222- Emerald Venom", 2500 },
                    { 12, 4, "Featuring the 'Contra' snake sigil from Behemoth's 2022 12th studio album 'Opvs Contra Natvram'.\n\nA 3D sculpted, antiqued English pewter pendant on 21\" trace chain.", "behemoth-opvs-contra-natvram.jpg", "PP526 - Behemoth: Opvs Contra Natvram", 4000 },
                    { 13, 2, "From ancient Greek philosophy, the Ouroboros, a snake-serpent eating its own tail, is the Gnostic symbol of eternity, rebirth and the unity of everything, representing both the sun and soul of the world.\n\nA pewter Ouroboros ring of a serpent swallowing its own tail, and with green Austrian crystal-set eyes.", "the-sophia-serpent.jpg", "R206 - The Sophia Serpent", 2300 },
                    { 14, 4, "This serpent, evincing its three coils, symbolises the pagan/Wiccan Rule of Three; that all energy transmitted into the world by somebody - positive or negative, is returned threefold to that same person.\n\nFeel wonderfully special in this spectacular serpent inspired piece!\n\nA long, intricate pewter snake in an open knot, cruciform configuration, with a lower centrally-set dark emerald, round Austrian crystal and a matching dropper below. The pendant hangs from a fine trace chain triangle with black crystal junctions, (measuring 7\" [18cm] long altogether).", "tercia-serpent.jpg", "P874 - Tercia Serpent", 3100 },
                    { 15, 2, "\"Let God arise and His enemies be scattered\"; 'Nachash', the serpent was the embodiment of wicked power from the underworld, as evidenced in the Garden of Eden, however, the serpent conversely became a symbol of fertility, healing and life and, especially green, represented love and sexual desire.\n\nA statement ring that would site perfectly on any finger!\n\nAn easily adjustable pewter ring of a coiled serpent, with a green Austrian crystal set into its head.", "psalm-68.jpg", "R228 - Psalm 68", 2900 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
