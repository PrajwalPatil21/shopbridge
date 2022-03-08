using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Controllers.Entity
{
    public class ProductData
    {
        [Required]
        public int Product_Code { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string Product_Name { get; set; }
        public string Product_Info { get; set; }
        public double Product_Price { get; set; }
        public int Product_Quantity { get; set; }
    }
}
