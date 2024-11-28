using System.Collections.ObjectModel;

namespace QualMeuImposto.Mobile;

/// <summary>
/// Página principal do aplicativo, onde o usuário pode adicionar produtos à lista e visualizar os totais.
/// </summary>
public partial class HomePage : ContentPage
{
    /// <summary>
    /// Lista observável para armazenar os produtos adicionados pelo usuário.
    /// </summary>
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    /// <summary>
    /// Subtotal dos produtos na lista.
    /// </summary>
    public decimal Subtotal => Products.Sum(p => p.Price);

    /// <summary>
    /// Total de impostos calculados com base na porcentagem configurada.
    /// </summary>
    public decimal Taxes => Subtotal * (TaxRate / 100);

    /// <summary>
    /// Total geral em dólar americano.
    /// </summary>
    public decimal TotalUSD => Subtotal + Taxes;

    /// <summary>
    /// Total geral convertido em reais.
    /// </summary>
    public decimal TotalBRL => TotalUSD * DollarRate;

    /// <summary>
    /// Taxa do dólar (atualizada via Configurações).
    /// </summary>
    public static decimal DollarRate { get; set; } = 5.80m;

    /// <summary>
    /// Taxa de imposto em porcentagem (atualizada via Configurações).
    /// </summary>
    public static decimal TaxRate { get; set; } = 13m;

    public HomePage()
    {
        InitializeComponent();
        BindingContext = this;
        ProductsList.ItemsSource = Products;
    }

    /// <summary>
    /// Evento disparado ao clicar no botão "Adicionar Produto".
    /// </summary>
    private void OnAddProductClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(ProductPriceEntry.Text, out var price) && !string.IsNullOrWhiteSpace(ProductNameEntry.Text))
        {
            Products.Add(new Product
            {
                Name = ProductNameEntry.Text,
                Price = price
            });

            // Limpar os campos após adicionar
            ProductNameEntry.Text = string.Empty;
            ProductPriceEntry.Text = string.Empty;

            // Atualizar os bindings
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Taxes));
            OnPropertyChanged(nameof(TotalUSD));
            OnPropertyChanged(nameof(TotalBRL));
        }
        else
        {
            DisplayAlert("Erro", "Insira um nome e um preço válido para o produto.", "OK");
        }
    }

    /// <summary>
    /// Evento disparado ao remover um produto da lista (swipe).
    /// </summary>
    private void OnRemoveProduct(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        if (swipeItem?.BindingContext is Product product)
        {
            Products.Remove(product);

            // Atualizar os bindings
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Taxes));
            OnPropertyChanged(nameof(TotalUSD));
            OnPropertyChanged(nameof(TotalBRL));
        }
    }
}

/// <summary>
/// Representa um produto na lista.
/// </summary>
public class Product
{
    /// <summary>
    /// Nome do produto.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Preço do produto em dólar americano.
    /// </summary>
    public decimal Price { get; set; }
}