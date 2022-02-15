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

        public long Id { get; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
            }
        }

        public decimal? PercentageDiscount
        {
            get => percentageDiscount;
            set
            {
                percentageDiscount = value;
            }
        }

        private string name;
        private string category;
        private string description;
        private decimal price;
        private int quantity;
        private decimal? percentageDiscount;



        public Inventory()
        {}

        public static ObservableCollection<Product> GetDBProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            ProductRepository repository = new ProductRepository();
            List<Product> productList = repository.GetProducts();

            foreach (Product product in productList)
            {
                products.Add(product);
            }
            return products;
        }

    }
}
