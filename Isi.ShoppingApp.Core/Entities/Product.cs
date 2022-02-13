﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isi.ShoppingApp.Core.Entities
{
    public class Product
    {
        public long Id { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        private decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal? PercentageDiscount { get; set; }

        public Product(long id, string name, string category, string description, decimal price, int quantity , decimal? percentageDiscount)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
            PercentageDiscount = percentageDiscount;
        }

        public Product(string name, string category, string description, decimal price, int quantity ,decimal? percentageDiscount)
            :this(0,name,category,description,price,quantity,percentageDiscount)
        {}

        public bool IsAvailable()
        {
            return Quantity > 0;
        }
        private decimal GetDiscountForFinalPrice()
        {
            decimal toReturn = PercentageDiscount ?? 0m;
            if (toReturn > 0)
                toReturn /= 100;
            return toReturn;
        }

        public decimal FinalPrice()
        {
            return Price - (GetDiscountForFinalPrice() * Price);
        }

        public override string ToString()
        {
            string discount = PercentageDiscount.ToString()??"0";
            return $"{Id}_{Name}_{Category}_${Price} - {discount}%"; 
        }

    }
}
