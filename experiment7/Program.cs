using System;
using System.Drawing;
using System.Windows.Forms;

class LibraryForm : Form
{
    Label titleLabel;
    Label bookLabel;
    Label memberLabel;
    Label typeLabel;

    TextBox bookTextBox;
    TextBox memberTextBox;

    RadioButton studentRadio;
    RadioButton facultyRadio;

    ComboBox categoryComboBox;

    CheckBox issueCheckBox;
    CheckBox returnCheckBox;

    Button submitButton;
    Label resultLabel;

    public LibraryForm()
    {
        Text = "Library Registration";
        Size = new Size(550, 550);
        StartPosition = FormStartPosition.CenterScreen;

        titleLabel = new Label();
        titleLabel.Text = "LIBRARY REGISTRATION";
        titleLabel.Location = new Point(160, 30);
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Arial", 16, FontStyle.Bold);

        memberLabel = new Label();
        memberLabel.Text = "Member Name:";
        memberLabel.Location = new Point(50, 90);
        memberLabel.AutoSize = true;

        memberTextBox = new TextBox();
        memberTextBox.Location = new Point(190, 85);
        memberTextBox.Width = 230;

        bookLabel = new Label();
        bookLabel.Text = "Book Name:";
        bookLabel.Location = new Point(50, 140);
        bookLabel.AutoSize = true;

        bookTextBox = new TextBox();
        bookTextBox.Location = new Point(190, 135);
        bookTextBox.Width = 230;

        typeLabel = new Label();
        typeLabel.Text = "Member Type:";
        typeLabel.Location = new Point(50, 195);
        typeLabel.AutoSize = true;

        studentRadio = new RadioButton();
        studentRadio.Text = "Student";
        studentRadio.Location = new Point(190, 190);
        studentRadio.AutoSize = true;

        facultyRadio = new RadioButton();
        facultyRadio.Text = "Faculty";
        facultyRadio.Location = new Point(280, 190);
        facultyRadio.AutoSize = true;

        categoryComboBox = new ComboBox();
        categoryComboBox.Location = new Point(190, 235);
        categoryComboBox.Width = 230;
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        categoryComboBox.Items.Add("Programming");
        categoryComboBox.Items.Add("Database");
        categoryComboBox.Items.Add("Networking");
        categoryComboBox.Items.Add("Artificial Intelligence");

        issueCheckBox = new CheckBox();
        issueCheckBox.Text = "Issue Book";
        issueCheckBox.Location = new Point(190, 280);
        issueCheckBox.AutoSize = true;

        returnCheckBox = new CheckBox();
        returnCheckBox.Text = "Return Book";
        returnCheckBox.Location = new Point(290, 280);
        returnCheckBox.AutoSize = true;

        submitButton = new Button();
        submitButton.Text = "Submit";
        submitButton.Location = new Point(190, 330);
        submitButton.Size = new Size(100, 35);

        submitButton.Click += SubmitButton_Click;

        resultLabel = new Label();
        resultLabel.Location = new Point(50, 390);
        resultLabel.AutoSize = true;

        Controls.Add(titleLabel);
        Controls.Add(memberLabel);
        Controls.Add(memberTextBox);
        Controls.Add(bookLabel);
        Controls.Add(bookTextBox);
        Controls.Add(typeLabel);
        Controls.Add(studentRadio);
        Controls.Add(facultyRadio);
        Controls.Add(categoryComboBox);
        Controls.Add(issueCheckBox);
        Controls.Add(returnCheckBox);
        Controls.Add(submitButton);
        Controls.Add(resultLabel);
    }

    private void SubmitButton_Click(object? sender, EventArgs e)
    {
        string memberType;

        if (studentRadio.Checked)
            memberType = "Student";
        else if (facultyRadio.Checked)
            memberType = "Faculty";
        else
            memberType = "Not Selected";

        string category = categoryComboBox.Text;

        string activity = "";

        if (issueCheckBox.Checked)
            activity += "Issue Book ";

        if (returnCheckBox.Checked)
            activity += "Return Book";

        if (activity == "")
            activity = "None";

        resultLabel.Text =
            "--- Library Details ---\n" +
            "Member : " + memberTextBox.Text + "\n" +
            "Book   : " + bookTextBox.Text + "\n" +
            "Type   : " + memberType + "\n" +
            "Category: " + category + "\n" +
            "Activity: " + activity;
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LibraryForm());
    }
}