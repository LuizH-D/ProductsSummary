using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using ProductsSummary.Entities;

namespace ProductsSummary {
    class Program {
        static void Main(string[] args) {

            List<Product> products = new List<Product>();

            try {
                Console.WriteLine("ENTER YOUR SOURCE FILE PATH (YOUR FILE MUST BE NAMED AS 'Products.txt'):");
                string sourceFile = Console.ReadLine();
                string targetDirectory = sourceFile.Substring(0, sourceFile.Length - 13);

                using (StreamReader sr = File.OpenText(sourceFile)) {
                    while (!sr.EndOfStream) {
                        string[] lines = sr.ReadLine().Split(",");
                        string productName = lines[0];
                        double productPrice = double.Parse(lines[1], CultureInfo.InvariantCulture);
                        int productQuantity = int.Parse(lines[2]);
                        products.Add(new Product(productName, productPrice, productQuantity));
                    }
                }

                Directory.CreateDirectory(targetDirectory + @"\Summary");
                targetDirectory += @"\Summary";
               
                if (File.Exists(targetDirectory + @"\Summary.csv")) {
                    using (StreamWriter sw = File.CreateText(targetDirectory + $@"\Summary({Directory.GetFiles(targetDirectory, "Summary*.csv", SearchOption.TopDirectoryOnly).Length}).csv")) {
                        foreach (Product product in products) {
                            sw.WriteLine($"{product.Name}, {product.TotalValue().ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
                else {
                    using (StreamWriter sw = File.CreateText(targetDirectory + @"\Summary.csv")) {

                        foreach (Product product in products) {
                            sw.WriteLine($"{product.Name}, {product.TotalValue().ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }

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