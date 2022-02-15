using Isi.ShoppingApp.Core.Entities;
using Isi.ShoppingApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isi.ShoppingApp.Presentation.ViewModels
{
    class Controller
    {
        public ObservableCollection<Product> Products 
        {
            get => Inventory.GetDBProducts();
        }

       public ObservableCollection<string> Items { get; set; }

        public Controller()
        {
            
        }
    }
}
