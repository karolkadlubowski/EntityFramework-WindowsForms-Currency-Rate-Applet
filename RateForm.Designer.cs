namespace CryptoMoon
{
    partial class RateForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.currencyDataGriedView = new System.Windows.Forms.DataGridView();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.differenceButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.currencyDataGriedView)).BeginInit();
            this.SuspendLayout();
            // 
            // currencyDataGriedView
            // 
            this.currencyDataGriedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currencyDataGriedView.Location = new System.Drawing.Point(294, 12);
            this.currencyDataGriedView.Name = "currencyDataGriedView";
            this.currencyDataGriedView.RowHeadersWidth = 51;
            this.currencyDataGriedView.RowTemplate.Height = 24;
            this.currencyDataGriedView.Size = new System.Drawing.Size(478, 561);
            this.currencyDataGriedView.TabIndex = 0;
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(13, 13);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(121, 24);
            this.currencyComboBox.TabIndex = 1;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(166, 15);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 22);
            this.amountTextBox.TabIndex = 2;
            this.amountTextBox.Text = "1";
            // 
            // differenceButton
            // 
            this.differenceButton.Location = new System.Drawing.Point(13, 111);
            this.differenceButton.Name = "differenceButton";
            this.differenceButton.Size = new System.Drawing.Size(121, 23);
            this.differenceButton.TabIndex = 3;
            this.differenceButton.Text = "Pokaż różnice";
            this.differenceButton.UseVisualStyleBackColor = true;
            this.differenceButton.Click += new System.EventHandler(this.differenceButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(166, 58);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Odśwież";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // RateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 585);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.differenceButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.currencyDataGriedView);
            this.Name = "RateForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.currencyDataGriedView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView currencyDataGriedView;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button differenceButton;
        private System.Windows.Forms.Button refreshButton;
    }
}

