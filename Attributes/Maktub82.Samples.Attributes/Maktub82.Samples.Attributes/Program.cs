using Maktub82.Samples.Attributes.Enums;
using Maktub82.Samples.Attributes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktub82.Samples.Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Show Centuries:");
            Console.WriteLine($"Century {Century.XV.GetCenturyName()} [{Century.XV.GetStartYear()},{Century.XV.GetEndYear()}]");
            Console.WriteLine($"Century {Century.XX.GetCenturyName()} [{Century.XX.GetStartYear()},{Century.XX.GetEndYear()}]");
            Console.WriteLine($"Century {Century.XVIII.GetCenturyName()} [{Century.XVIII.GetStartYear()},{Century.XVIII.GetEndYear()}]");
            Console.WriteLine("Show Centuries:");
            Console.WriteLine();

            Console.WriteLine("Show Fruits Name:");
            Console.WriteLine(Fruit.BloodOrange.GetDisplayName());
            Console.WriteLine(Fruit.Watermelon.GetDisplayName());
            Console.WriteLine(Fruit.Lemon.GetDisplayName());
            Console.WriteLine();

            Console.WriteLine("Real Example. Attribute to filter in Api search");
            Console.WriteLine($"To Search by {Category.Films.GetDisplayName()} category: \nhttp://example.api.fake?query=the&category={Category.Films.GenerateQuery()}\n");
            Console.WriteLine($"To Search by {Category.Series.GetDisplayName()} category: \nhttp://example.api.fake?query=the&category={Category.Series.GenerateQuery()}\n");
            Console.WriteLine($"To Search by {Category.Documentary.GetDisplayName()} category: \nhttp://example.api.fake?query=the&category={Category.Documentary.GenerateQuery()}\n");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
