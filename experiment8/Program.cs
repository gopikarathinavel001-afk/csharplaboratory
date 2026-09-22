using System;
using System.Drawing;
using System.Windows.Forms;

class TemperatureForm : Form
{
    Label titleLabel;
    Label valueLabel;
    Label resultLabel;

    TextBox valueTextBox;

    ComboBox conversionComboBox;

    Button convertButton;
    Button clearButton;

    Panel resultPanel;

    public TemperatureForm()
    {
        Text = "Temperature Converter";
        Size = new Size(550, 450);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.AliceBlue;

        titleLabel = new Label();
        titleLabel.Text = "TEMPERATURE CONVERTER";
        titleLabel.Location = new Point(145, 35);
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Arial", 16, FontStyle.Bold);

        valueLabel = new Label();
        valueLabel.Text = "Enter Temperature:";
        valueLabel.Location = new Point(70, 110);
        valueLabel.AutoSize = true;

        valueTextBox = new TextBox();
        valueTextBox.Location = new Point(230, 105);
        valueTextBox.Width = 200;

        conversionComboBox = new ComboBox();
        conversionComboBox.Location = new Point(230, 155);
        conversionComboBox.Width = 200;
        conversionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        conversionComboBox.Items.Add("Celsius to Fahrenheit");
        conversionComboBox.Items.Add("Fahrenheit to Celsius");

        convertButton = new Button();
        convertButton.Text = "Convert";
        convertButton.Location = new Point(170, 210);
        convertButton.Size = new Size(100, 40);
        convertButton.BackColor = Color.LightGreen;
        convertButton.Click += ConvertButton_Click;

        clearButton = new Button();
        clearButton.Text = "Clear";
        clearButton.Location = new Point(280, 210);
        clearButton.Size = new Size(100, 40);
        clearButton.Click += ClearButton_Click;

        resultPanel = new Panel();
        resultPanel.Location = new Point(100, 280);
        resultPanel.Size = new Size(340, 70);
        resultPanel.BackColor = Color.White;
        resultPanel.BorderStyle = BorderStyle.FixedSingle;

        resultLabel = new Label();
        resultLabel.Text = "Result:";
        resultLabel.Location = new Point(20, 20);
        resultLabel.AutoSize = true;
        resultLabel.Font = new Font("Arial", 12, FontStyle.Bold);

        resultPanel.Controls.Add(resultLabel);

        Controls.Add(titleLabel);
        Controls.Add(valueLabel);
        Controls.Add(valueTextBox);
        Controls.Add(conversionComboBox);
        Controls.Add(convertButton);
        Controls.Add(clearButton);
        Controls.Add(resultPanel);
    }

    private void ConvertButton_Click(object? sender, EventArgs e)
    {
        if (!double.TryParse(valueTextBox.Text, out double value))
        {
            resultLabel.Text = "Enter a valid temperature.";
            return;
        }

        if (conversionComboBox.Text == "Celsius to Fahrenheit")
        {
            double result = (value * 9 / 5) + 32;
            resultLabel.Text = "Result: " + result + " °F";
        }
        else if (conversionComboBox.Text == "Fahrenheit to Celsius")
        {
            double result = (value - 32) * 5 / 9;
            resultLabel.Text = "Result: " + result + " °C";
        }
        else
        {
            resultLabel.Text = "Select a conversion type.";
        }
    }

    private void ClearButton_Click(object? sender, EventArgs e)
    {
        valueTextBox.Clear();
        conversionComboBox.SelectedIndex = -1;
        resultLabel.Text = "Result:";
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TemperatureForm());
    }
}