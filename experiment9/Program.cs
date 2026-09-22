using System;
using System.Drawing;
using System.Windows.Forms;

class EmployeeDialog : Form
{
    TextBox nameBox;
    TextBox idBox;
    ComboBox departmentBox;
    Button saveButton;
    Button cancelButton;

    public EmployeeDialog()
    {
        Text = "Employee Details";
        Size = new Size(400, 300);
        StartPosition = FormStartPosition.CenterParent;

        Label title = new Label();
        title.Text = "EMPLOYEE DETAILS";
        title.Location = new Point(120, 20);
        title.AutoSize = true;
        title.Font = new Font("Arial", 14, FontStyle.Bold);

        Label idLabel = new Label();
        idLabel.Text = "Employee ID:";
        idLabel.Location = new Point(40, 70);
        idLabel.AutoSize = true;

        idBox = new TextBox();
        idBox.Location = new Point(150, 65);
        idBox.Width = 180;

        Label nameLabel = new Label();
        nameLabel.Text = "Employee Name:";
        nameLabel.Location = new Point(40, 110);
        nameLabel.AutoSize = true;

        nameBox = new TextBox();
        nameBox.Location = new Point(150, 105);
        nameBox.Width = 180;

        Label departmentLabel = new Label();
        departmentLabel.Text = "Department:";
        departmentLabel.Location = new Point(40, 150);
        departmentLabel.AutoSize = true;

        departmentBox = new ComboBox();
        departmentBox.Location = new Point(150, 145);
        departmentBox.Width = 180;
        departmentBox.DropDownStyle = ComboBoxStyle.DropDownList;

        departmentBox.Items.Add("IT");
        departmentBox.Items.Add("CSE");
        departmentBox.Items.Add("ECE");
        departmentBox.Items.Add("EEE");

        saveButton = new Button();
        saveButton.Text = "Save";
        saveButton.Location = new Point(100, 200);
        saveButton.Size = new Size(80, 30);

        cancelButton = new Button();
        cancelButton.Text = "Cancel";
        cancelButton.Location = new Point(200, 200);
        cancelButton.Size = new Size(80, 30);

        saveButton.Click += SaveButton_Click;
        cancelButton.Click += (sender, e) => Close();

        Controls.Add(title);
        Controls.Add(idLabel);
        Controls.Add(idBox);
        Controls.Add(nameLabel);
        Controls.Add(nameBox);
        Controls.Add(departmentLabel);
        Controls.Add(departmentBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "Employee Saved Successfully!\n\n" +
            "ID: " + idBox.Text + "\n" +
            "Name: " + nameBox.Text + "\n" +
            "Department: " + departmentBox.Text,
            "Employee Details");

        Close();
    }
}

class EmployeeForm : Form
{
    public EmployeeForm()
    {
        Text = "Employee Window";
        Size = new Size(500, 350);

        Label label = new Label();
        label.Text = "Employee Management";
        label.Location = new Point(150, 120);
        label.AutoSize = true;
        label.Font = new Font("Arial", 16, FontStyle.Bold);

        Controls.Add(label);
    }
}

class AboutForm : Form
{
    public AboutForm()
    {
        Text = "About Application";
        Size = new Size(400, 250);

        Label label = new Label();
        label.Text = "Employee Management System\n\nC# Windows Forms Application";
        label.Location = new Point(70, 70);
        label.AutoSize = true;
        label.Font = new Font("Arial", 12, FontStyle.Regular);

        Controls.Add(label);
    }
}

class MainForm : Form
{
    MenuStrip menuStrip;

    public MainForm()
    {
        Text = "Employee Management System";
        IsMdiContainer = true;
        WindowState = FormWindowState.Maximized;

        menuStrip = new MenuStrip();

        ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");

        ToolStripMenuItem employeeMenu =
            new ToolStripMenuItem("New Employee");

        ToolStripMenuItem aboutMenu =
            new ToolStripMenuItem("About");

        ToolStripMenuItem exitMenu =
            new ToolStripMenuItem("Exit");

        employeeMenu.Click += (sender, e) =>
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.MdiParent = this;
            employeeForm.Show();
        };

        aboutMenu.Click += (sender, e) =>
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.MdiParent = this;
            aboutForm.Show();
        };

        exitMenu.Click += (sender, e) =>
        {
            Close();
        };

        fileMenu.DropDownItems.Add(employeeMenu);
        fileMenu.DropDownItems.Add(aboutMenu);
        fileMenu.DropDownItems.Add(exitMenu);

        ToolStripMenuItem windowMenu =
            new ToolStripMenuItem("Window");

        ToolStripMenuItem cascadeMenu =
            new ToolStripMenuItem("Cascade");

        ToolStripMenuItem horizontalMenu =
            new ToolStripMenuItem("Tile Horizontal");

        ToolStripMenuItem verticalMenu =
            new ToolStripMenuItem("Tile Vertical");

        cascadeMenu.Click += (sender, e) =>
        {
            LayoutMdi(MdiLayout.Cascade);
        };

        horizontalMenu.Click += (sender, e) =>
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        };

        verticalMenu.Click += (sender, e) =>
        {
            LayoutMdi(MdiLayout.TileVertical);
        };

        windowMenu.DropDownItems.Add(cascadeMenu);
        windowMenu.DropDownItems.Add(horizontalMenu);
        windowMenu.DropDownItems.Add(verticalMenu);

        menuStrip.Items.Add(fileMenu);
        menuStrip.Items.Add(windowMenu);

        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;

        Shown += MainForm_Shown;
    }

    private void MainForm_Shown(object? sender, EventArgs e)
    {
        EmployeeDialog dialog = new EmployeeDialog();

        if (dialog.ShowDialog(this) == DialogResult.None)
        {
            // Custom dialog is displayed when application starts.
        }
    }
}

class Program
{
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}