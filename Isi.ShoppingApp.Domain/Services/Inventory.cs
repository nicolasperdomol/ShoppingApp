using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Data.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isi.ShoppingApp.Domain.Services
{
    public class Inventory
    {
        ProductRepository repository;
        public Inventory()
        {
        
        }

        public ObservableCollection<Product> GetDBProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            repository = new ProductRepository();
            List<Product> productList = repository.GetProducts();

            foreach (Product product in productList)
            {
                products.Add(product);
            }
            return products;
        }

        public Product GetProduct(long id)
        {
            repository = new ProductRepository();
            return repository.GetProduct(id);
        }
    }

}
