using CryptoMoon.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMoon
{
    public partial class RateForm : Form
    {
        private PanelService panelService { get; set; } = new PanelService();
        private INavigationService navigationService { get; set; } = new NavigationService();

        private EuroService euroService { get; set; } = new EuroService();

        public RateForm()
        {
            InitializeComponent();
            currencyComboBox.Items.AddRange(CurrencyConverterService.GetCurrencyTags());
            currencyComboBox.Text = currencyComboBox.Items[0].ToString();
            currencyDataGriedView.DataSource = euroService.EuroCurrencyRates;
            amountTextBox.GotFocus += (a, eve) => panelService.RemoveText(amountTextBox);
            amountTextBox.LostFocus += (a, eve) => panelService.AddText(amountTextBox, "1");
        }

        public RateForm(EuroService euroService)
        {
            this.euroService = euroService;
            InitializeComponent();
            currencyComboBox.Items.AddRange(CurrencyConverterService.GetCurrencyTags());
            currencyComboBox.Text = currencyComboBox.Items[euroService.CurrentDataGriedCurrencyIndex].ToString();
            amountTextBox.Text = euroService.CurrentDataGriedAmount.ToString();
            currencyDataGriedView.DataSource = euroService.DataGriedCurrentCurrencyRates;
            amountTextBox.GotFocus += (a, eve) => panelService.RemoveText(amountTextBox);
            amountTextBox.LostFocus += (a, eve) => panelService.AddText(amountTextBox, "1");
        }

        private void differenceButton_Click(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            euroService.CurrentDataGriedAmount = float.Parse(amountTextBox.Text);
            euroService.CurrentDataGriedCurrencyIndex = currencyComboBox.SelectedIndex;
            euroService.DataGriedCurrentCurrencyRates = euroService.GetCurrencyRates(currencyComboBox.Text,float.Parse(amountTextBox.Text));
            navigationService.Navigate<RateForm, RateForm>(this, typeof(RateForm),euroService, true);
        }
    }
}
