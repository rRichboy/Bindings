using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Bindings.Models;

namespace Bindings.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> SelectedProducts { get; set; }
    public ObservableCollection<Product> Cart { get; set; }
    
    
    
    public MainWindowViewModel()
    {
        Products = new ObservableCollection<Product>();
        SelectedProducts = new ObservableCollection<Product>();
        Cart = new ObservableCollection<Product>();
    }
    
    public ObservableCollection<Product> SearchTextBox(string searchText)
    {
        var filteredProducts = new ObservableCollection<Product>(
            Products.Where(product => product.Name.Contains(searchText)));

        return filteredProducts;
    }
}