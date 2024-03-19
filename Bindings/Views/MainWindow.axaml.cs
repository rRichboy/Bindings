using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;

            if (viewModel != null && viewModel.Products.Count > 0 && viewModel.Cart.Count > 0)
            {
                var mainWindow = this;

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
        
        private void DeleteButton_OnClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedItems = Prod.SelectedItems.OfType<Product>().ToList();
            

            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                foreach (var selectedItem in selectedItems)
                {
                    viewModel.Products.Remove(selectedItem);
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

    }
}