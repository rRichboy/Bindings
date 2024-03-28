using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
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
        private Bitmap _imagePath;
        private MainWindowViewModel viewModel;



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
                _selectedProduct.ImagePath = _imagePath;

                Close();
            }
        }

        public void SetProductFields(Product selectedProduct)
        {
            nameTextBox.Text = selectedProduct.Name;
            priceTextBox.Text = selectedProduct.Price.ToString();
            countTextBox.Text = selectedProduct.Count.ToString();
            _imagePath = selectedProduct.ImagePath;
        }
        
        private async void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                AllowMultiple = false,
                Title = "Выберите изображение",
                Directory = "C:\\Users\\glkho\\RiderProjects\\Bindings\\Bindings\\Assets",
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Images", Extensions = { "jpg", "png", "jpeg", "ico" } }
                }
            };

            var result = await fileDialog.ShowAsync(this);

            if (result != null && result.Length > 0)
            {
                var imagePath= result[0];
                var bitmap = new Bitmap(imagePath);
                _imagePath = bitmap;
            }
        }
    }
}