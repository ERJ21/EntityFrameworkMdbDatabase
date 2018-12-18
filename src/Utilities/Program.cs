using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerializeDbInfoJson(@"C:\Users\Admin\Desktop\DelayTrackerDBs\Vessels", @"C:\Users\Admin\Desktop\test.json");
            DelayTrackerDbFileInfo[] array = JsonConvert.DeserializeObject<DelayTrackerDbFileInfo[]>(File.ReadAllText(@"C:\Users\Admin\Desktop\test.json"));
        }

        private static void SerializeDbInfoJson(string rootDirectory, string outputPath)
        {
            var tasks = new List<Task<DelayTrackerDbFileInfo>>();
            foreach (string file in Directory.EnumerateFiles(
                rootDirectory, "*.mdb", SearchOption.AllDirectories))
            {
                string taskFile = file;
                Console.WriteLine(taskFile);
                var t = Task.Factory.StartNew(() =>
                {
                    IEnumerable<string> tableNames = null;

                    try
                    {
                        tableNames = ExtractTableNames(taskFile);
                    }
                    catch { }

                    return new DelayTrackerDbFileInfo(taskFile, tableNames);
                });

                tasks.Add(t);
            }

            Task.Factory.ContinueWhenAll(tasks.ToArray(),
                result =>
                {
                    File.WriteAllText(
                        outputPath,
                        JsonConvert.SerializeObject(result.Select(t => t.Result)));
                }).Wait();
        }

        private static IEnumerable<string> ExtractTableNames(string mdbFilePath)
        {
            using (var connection = new OleDbConnection($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={mdbFilePath};"))
            {
                connection.Open();

                return connection
                    .GetSchema("tables")
                    .AsEnumerable()
                    .Select(r => r.Field<string>("TABLE_NAME"))
                    .Where(t => !t.StartsWith("MSys"))
                    .ToArray();
            }
        }
    }
}
