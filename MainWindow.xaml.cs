using System.Windows;

namespace MunicipalAppProgPoe
{
    public partial class MainWindow : Window
    {
        public int IssueCounter { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            UpdateIssueCounter();
        }

        private void UpdateIssueCounter()
        {
            Title = $"MainWindow - Issues Reported: {IssueCounter}";

            lblIssueCounter.Content = $"Total Issues Reported: {IssueCounter}";
        }

        public void IncrementIssueCounter()
        {
            IssueCounter++;
            UpdateIssueCounter();
        }

        private void BtnReportIssue( object sender, RoutedEventArgs e )
        {
            MainFrame.Navigate(new ReportIssue(this));
            MainContent.Visibility = Visibility.Hidden;
        }

        public void ShowMainContent()
        {
            MainContent.Visibility = Visibility.Visible;
        }

        public void ClearMainFrame()
        {
            MainFrame.Content = null;
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            MainFrame.Navigate(new EventsAnnouncements());
            MainContent.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            MainFrame.Navigate(new ServiceRequest());
            MainContent.Visibility = Visibility.Hidden;
        }
    }
}
