using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        AgedBriePreSellIn(item);
                        DecreaseSellIn(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        BackstagePassPreSellIn(item);
                        DecreaseSellIn(item);
                        break;
                    }
                    default:
                    {
                        NormalItemPreSellIn(item);
                        DecreaseSellIn(item);
                        break;
                    }
                }
                
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.SellIn < 0)
                        {
                            IncreaseQualityIfFiftyOrLess(item);
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn < 0)
                        {
                            SetQualityToZero(item);
                        }
                        break;
                    default:
                        if (item.SellIn < 0)
                        {
                            DecreaseQualityIfGreaterThanZero(item);
                        }
                        break;
                }
            }
        }

        private static void NormalItemPreSellIn(Item item)
        {
            DecreaseQualityIfGreaterThanZero(item);
        }

        private static void BackstagePassPreSellIn(Item item)
        {
            IncreaseQualityIfFiftyOrLess(item);

            if (item.SellIn < 11)
            {
                IncreaseQualityIfFiftyOrLess(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQualityIfFiftyOrLess(item);
            }
        }

        private static void AgedBriePreSellIn(Item item)
        {
            IncreaseQualityIfFiftyOrLess(item);
        }

        private static void DecreaseQualityIfGreaterThanZero(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private static void IncreaseQualityIfFiftyOrLess(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private static void SetQualityToZero(Item item)
        {
            item.Quality -= item.Quality;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
