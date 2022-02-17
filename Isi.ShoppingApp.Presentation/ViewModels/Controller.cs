using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Domain.Services;
using Isi.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;



namespace Isi.ShoppingApp.Presentation.ViewModels
{
    public class Controller : Isi.Utility.ViewModels.ViewModel
    {
        public DelegateCommand IncreaseAmountToBuy{ get; }
        public DelegateCommand DecreaseAmountToBuy{ get; }

        public int AmountToBuy 
        {
            get => amountToBuy;
            set
            {
                if(value>0)
                {
                    amountToBuy = value;
                    NotifyPropertyChanged(nameof(AmountToBuy));
                }
            }
        }
        public ObservableCollection<Product> Products
        {
            get => getInitialCollection();
        }

        public Product ProductSelected
        {
            get => productSelected;
            set
            {
                productSelected = value;
                NotifyPropertyChanged(nameof(ProductSelected));
                AmountToBuy = 1;
            }
        }


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
        private int amountToBuy;

        private Product productSelected;
        public string User { get; set; }
       
        public Controller()
        {
            ProductSelected = Products[0];
            IncreaseAmountToBuy = new DelegateCommand(Increment, CanIncrement);
            DecreaseAmountToBuy = new DelegateCommand(Decrement);

            User = "Nicolas Perdomo";
            AmountToBuy = 1;
        }

        public ObservableCollection<Product> getInitialCollection()
        {
            Inventory inventory = new Inventory();
            return inventory.GetDBProducts();
        }


        private void Increment(object _)
        {
            if (CanIncrement(_))
            {
                AmountToBuy++;
            }
        }

        private bool CanIncrement(object _)
        {
            return AmountToBuy < ProductSelected.Quantity & ProductSelected != null;
        }


        private void Decrement(object _)
        {
            AmountToBuy--;
        }
    }

}
