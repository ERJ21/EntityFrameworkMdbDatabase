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
                var obj = context.Locations.ToList();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Admin\\Desktop\\test.txt", true))
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        file.WriteLine("|" + obj[i].LocationId + "|" + obj[i].LocationName + "|");
                    }
                }
            }
        }
    }
}