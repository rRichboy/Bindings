using System.Linq;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views
{
    public partial class MainWindow : Window
    {
        private Bitmap _imagePath;
        private ComboBox сomboBox;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;

            if (viewModel != null && viewModel.Products.Count > 0 && viewModel.SelectedProducts.Count > 0)
            {
                var mainWindow = this;

                foreach (var product in viewModel.SelectedProducts)
                {
                    if (!viewModel.Cart.Any(p => p.Name == product.Name))
                    {
                        var cartProduct = new Product
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Count = 1,
                            ImagePath = product.ImagePath 
                        };

                        viewModel.Cart.Add(cartProduct);
                    }
                    else
                    {
                        Error.Text = $"Продукт '{product.Name}' уже присутствует в корзине.";
                    }
                }

                Window1 window1 = new Window1(DataContext);

                window1.Closed += (s, args) => { mainWindow.Show(); };

                mainWindow.Hide();

                window1.Show();
            }
            else
            {
                Error.Text = "Выберите продукты перед открытием корзины.";
            }
        }
        
        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = Prod.SelectedItems.OfType<Product>().ToList();

            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                foreach (var selectedItem in selectedItems)
                {
                    viewModel.Products.Remove(selectedItem);

                    for (int i = viewModel.Cart.Count - 1; i >= 0; i--)
                    {
                        if (viewModel.Cart[i].Name == selectedItem.Name)
                        {
                            viewModel.Cart.RemoveAt(i);
                        }
                    }
                }
            }
        }
        
        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)Prod.SelectedItem;

            if (selectedProduct != null)
            {
                var dialog = new EditProducts((MainWindowViewModel)DataContext, this, selectedProduct);
                dialog.SetProductFields(selectedProduct);
                dialog.ShowDialog(this);
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new AddProducts((MainWindowViewModel)DataContext);
            dialog.ShowDialog(this);
        }
        
        private void OpenCartButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;

            if (viewModel != null && viewModel.Cart.Count > 0)
            {
                var mainWindow = this;

                Window1 window1 = new Window1(DataContext);

                window1.Closed += (s, args) => { mainWindow.Show(); };

                mainWindow.Hide();

                window1.Show();
            }
        }
        
        private void SearchTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel; 
            if (viewModel != null)
            {
                viewModel.SearchTextBox(Search.Text);
            }
        }
        
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                string sortBy = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                switch (sortBy)
                {
                    case "Дешевле":
                        Prod.ItemsSource = ((MainWindowViewModel)this.DataContext).Products.OrderBy(p => p.Price);
                        break;
                    case "Дороже":
                        Prod.ItemsSource = ((MainWindowViewModel)this.DataContext).Products.OrderByDescending(p => p.Price);
                        break;
                    case "От А до Я":
                        Prod.ItemsSource = ((MainWindowViewModel)this.DataContext).Products.OrderBy(p => p.Name);
                        break;
                    case "От Я до А":
                        Prod.ItemsSource = ((MainWindowViewModel)this.DataContext).Products.OrderByDescending(p => p.Name);
                        break;        
                }
            }
        }
    }
}