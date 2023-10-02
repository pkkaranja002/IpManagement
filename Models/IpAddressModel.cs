namespace IpManagement.Models
{
    public class IpAddressModel
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public int? CustomerId { get; set; }
    }
}
