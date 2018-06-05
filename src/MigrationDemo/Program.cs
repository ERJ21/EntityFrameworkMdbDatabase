using DelayTracker.Migrations;
using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using System;

namespace MigrationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string v2_0FilePath = @"C:\Users\JanGo\Desktop\Vessels\Hydraulic\Texas\DatabaseFiles\151215_DelaysDB.mdb";
            string v2_1FilePath = @"C:\Users\JanGo\Desktop\DelaysDB.2.1.mdb";

            DbContextOptions<DelayTracker.v2_0.ModelContext> v2_0Options =
                new DbContextOptionsBuilder<DelayTracker.v2_0.ModelContext>()
                .UseJet($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={v2_0FilePath};")
                .Options;

            DbContextOptions<DelayTracker.v2_1.ModelContext> v2_1Options =
                new DbContextOptionsBuilder<DelayTracker.v2_1.ModelContext>()
                .UseJet($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={v2_1FilePath};")
                .Options;

            using (var v2_0Context = new DelayTracker.v2_0.ModelContext(v2_0Options))
            using (var v2_1Context = new DelayTracker.v2_1.ModelContext(v2_1Options))
            {
                new Migratorv2_0Tov2_1().Migrate(v2_0Context, v2_1Context);

                v2_1Context.SaveChanges();
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
