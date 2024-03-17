using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views
{
    public partial class Window1 : Window
    {
        private TextBlock _summa;

        public Window1(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
            _summa = summa;

            Update();

            ProductsChanges();

            var backButton = BackButton;

            backButton.Click += OnBackButtonClick;
        }

        private void ProductsChanges()
        {
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.Products.CollectionChanged += (sender, args) => { Update(); };
            }
        }

        private void Update()
        {
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                var totalPrice = viewModel.Products.Sum(product => product.Price * product.Count);
                _summa.Text = $"Общая сумма: {totalPrice}";
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
        
        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}