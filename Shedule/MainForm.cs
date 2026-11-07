using Microsoft.VisualBasic;

namespace Schedule;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }
    private void MainForm_Load(object sender, EventArgs e)
    {
        SetValueComboBox();
    }

    private void ConvertButton_Click(object sender, EventArgs e)
    {
        try
        {

            if (monthComboBox.SelectedIndex < 0 || yearComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Proszę wybrać miesiąc i rok");
                return;
            }

            int month = monthComboBox.SelectedIndex + 1;
            int.TryParse(yearComboBox.SelectedItem!.ToString(), out int year);

            List<Item> items = ItemGeneration.GenerateItemFromSchedule(inputRichTextBox.Text, month, year);
            string csv = FileOperation.FormatCSV(items);
            if (FileOperation.SaveFile(csv,month,year))
            {
                MessageBox.Show("Plik CSV został zapisany pomyślnie");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void SetValueComboBox()
    {
        yearComboBox.Items.Add(DateTime.Now.Year.ToString());
        yearComboBox.Items.Add(DateTime.Now.AddYears(1).Year.ToString());
        yearComboBox.SelectedIndex = 0;
        monthComboBox.SelectedIndex = DateTime.Now.Month - 1;
        depotComboBox.SelectedItem = Properties.Settings.Default.depot;
    }

    private void DepotComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.depot = depotComboBox.SelectedItem!.ToString();
        Properties.Settings.Default.Save();
    }
}
