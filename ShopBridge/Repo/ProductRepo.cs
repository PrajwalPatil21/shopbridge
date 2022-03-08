using Microsoft.Extensions.Configuration;
using ShopBridge.Data;
using ShopBridge.Repo.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopBridge.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly IConfiguration _configuration;

        private readonly DataContext _context;
        public ProductRepo(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }
        public List<ProductDetails> GetProducts()
        {
            try
            {
                ProductDetails result = new ProductDetails();
                List<ProductDetails> dataList = new List<ProductDetails>();
                dynamic users = _context.productdata;
                foreach (dynamic record in users)
                {
                    dataList.Add(MapperD(record));
                }
                return dataList;


            }
            catch (Exception ex)
            { throw ex; }
        }
        public ProductDetails MapperD(dynamic record)
        {
            List<ProductDetails> dataList = new List<ProductDetails>();
            ProductDetails prod = new ProductDetails();
            prod.Product_Info = record.Product_Info ?? String.Empty;
            prod.Product_Id = record.Product_Id;
            prod.Product_Name = record.Product_Name ?? String.Empty; 
            prod.Product_Price = record.Product_Price ?? String.Empty;
            prod.Product_Code = record.Product_Code; 
            prod.Product_Quantity = record.Product_Quantity ?? 0 ;
            return prod;
        }

        public string AddProduct(ProductDetails request)
        {
            try
            {
                var user = _context.productdata.FirstOrDefault(x => x.Product_Id == request.Product_Id);
                if (user == null)
                {
                    var productD = new ProductDetails()
                    {
                        Product_Id = request.Product_Id,
                        Product_Code = request.Product_Code,
                        Product_Name = request.Product_Name,
                        Product_Info = request.Product_Info,
                        Product_Price = request.Product_Price,
                        Product_Quantity = request.Product_Quantity,
                    };

                    _context.productdata.Add(productD);
                    _context.SaveChanges();
                    return "Data Added succesfully ";
                }
                else
                    return "Product code already exits";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public ProductDetails UpdateProduct(ProductDetails request)
        {
            try
            {
                if (request.Product_Id != null)
                {
                    var user = _context.productdata.FirstOrDefault(x => x.Product_Id == request.Product_Id);
                    if (user != null)
                    {
                        user.Product_Name = request.Product_Name;
                        user.Product_Info = request.Product_Info;
                        user.Product_Price = request.Product_Price;

                        var da = _context.Entry(user).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else return null;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            List<ProductDetails> dataList = new List<ProductDetails>();
            return request;
        }

        public string DeleteProduct(string request)
        {
            try
            {
                int pCode = Convert.ToInt32(request);
                var user = _context.productdata.FirstOrDefault(x => x.Product_Id == pCode);
                if (user != null)
                {
                    var da = _context.Remove(user);//  Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return "Delete Successfully deleted for Id : "+ request;
                }
                else
                    return "Product Id does not Exit";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //ProductDetails result = new ProductDetails();
            //List<ProductDetails> dataList = new List<ProductDetails>();
            //dynamic users = _context.studentdata;
            //    foreach (dynamic record in users)
            //    {
            //        dataList.Add(MapperD(record));
            //    }
            //return request;
            //}
        }

    }
}
