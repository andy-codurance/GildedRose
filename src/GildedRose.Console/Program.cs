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
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        IncreaseQualityByOne(item);

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    IncreaseQualityByOne(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    IncreaseQualityByOne(item);
                                }
                            }
                        }
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        IncreaseQualityByOne(item);
                        
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                IncreaseQualityByOne(item);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                IncreaseQualityByOne(item);
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality <= 0)
                    {
                        // do not decrease quality
                    }
                    else if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                        // do not decrease quality
                    }
                    else
                    {
                        DecreaseQualityByOne(item);
                    }
                }

                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    // do not decrease sellin
                }
                else
                {
                    DecreaseSellIn(item);
                }

                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQualityByOne(item);
                        }
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            SetQualityToZero(item);
                        }
                        else
                        {
                            if (item.Quality <= 0)
                            {
                                continue;
                            }

                            if (item.Name == "Sulfuras, Hand of Ragnaros")
                            {
                                continue;
                            }

                            DecreaseQualityByOne(item);
                        }
                    }
                }
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

        private static void DecreaseQualityByOne(Item item)
        {
            item.Quality -= 1;
        }

        private static void IncreaseQualityByOne(Item item)
        {
            item.Quality += 1;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
