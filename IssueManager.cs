namespace MunicipalAppProgPoe
{
    public class IssueManager
    {
        private static List<Issue> issuesList = new List<Issue>();

        public static void AddIssue( Issue issue )
        {
            issuesList.Add(issue);
        }

        public static List<Issue> GetIssues()
        {
            return issuesList;
        }
    }
}
