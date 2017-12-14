using Microsoft.VisualBasic.FileIO;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace CSVReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "(*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (TextFieldParser parser = new TextFieldParser(openFileDialog.FileName))
                {
                    lblTitle.Content = openFileDialog.FileName;
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        foreach (string field in fields)
                        {
                            text.Append(field + ",");
                        }

                        text.Append('\n');
                    }

                    txtReader.Text = text.ToString();
                }
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "(*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, text.ToString());
            }
        }
        private void btnToUpper_Click(object sender, RoutedEventArgs e)
        {
            text.Replace(txtToUpper.Text, txtToUpper.Text.ToUpper());
            txtReader.Text = text.ToString();
        }

        StringBuilder text = new StringBuilder(128);
    }
}