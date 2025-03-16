using System.Globalization;

namespace ProductsSummary.Entities {
    internal class SourceFile {
        public string Path { get; private set; }
        
        public SourceFile() {
        }

        public SourceFile(string path) {
            Path = path;
        }


        public List<Product> FileReader(string path) {
            List<Product> products = new List<Product>();
            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] lines = sr.ReadLine().Split(",");
                    string productName = lines[0];
                    double productPrice = double.Parse(lines[1], CultureInfo.InvariantCulture);
                    int productQuantity = int.Parse(lines[2]);
                    products.Add(new Product(productName, productPrice, productQuantity));
                }
                return products;
            }
        }
    }
}
