using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Interactivity;
using Bindings.Models;

namespace Bindings.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; } = new ();

    public ObservableCollection<Product> Cart { get; set; } = new ();
}