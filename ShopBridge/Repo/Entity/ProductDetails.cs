using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Repo.Entity
{
    public class ProductDetails
    {
        [Key]
        public int Product_Code { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Info { get; set; }
        public double Product_Price  { get; set; }
        public int Product_Quantity { get; set; }

    }
}
