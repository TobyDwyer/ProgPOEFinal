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
        private int _currentId = 0;

        public ServiceRequest()
        {
            InitializeComponent();
            LoadSampleData();
            BindListView(avlTree.InOrderTraversal());
        }

        private void LoadSampleData()
        {
            var requests = new List<ServiceRequestModel>
            {
                new ServiceRequestModel(1, "Fix streetlight", "Pending"),
                new ServiceRequestModel(2, "Water leakage", "In Progress"),
                new ServiceRequestModel(3, "Garbage collection", "Completed"),
                new ServiceRequestModel(4, "Repair pothole", "Pending"),
                new ServiceRequestModel(5, "Clear fallen tree", "In Progress"),
                new ServiceRequestModel(6, "Replace damaged stop sign", "Pending"),
                new ServiceRequestModel(7, "Repair broken fence", "Completed"),
                new ServiceRequestModel(8, "Fix playground equipment", "Pending"),
                new ServiceRequestModel(9, "Check traffic lights", "In Progress"),
                new ServiceRequestModel(10, "Repair water main", "Completed"),
                new ServiceRequestModel(11, "Trim overgrown hedges", "Pending"),
                new ServiceRequestModel(12, "Inspect sewage system", "In Progress"),
                new ServiceRequestModel(13, "Repair street signs", "Pending"),
                new ServiceRequestModel(14, "Fill potholes on Main Street", "Completed"),
                new ServiceRequestModel(15, "Inspect electrical lines", "In Progress")
            };

            // Sets up tree and nodes
            foreach (var request in requests)
            {
                avlTree.Insert(request);
                _currentId = Math.Max(_currentId, request.Id);
            }

            var allNodes = avlTree.InOrderTraversal();
            foreach (var node in allNodes)
            {
                AddEdgesForNewNode(node.Id);
            }

            _currentId = requests.Max(r => r.Id);

        }

        private void BindListView( IEnumerable<ServiceRequestModel> data )
        {
            lvRequest.ItemsSource = data;
        }

        // Search function that searches for description and status
        private void BtnSearch_Click( object sender, RoutedEventArgs e )
        {
            string description = txtSearchDescription.Text.ToLower();
            string status = txtSearchStatus.Text.ToLower();

            var results = avlTree.InOrderTraversal().Where(req =>
                (string.IsNullOrEmpty(description) || req.Description.ToLower().Contains(description)) &&
                (string.IsNullOrEmpty(status) || req.Status.ToLower().Equals(status))
            ).ToList();

            if (results.Any())
            {
                BindListView(results);
            }
            else
            {
                MessageBox.Show("No matching requests found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Resets the list
        private void BtnViewAll_Click( object sender, RoutedEventArgs e )
        {
            BindListView(avlTree.InOrderTraversal());
        }

        // Takes in Status and description and adds new request with auto increment id
        private void BtnAddRequest_Click( object sender, RoutedEventArgs e )
        {
            string description = txtDescription.Text;
            string status = cmbStatus.Text;

            if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(status))
            {
                AddRequest(description, status);
                MessageBox.Show("Service request added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                txtDescription.Clear();
                cmbStatus.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please provide valid details for the new request.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Adds the request to the graph and tree
        private void AddRequest( string description, string status )
        {
            _currentId++;

            var newRequest = new ServiceRequestModel(_currentId, description, status);
            avlTree.Insert(newRequest);


            serviceGraph.AddNode(_currentId);
            AddEdgesForNewNode(_currentId);

            BindListView(avlTree.InOrderTraversal());
        }

        // Takes selected item and shows the related items
        private void BtnShowRelatedItems_Click( object sender, RoutedEventArgs e )
        {
            if (lvRequest.SelectedItem is ServiceRequestModel selectedRequest)
            {

                var connectedIds = serviceGraph.GetConnectedComponent(selectedRequest.Id);

                var relatedRequests = avlTree.InOrderTraversal()
                    .Where(req => connectedIds.Contains(req.Id))
                    .ToList();

                if (relatedRequests.Any())
                {
                    BindListView(relatedRequests);
                }
                else
                {
                    MessageBox.Show("No related service requests found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a service request to find related tasks.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Adds edges for new items that are added to the list so that the items can be better searched.
        private void AddEdgesForNewNode( int newId )
        {
            int defaultWeight = 3;

            var newNode = avlTree.Search(newId);
            if (newNode == null) return;

            var newWords = newNode.Description.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var allNodes = avlTree.InOrderTraversal();
            foreach (var node in allNodes)
            {
                if (node.Id == newId) continue;

                var nodeWords = node.Description.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var commonWords = newWords.Intersect(nodeWords);

                if (commonWords.Any())
                {
                    serviceGraph.AddNode(newId);
                    serviceGraph.AddNode(node.Id);
                    serviceGraph.AddEdge(newId, node.Id, defaultWeight);
                }
            }
        }


        private void btnBack_Click( object sender, RoutedEventArgs e )
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.ClearMainFrame();
                mainWindow.ShowMainContent();
            }
        }

        // Optimizes the display by ordering in logical ways
        private void OptimizeDisplay()
        {
            var allRequests = avlTree.InOrderTraversal();


            var sortedRequests = allRequests
                .OrderBy(req => req.Status)
                .ThenBy(req => req.Description)
                .ThenBy(req => req.Id)
                .ToList();

            BindListView(sortedRequests);
        }

        private void BtnOptimizeDisplay_Click( object sender, RoutedEventArgs e )
        {
            OptimizeDisplay();

        }
    }
}
