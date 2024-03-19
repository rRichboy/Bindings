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
        // Ваш код для создания нового продукта
        var newProduct = new Product
        {
            Name = nm.Text,
            Price = int.Parse(pr.Text),
            Count = int.Parse(ct.Text)
        };

        // Добавление нового продукта в список Products через экземпляр MainWindowViewModel
        viewModel.Products.Add(newProduct);

        // Очистка полей и закрытие окна
        nm.Text = string.Empty;
        pr.Text = string.Empty;
        ct.Text = string.Empty;
        this.Close();
    }
}