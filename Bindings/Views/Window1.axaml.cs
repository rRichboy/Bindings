using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views;

public partial class Window1 : Window
{
    public Window1(object dataContext)
    {
        InitializeComponent();
        DataContext = dataContext;
        
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.UpdateTotalPriceOnCartChanged();
        }
    }
}