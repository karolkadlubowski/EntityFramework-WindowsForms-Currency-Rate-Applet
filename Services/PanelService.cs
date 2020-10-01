using System.Windows.Forms;

namespace CryptoMoon.Services
{
    public class PanelService
    {
        public void RemoveText(TextBox textBox)
        {
            textBox.Text = "";
        }

        public void AddText(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = placeholder;
        }
    }
}
