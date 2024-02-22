using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Bindings.Models;

namespace Bindings.Views;

public partial class Window1 : Window
{
    private Product _product;
    public Window1(Product product)
    {
        _product = product;
        InitializeComponent();
        nameP.Text = _product.Name;
        priceP.Text = _product.Price;
        countP.Text = _product.Count;
    }
    
    
    
    
    
}