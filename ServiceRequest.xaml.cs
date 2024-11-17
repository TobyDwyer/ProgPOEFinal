using MunicipalAppProgPoe.Models;
using MunicipalAppProgPoe.Utils;
using System.Windows;
using System.Windows.Controls;

namespace MunicipalAppProgPoe
{
    public partial class ServiceRequest : Page
    {
        private AVLTree avlTree = new AVLTree();
        private Graph serviceGraph = new Graph();

        public ServiceRequest()
        {
            InitializeComponent();
            LoadSampleData();
            BindListView(avlTree.InOrderTraversal());
        }

        private void LoadSampleData()
        {
            avlTree.Insert(new ServiceRequestModel(1, "Fix streetlight", "Pending"));
            avlTree.Insert(new ServiceRequestModel(2, "Water leakage", "In Progress"));
            avlTree.Insert(new ServiceRequestModel(3, "Garbage collection", "Completed"));

            // Example: Creating relationships between service requests in the graph
            serviceGraph.AddEdge(1, 2);
            serviceGraph.AddEdge(2, 3);
        }

        private void BindListView( IEnumerable<ServiceRequestModel> data )
        {
            lvRequest.ItemsSource = data;
        }

        private void BtnSearch_Click( object sender, RoutedEventArgs e )
        {
            if (int.TryParse(txtSearchId.Text, out int id))
            {
                var request = avlTree.Search(id);
                if (request != null)
                {
                    BindListView(new List<ServiceRequestModel> { request });
                }
                else
                {
                    MessageBox.Show("Request not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnViewAll_Click( object sender, RoutedEventArgs e )
        {
            BindListView(avlTree.InOrderTraversal());
        }

        private void BtnAddRequest_Click( object sender, RoutedEventArgs e )
        {
            if (int.TryParse(txtId.Text, out int id) && !string.IsNullOrEmpty(txtDescription.Text) && !string.IsNullOrEmpty(txtStatus.Text))
            {
                var newRequest = new ServiceRequestModel(id, txtDescription.Text, txtStatus.Text);
                avlTree.Insert(newRequest);

                // Optional: Add new request to the graph
                serviceGraph.AddNode(id);

                MessageBox.Show("Service request added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                BindListView(avlTree.InOrderTraversal());
            }
            else
            {
                MessageBox.Show("Please provide valid details for the new request.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}