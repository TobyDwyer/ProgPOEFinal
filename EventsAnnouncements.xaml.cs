using System.Windows;
using System.Windows.Controls;

namespace MunicipalAppProgPoe
{
    public partial class EventsAnnouncements : Page
    {
        private List<Event> EventsList = new List<Event>();
        private Dictionary<string, Event> eventDictionary = new Dictionary<string, Event>();
        private HashSet<string> uniqueCategories = new HashSet<string>();
        private HashSet<DateTime> uniqueDates = new HashSet<DateTime>();
        private Stack<string> searchHistory = new Stack<string>();
        private Queue<string> userSearchPatterns = new Queue<string>();
        private PriorityQueue<Event, DateTime> eventQueue = new PriorityQueue<Event, DateTime>();

        public EventsAnnouncements()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            EventsList.Add(new Event("Music Festival", DateTime.Now.AddDays(10), "Music", "Town Hall"));
            EventsList.Add(new Event("Art Exhibition", DateTime.Now.AddDays(15), "Art", "City Museum"));
            EventsList.Add(new Event("Community Fair", DateTime.Now.AddDays(5), "Fair", "Central Park"));
            EventsList.Add(new Event("Food Truck Fiesta", DateTime.Now.AddDays(8), "Food", "Main Square"));
            EventsList.Add(new Event("Marathon", DateTime.Now.AddDays(20), "Sports", "City Stadium"));
            EventsList.Add(new Event("Book Fair", DateTime.Now.AddDays(12), "Books", "Convention Center"));
            EventsList.Add(new Event("Craft Market", DateTime.Now.AddDays(7), "Market", "Riverside Park"));
            EventsList.Add(new Event("Film Screening", DateTime.Now.AddDays(18), "Film", "Grand Theater"));
            EventsList.Add(new Event("Science Expo", DateTime.Now.AddDays(11), "Science", "Tech University"));
            EventsList.Add(new Event("Pet Adoption Day", DateTime.Now.AddDays(14), "Pets", "Animal Shelter"));
            EventsList.Add(new Event("Comedy Night", DateTime.Now.AddDays(6), "Comedy", "Downtown Club"));
            EventsList.Add(new Event("Jazz Concert", DateTime.Now.AddDays(9), "Music", "Jazz Hall"));
            EventsList.Add(new Event("Coding Bootcamp", DateTime.Now.AddDays(17), "Tech", "Tech Hub"));
            EventsList.Add(new Event("Wine Tasting", DateTime.Now.AddDays(22), "Food", "Vineyard"));
            EventsList.Add(new Event("Startup Pitch", DateTime.Now.AddDays(25), "Business", "Innovation Center"));
            EventsList.Add(new Event("Yoga Retreat", DateTime.Now.AddDays(13), "Health", "Mountain Resort"));
            EventsList.Add(new Event("Charity Auction", DateTime.Now.AddDays(16), "Charity", "Hotel Ballroom"));
            EventsList.Add(new Event("Dance Workshop", DateTime.Now.AddDays(21), "Dance", "Dance Studio"));
            EventsList.Add(new Event("Photography Exhibition", DateTime.Now.AddDays(19), "Art", "Art Gallery"));
            EventsList.Add(new Event("Historical Tour", DateTime.Now.AddDays(24), "History", "Old Town"));
            EventsList.Add(new Event("Orchestra Performance", DateTime.Now.AddDays(23), "Music", "Concert Hall"));
            EventsList.Add(new Event("Sculpture Workshop", DateTime.Now.AddDays(30), "Art", "Cultural Center"));
            EventsList.Add(new Event("Farmers Market", DateTime.Now.AddDays(4), "Market", "Green Park"));
            EventsList.Add(new Event("Chess Tournament", DateTime.Now.AddDays(28), "Games", "Library"));
            EventsList.Add(new Event("Beach Cleanup", DateTime.Now.AddDays(3), "Environment", "Beachfront"));

            foreach (var ev in EventsList)
            {
                eventDictionary[ev.Name.ToLower()] = ev;
                uniqueCategories.Add(ev.Category);
                uniqueDates.Add(ev.Date.Date);
                eventQueue.Enqueue(ev, ev.Date);
            }

            // Load sorted events by date into the ListView
            EventsList = eventQueue.UnorderedItems.Select(item => item.Element).ToList();
            lvEvents.ItemsSource = EventsList;
        }

        private void BtnSearch_Click( object sender, RoutedEventArgs e )
        {
            SearchWindow searchWindow = new SearchWindow();
            if (searchWindow.ShowDialog() == true)
            {
                string? eventName = searchWindow.EventName?.ToLower();
                string? category = searchWindow.Category?.ToLower();
                DateTime? eventDate = searchWindow.EventDate;

                // Store search term in the history stack
                searchHistory.Push(eventName ?? "");
                if (!string.IsNullOrEmpty(eventName))
                    userSearchPatterns.Enqueue(eventName);

                // Filter events based on search input
                var filteredEvents = EventsList.Where(ev =>
                    (string.IsNullOrEmpty(eventName) || ev.Name.ToLower().Contains(eventName)) &&
                    (string.IsNullOrEmpty(category) || ev.Category.ToLower().Contains(category)) &&
                    (!eventDate.HasValue || ev.Date.Date == eventDate.Value.Date)).ToList();

                lvEvents.ItemsSource = filteredEvents;

            }
        }

        // Reset button click event to clear search filters
        private void BtnReset_Click( object sender, RoutedEventArgs e )
        {
            lvEvents.ItemsSource = EventsList;
        }

        // Retrieve event by name from dictionary
        private Event? GetEventByName( string name )
        {
            return eventDictionary.ContainsKey(name.ToLower()) ? eventDictionary[name.ToLower()] : null;
        }

        // Recommendation logic based on user search history
        private List<Event> GetRecommendedEvents()
        {
            if (!userSearchPatterns.Any()) return new List<Event>();

            // Find the most searched term
            var mostSearchedTerm = userSearchPatterns.GroupBy(x => x)
                                                     .OrderByDescending(g => g.Count())
                                                     .First().Key;

            // Recommend events based on most searched term
            return EventsList.Where(ev => ev.Name.ToLower().Contains(mostSearchedTerm) ||
                                          ev.Category.ToLower().Contains(mostSearchedTerm)).ToList();
        }

        // Show recommendations to the user
        private void ShowRecommendations()
        {
            var recommendedEvents = GetRecommendedEvents();
            if (recommendedEvents.Any())
            {
                lvEvents.ItemsSource = recommendedEvents;
            }
            else
            {
                MessageBox.Show("No recommendations found based on your search.",
                            "No Recommendations", MessageBoxButton.OK, MessageBoxImage.Information);

                lvEvents.ItemsSource = EventsList;
            }
        }


        private void BtnReccomended_Click( object sender, RoutedEventArgs e )
        {
            ShowRecommendations();
        }
    }

    public class Event
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }

        public Event( string name, DateTime date, string category, string location )
        {
            Name = name;
            Date = date;
            Category = category;
            Location = location;
        }
    }
}
