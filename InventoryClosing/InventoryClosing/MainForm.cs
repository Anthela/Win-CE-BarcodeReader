using System.Diagnostics;
using InventoryProcessor = InventoryClosing.Processor.Processor;

namespace InventoryClosing
{
    public partial class MainForm : Form
    {
        private InventoryProcessor? processor;
        public MainForm()
        {
            InitializeComponent();
        }

        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();

            ofd.Filter = "CSV files (*.csv)|*.csv";
            ofd.Title = "Leltár file kiválasztása...";

            if (ofd.ShowDialog() == DialogResult.OK)
                FilePathTextBox.Text = ofd.FileName;
        }

        private void InventoryCloseButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePathTextBox.Text))
            {
                processor = new InventoryProcessor(FilePathTextBox.Text);

                try
                {
                    processor.Process();

                    ErrorLabel.Text = "Sikeres feldolgozás!";
                    ErrorLabel.ForeColor = Color.Green;

                    Button openFolder = new Button();
                    openFolder.Text = "Mappa megnyitása";
                    openFolder.Location = new Point(255, 93);
                    openFolder.Size = new Size(117, 23);
                    openFolder.Click += new EventHandler(OnOpenFolderButtonClick);
                    Controls.Add(openFolder);
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = ex.Message;
                    ErrorLabel.ForeColor = Color.Red;
                }
            }
        }

        private void OnOpenFolderButtonClick(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetDirectoryName(FilePathTextBox.Text),
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
    }
}