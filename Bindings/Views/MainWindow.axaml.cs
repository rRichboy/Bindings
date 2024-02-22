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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                Name = nm.Text,
                Price = pr.Text,
                Count = ct.Text
            };

            (DataContext as MainWindowViewModel)?.Products.Add( newProduct);

            nm.Text = string.Empty;
            pr.Text = string.Empty;
            ct.Text = string.Empty;
        }
        
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (Prod.SelectedItem != null)
            {
                Product selectedProduct = (Product)Prod.SelectedItem;

                Window1 window1 = new Window1(selectedProduct);
                window1.Show();    
            }
        }
    }
}