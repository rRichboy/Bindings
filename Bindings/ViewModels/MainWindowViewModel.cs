using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Interactivity;
using Bindings.Models;

namespace Bindings.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; } = new ();

    public ObservableCollection<Product> Cart { get; set; } = new ();
    
    private int _totalPrice;

    public int TotalPrice
    {
        get { return _totalPrice; }
        set { _totalPrice = value; }
    }

    private void UpdateTotalPrice()
    {
        TotalPrice = Cart.Sum(product => product.Price * product.Count);
    }

    public void UpdateTotalPriceOnCartChanged()
    {
        Cart.CollectionChanged += (sender, e) =>
        {
            UpdateTotalPrice();
        };
    }
}