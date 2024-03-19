using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Interactivity;
using Bindings.Models;

namespace Bindings.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> Cart { get; set; }
    
    public MainWindowViewModel()
    {
        Products = new ObservableCollection<Product>();
        Cart = new ObservableCollection<Product>();
    }
}
