using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ModelContext())
            {
                var categories = context.Categories.ToList();
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("C:\\Users\\Admin\\Desktop\\test.txt", true))
                {
                    for (int i = 0; i < categories.Count+52; i++)
                    {
                        file.WriteLine("|" + categories[i].CategoryId + "|" + categories[i].CategoryName + "|X|"+categories[i].VesselType+"|");
                    }
                }
            }
        }
    }
}
