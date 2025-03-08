namespace ProductsSummary.Entities {
    internal class Product {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }

        public Product() { 
        }

        public Product(string name, double price, int quantity) {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double TotalValue() {
            return Price * Quantity;
        }
            
    }
}
