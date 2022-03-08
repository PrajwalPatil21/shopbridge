using ShopBridge.Repo.Entity;
using System.Collections.Generic;

namespace ShopBridge.Repo
{
    public interface IProductRepo
    {
        public string AddProduct(ProductDetails request);
        public List<ProductDetails> GetProducts();
        public ProductDetails UpdateProduct(ProductDetails request);

        public string DeleteProduct(string request);
    }
}