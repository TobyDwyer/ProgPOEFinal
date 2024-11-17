using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MunicipalAppProgPoe
{
    public partial class ReportIssue : Page
    {
        private int progress = 0;
        private readonly MainWindow _mainWindow;
        private List<string> attachedFilePaths = new List<string>();
        private bool flag = false;


        public ReportIssue( MainWindow mainWindow )
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            // Add categories
            cmbCategory.Items.Add("Road Maintenance");
            cmbCategory.Items.Add("Water Supply");
            cmbCategory.Items.Add("Electricity Outage");
            cmbCategory.Items.Add("Waste Collection");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedItem = null;

            txtLocation.TextChanged += ( s, e ) => UpdateProgressBar();
            cmbCategory.SelectionChanged += ( s, e ) => UpdateProgressBar();
            rtbDescription.TextChanged += ( s, e ) => UpdateProgressBar();

            UpdateProgressBar();
        }

        private void btnAttachMedia( object sender, RoutedEventArgs e )
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                attachedFilePaths.Add(filePath);
                AttachedMedia.Text += fileName + Environment.NewLine;
                UpdateProgressBar();
                MessageBox.Show("Added File: " + filePath);
            }
        }

        private void btnSubmit( object sender, RoutedEventArgs e )
        {
            string location = txtLocation.Text;
            string? category = cmbCategory.SelectedItem?.ToString();
            string description = GetRichTextBoxContent(rtbDescription).Trim();

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description) || attachedFilePaths.Count == 0)
            {
                MessageBox.Show("Please fill in all required fields!");
                return;
            }


            Issue issue = new Issue(location, category, description, attachedFilePaths);
            IssueManager.AddIssue(issue);

            _mainWindow.IncrementIssueCounter();

            MessageBox.Show("Issue Submitted!");

            ClearFields();
            UpdateProgressBar();

            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.ClearMainFrame();
                mainWindow.ShowMainContent();
            }
        }


        private string GetRichTextBoxContent( RichTextBox rtb )
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text.Trim();
        }


        private void UpdateProgressBar()
        {
            progress = 0;

            if (!string.IsNullOrEmpty(txtLocation.Text)) progress++;
            if (cmbCategory.SelectedItem != null) progress++;
            if (!string.IsNullOrWhiteSpace(GetRichTextBoxContent(rtbDescription))) progress++;
            if (attachedFilePaths.Count > 0) progress++;

            progressBar.Value = progress;

        }

        private void ClearFields()
        {
            txtLocation.Text = "";
            cmbCategory.SelectedItem = null;
            rtbDescription.Document.Blocks.Clear();
            AttachedMedia.Text = "";
            attachedFilePaths.Clear();
        }

        private void btnBack( object sender, RoutedEventArgs e )
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }

            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.ClearMainFrame();
                mainWindow.ShowMainContent();
            }
        }
    }
}
