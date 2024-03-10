// EditProducts.axaml.cs

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
        private TextBox _nameTextBox;
        private TextBox _priceTextBox;
        private TextBox _countTextBox;
        private MainWindow _mainWindow;
        private Product _selectedProduct;

        public EditProducts(MainWindowViewModel mainWindowViewModel, MainWindow mainWindow, Product selectedProduct)
        {
            InitializeComponent();

            _nameTextBox = this.FindControl<TextBox>("nm");
            _priceTextBox = this.FindControl<TextBox>("pr");
            _countTextBox = this.FindControl<TextBox>("ct");

            DataContext = mainWindowViewModel;

            _mainWindow = mainWindow;
            _selectedProduct = selectedProduct;

            Closed += OnClosed;
        }

        private void OnClosed(object? sender, EventArgs e)
        {
            _mainWindow.Show();
        }

        private void EditProduct_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _selectedProduct.Name = _nameTextBox.Text;
            _selectedProduct.Price = int.Parse(_priceTextBox.Text);
            _selectedProduct.Count = int.Parse(_countTextBox.Text);
            
            Close();
        }
    }
}