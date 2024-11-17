namespace MunicipalAppProgPoe.Models
{
    public class ServiceRequestModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ServiceRequestModel( int id, string description, string status )
        {
            Id = id;
            Description = description;
            Status = status;
        }
    }

}
