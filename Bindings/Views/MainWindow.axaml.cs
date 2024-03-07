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
            if (string.IsNullOrWhiteSpace(nm.Text) || string.IsNullOrWhiteSpace(pr.Text) || string.IsNullOrWhiteSpace(ct.Text))
            {
                Error.Text = "Заполните все поля";
                return;
            }

            if (!IsNumeric(pr.Text) || !IsNumeric(ct.Text))
            {
                Error.Text = "В поля Price и Count введите цифры";
                return;
            }

            var newProduct = new Product
            {
                Name = nm.Text,
                Price = int.Parse(pr.Text),
                Count = int.Parse(ct.Text)
            };

            (DataContext as MainWindowViewModel)?.Products.Add(newProduct);

            nm.Text = string.Empty;
            pr.Text = string.Empty;
            ct.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
        
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;

            if (viewModel != null && viewModel.Products.Count > 0 && viewModel.Cart.Count > 0)
            {
                Window1 window1 = new Window1(DataContext);
                window1.Show();
            }
            else
            {
                Error.Text = "Выберите продукты перед открытием корзины.";
            }
        }
    }
}