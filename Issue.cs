public class Issue
{
    public string Location { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public List<string> AttachedFiles { get; set; }

    public Issue( string location, string category, string description, List<string> attachedFiles )
    {
        Location = location;
        Category = category;
        Description = description;
        AttachedFiles = attachedFiles;
    }
}
