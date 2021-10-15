using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelperDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AutoMapping();
            MapByName();
            MapByIndex();
            ConvertType();
            await NonBlocking();
        }

        private static void AutoMapping()
        {
            StartDemo(nameof(AutoMapping));

            var fileName = "sample_v1.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    var data = csv.GetRecords<PersonV1>();

                    foreach (var person in data)
                    {
                        person.Print();
                    }
                }
            }
        }

        private static void MapByName()
        {
            StartDemo(nameof(MapByName));

            var fileName = "sample_v2.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    csv.Context.RegisterClassMap<PersonMapByName>();
                    var data = csv.GetRecords<PersonV1>();

                    foreach (var person in data)
                    {
                        person.Print();
                    }
                }
            }
        }

        private static void MapByIndex()
        {
            StartDemo(nameof(MapByIndex));

            var fileName = "sample_v3.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    csv.Context.RegisterClassMap<PersonMapByIndex>();
                    var data = csv.GetRecords<PersonV1>();

                    foreach (var person in data)
                    {
                        person.Print();
                    }
                }
            }
        }

        private static void ConvertType()
        {
            StartDemo(nameof(ConvertType));

            var fileName = "sample_v1.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    csv.Context.RegisterClassMap<PersonMapWithConverter>();
                    var data = csv.GetRecords<PersonV2>();

                    foreach (var person in data)
                    {
                        person.Print();
                    }
                }
            }
        }

        private static async Task NonBlocking()
        {
            StartDemo(nameof(NonBlocking));

            var fileName = "sample_v1.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    var data = csv.GetRecordsAsync<PersonV1>();

                    await foreach (var person in data)
                    {
                        person.Print();
                    }
                }
            }
        }

        private static void StartDemo(string name)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"Starting demo for: {name}");
        }
    }
}
