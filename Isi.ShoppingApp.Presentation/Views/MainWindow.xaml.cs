using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Isi.ShoppingApp.Presentation;
using Isi.ShoppingApp.Domain.Services;
using Isi.ShoppingApp.Presentation.ViewModels;
using System.Diagnostics;

namespace Isi.ShoppingApp.Presentation.Views
{
    public partial class MainWindow : Window
    {
        Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
            DataContext = controller;
            
        }

        private void OnItemButtonClicked(object sender, RoutedEventArgs e)
        {
            ProductService productService = new ProductService();
            ModifyCartPanelView();
            long ButtonId = (long)(sender as Button).Tag;
            CartPanel.MinWidth = 200;
            Width = Inventory.Width + CartPanel.Width + ShoppingCartDropdown.Width;
            controller.ProductSelected = productService.GetProduct(ButtonId);
        }

        private void ModifyCartPanelView()
        {
            CartPanel.Visibility = Visibility.Visible;
            CartPanel.MaxHeight = 250;
            CartPanel.MinHeight = 200;
            CartPanel.Height = Inventory.Height;
        }

        private void OnUserButtonClicked(object sender, RoutedEventArgs e)
        {
            
            if (!IsUserPanelVisible())
            {
                
                HideShoppingCartPanel();
                UserDropdown.Visibility = Visibility.Visible;
                UserDropdown.Height = 30;
            }

            else
            {
                HideUserPanel();
            }
        }

        private void HideUserPanel()
        {
            UserDropdown.Visibility = Visibility.Hidden;
            UserDropdown.Height = 0;
        }

        private void OnShoppingCartButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!IsShoppingCartVisible())
            {
                ShoppingCartDropdown.Visibility = Visibility.Visible;
                ShoppingCartDropdown.MinWidth = 100;
                HideUserPanel();
            }

            else
            { 
                HideShoppingCartPanel();
            }

            Width = 1000;
        }

        private void HideShoppingCartPanel()
        {
            ShoppingCartDropdown.Visibility = Visibility.Hidden;
            ShoppingCartDropdown.Width = 0;
        }

        private bool IsShoppingCartVisible()
        {
            return ShoppingCartDropdown.Visibility == Visibility.Visible;
        }

        private bool IsUserPanelVisible()
        {
            return UserDropdown.Visibility == Visibility.Visible;
        }
    }
}