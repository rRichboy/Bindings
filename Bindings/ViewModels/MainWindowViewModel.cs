using System.Collections.ObjectModel;
using Avalonia.Interactivity;
using Bindings.Models;

namespace Bindings.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Product> Products { get; set; } = new ();

}