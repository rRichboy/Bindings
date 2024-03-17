using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views
{
    public partial class EditProducts : Window
    {
        private TextBox nameTextBox;
        private TextBox priceTextBox;
        private TextBox countTextBox;
        private MainWindow _mainWindow;
        private Product _selectedProduct;

        public EditProducts(MainWindowViewModel viewModel, MainWindow mainWindow, Product selectedProduct)
        {
            InitializeComponent();
            
            nameTextBox = nm;
            priceTextBox = pr;
            countTextBox = ct;
            _mainWindow = mainWindow;
            _selectedProduct = selectedProduct;
            DataContext = viewModel;
            
            Closed += OnClosed;
        }

        private void OnClosed(object? sender, EventArgs e)
        {
            _mainWindow.DataContext = null;
            _mainWindow.DataContext = DataContext;
            _mainWindow.Show();
        }

        private void EditProduct_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (_selectedProduct != null)
            {
                _selectedProduct.Name = nameTextBox.Text;
                _selectedProduct.Price = int.Parse(priceTextBox.Text);
                _selectedProduct.Count = int.Parse(countTextBox.Text);
                Close();
            }
        }
    }
}