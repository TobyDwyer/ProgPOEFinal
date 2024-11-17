using System.Windows;

namespace MunicipalAppProgPoe
{
    public partial class SearchWindow : Window
    {
        public string? EventName { get; private set; }
        public string? Category { get; private set; }
        public DateTime? EventDate { get; private set; }

        public SearchWindow()
        {
            InitializeComponent();
        }

        // Handle search button click and close the window
        private void BtnSearch_Click( object sender, RoutedEventArgs e )
        {
            EventName = txtEventName.Text;
            Category = txtCategory.Text;
            EventDate = dpEventDate.SelectedDate;

            DialogResult = true;
            Close();
        }
    }
}
