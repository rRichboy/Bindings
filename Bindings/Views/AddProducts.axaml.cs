using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Bindings.Models;
using System.IO;
using System.Linq;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Bindings.ViewModels;

namespace Bindings.Views
{
    public partial class AddProducts : Window
    {
        private MainWindowViewModel viewModel;
        private Bitmap _imagePath;

        public AddProducts(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                Name = nm.Text,
                Price = int.Parse(pr.Text),
                Count = int.Parse(ct.Text),
                ImagePath = _imagePath
            };

            if (viewModel.Products.Any(p => p.Name == newProduct.Name))
            {
                Error.Text = $"Товар с именем '{newProduct.Name}' уже существует.";
                return;
            }

            viewModel.Products.Add(newProduct);

            nm.Text = string.Empty;
            pr.Text = string.Empty;
            ct.Text = string.Empty;
            this.Close();
        }
    }
}
