using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
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

            _summa = this.FindControl<TextBlock>("summa");

            UpdateTotalPrice();

            SubscribeToProductsChanges();

            var backButton = this.FindControl<Button>("BackButton");

            backButton.Click += OnBackButtonClick;
        }

        private void SubscribeToProductsChanges()
        {
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.Products.CollectionChanged += (sender, args) => { UpdateTotalPrice(); };
            }
        }

        private void UpdateTotalPrice()
        {
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                var totalPrice = viewModel.Products.Sum(product => product.Price * product.Count);
                _summa.Text = $"Total Price: {totalPrice}";
            }
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}