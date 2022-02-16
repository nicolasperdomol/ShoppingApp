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

namespace Isi.ShoppingApp.Presentation.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Controller controller = new Controller();
            DataContext = controller;
        }
    }
}