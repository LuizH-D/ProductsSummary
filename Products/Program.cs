using System;
using System.IO;
using System.Globalization;
using ProductsSummary.Entities;

namespace ProductsSummary {
    class Program {
        static void Main(string[] args) {
            try {
                Console.WriteLine("ENTER YOUR SOURCE FILE PATH (YOUR FILE MUST BE NAMED AS 'Products.txt'):");
                string path = Console.ReadLine();
                SourceFile sourceFile = new SourceFile(path);
                string targetDirectory = sourceFile.Path.Substring(0, sourceFile.Path.Length - 13);

                Directory.CreateDirectory(targetDirectory + @"\Summary");
                targetDirectory += @"\Summary";
               
                if (File.Exists(targetDirectory + @"\Summary.csv")) {
                    using (StreamWriter sw = File.CreateText(targetDirectory + $@"\Summary({Directory.GetFiles(targetDirectory, "Summary*.csv", SearchOption.TopDirectoryOnly).Length}).csv")) {
                        foreach (Product product in sourceFile.FileReader(sourceFile.Path)) {
                            sw.WriteLine($"{product.Name},{product.TotalValue().ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
                else {
                    using (StreamWriter sw = File.CreateText(targetDirectory + @"\Summary.csv")) {

                        foreach (Product product in sourceFile.FileReader(sourceFile.Path)) {
                            sw.WriteLine($"{product.Name},{product.TotalValue().ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Summary created!");
            }

            catch (FormatException ex) {
                Console.WriteLine("Format error!:\n" + ex.Message);
            }

            catch (IOException ex) {
                Console.WriteLine("An error occurred!:\n" + ex.Message);
            }

            catch (Exception ex) {
                Console.WriteLine("An error occurred!:\n" + ex.Message);
            }
        }
    }
}