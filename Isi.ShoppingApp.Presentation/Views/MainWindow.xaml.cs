﻿using System;
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

<<<<<<< HEAD:Isi.ShoppingApp.Presentation/Views/MainWindow.xaml.cs
using Isi.ShoppingApp.Domain.Services;
using Isi.ShoppingApp.Presentation.ViewModels;

=======
>>>>>>> 8d63b377c906e6a7e38c20f2269a4b798258d22f:Isi.ShoppingApp.Presentation/Views/SignUpView.xaml.cs
namespace Isi.ShoppingApp.Presentation.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
            Controller controller = new Controller();
            DataContext = controller;
        }
    }
}
