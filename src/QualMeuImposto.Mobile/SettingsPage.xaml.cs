namespace QualMeuImposto.Mobile;

/// <summary>
/// P�gina de configura��es para alterar a cota��o do d�lar e a porcentagem de imposto.
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
    /// Evento disparado ao alterar a cota��o do d�lar.
    /// </summary>
    private void OnDollarRateChanged(object sender, EventArgs e)
    {
        if (decimal.TryParse(DollarRateEntry.Text, out var rate))
        {
            HomePage.DollarRate = rate;
        }
        else
        {
            DisplayAlert("Erro", "Insira uma cota��o v�lida.", "OK");
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
            DisplayAlert("Erro", "Insira uma porcentagem v�lida.", "OK");
            TaxRateEntry.Text = HomePage.TaxRate.ToString();
        }
    }
}