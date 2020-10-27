namespace Assignment4
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int SupplierId { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"ProductId = {ProductId}, ProductName = {ProductName}, CategoryName = {Category.CategoryName}";
        }
    }
}