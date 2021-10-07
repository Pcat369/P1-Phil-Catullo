namespace Models
{
    public class Product
    {
        public Product()
        {
            
        }
        
        public string Description { get; set; }

        public string Manufacturer { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ProductID { get; set; }

        public override string ToString()
        {
            return $"Item name: {this.Name} \nProductID: {this.ProductID} \nDescription: {this.Description} \nManufactured By: {this.Manufacturer} \nPrice: {this.Price} \n  ";
        }
        
    }
}