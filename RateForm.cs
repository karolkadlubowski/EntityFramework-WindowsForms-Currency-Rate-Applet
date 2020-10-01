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

        public RateForm()
        {
            InitializeComponent();
            //var panelService = new PanelService();
            
            currencyComboBox.Items.AddRange(CurrencyConverterService.GetCurrencyTags());
            currencyComboBox.Text = currencyComboBox.Items[0].ToString();
            var es = new EuroService(currencyComboBox.Text,float.Parse(amountTextBox.Text));
            currencyDataGriedView.DataSource = es.CurrencyRates;
            amountTextBox.GotFocus += (a, eve) => panelService.RemoveText(amountTextBox);
            amountTextBox.LostFocus += (a, eve) => panelService.AddText(amountTextBox, "1");
            //amountTextBox.TextChanged += (a, eve) => es.MultiplyValue(currencyDataGriedView, float.Parse(amountTextBox.Text));
        }

        private void differenceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
