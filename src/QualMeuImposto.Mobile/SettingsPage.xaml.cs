namespace QualMeuImposto.Mobile;

/// <summary>
/// Página de configurações para alterar a cotação do dólar e a porcentagem de imposto.
/// </summary>
public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        DollarRateEntry.Text = HomePage.DollarRate.ToString();
        TaxRateEntry.Text = HomePage.TaxRate.ToString();
    }

    /// <summary>
    /// Evento disparado ao alterar a cotação do dólar.
    /// </summary>
    private void OnDollarRateChanged(object sender, EventArgs e)
    {
        if (decimal.TryParse(DollarRateEntry.Text, out var rate))
        {
            HomePage.DollarRate = rate;
        }
        else
        {
            DisplayAlert("Erro", "Insira uma cotação válida.", "OK");
            DollarRateEntry.Text = HomePage.DollarRate.ToString();
        }
    }

    /// <summary>
    /// Evento disparado ao alterar a porcentagem de imposto.
    /// </summary>
    private void OnTaxRateChanged(object sender, EventArgs e)
    {
        if (decimal.TryParse(TaxRateEntry.Text, out var rate))
        {
            HomePage.TaxRate = rate;
        }
        else
        {
            DisplayAlert("Erro", "Insira uma porcentagem válida.", "OK");
            TaxRateEntry.Text = HomePage.TaxRate.ToString();
        }
    }
}