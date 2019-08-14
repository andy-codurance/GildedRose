namespace GildedRose.Tests
{
    using System.Linq;
    using Console;

    internal static class ProgramFactory
    {
        public static Program Create(params Item[] item)
        {
            var app = new Program
            {
                Items = item.ToList()
            };
            return app;
        }
    }
}