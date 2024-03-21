using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Bindings.Models;
using Bindings.ViewModels;

namespace Bindings.Views;

public partial class AddProducts : Window
{
    private MainWindowViewModel viewModel;

    public AddProducts(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var newProduct = new Product
        {
            Name = nm.Text,
            Price = int.Parse(pr.Text),
            Count = int.Parse(ct.Text)
        };

        if (viewModel.Products.Any(p => p.Name == newProduct.Name))
        {
            Error.Text = $"Товар с именем '{newProduct.Name}' уже существует.";
            return; 
        }

        viewModel.Products.Add(newProduct);
    
        nm.Text = string.Empty;
        pr.Text = string.Empty;
        ct.Text = string.Empty;
        this.Close();
    }
}   