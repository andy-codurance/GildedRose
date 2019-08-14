﻿using System.Collections.Generic;

namespace GildedRose.Console
{
    public abstract class ShopItem
        : Item
    {
        public abstract void UpdateQuality(Item item);
    }

    public class Ragnaros
        : ShopItem
    {
        public override void UpdateQuality(Item item)
        {
        }
    }
    
    public class NormalItem
        : ShopItem
    {
        public override void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;
            
            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }

    public class BackstagePass
        : ShopItem
    {
        public override void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

            item.SellIn -= 1;
            
            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }
    }

    public class AgedBrie
        : ShopItem
    {
        public override void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;
            
            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }

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
                ShopItem shopItem;
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        shopItem = new Ragnaros();
                        shopItem.UpdateQuality(item);
                        break;
                    case "Aged Brie":
                        shopItem = new AgedBrie();
                        shopItem.UpdateQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        shopItem = new BackstagePass();
                        shopItem.UpdateQuality(item);
                        break;
                    default:
                        shopItem = new NormalItem();
                        shopItem.UpdateQuality(item);
                        break;
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
