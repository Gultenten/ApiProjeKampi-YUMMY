namespace ApiProjeKampi_YUMMY.WebApi.Entities
{
    public class GroupReservation
    {
        public int GroupReservationId { get; set; }
        public string ResponsibleCustomerName{ get; set; }
        public string GroupTitle{ get; set; }
        public DateTime ReservationDate{ get; set; }
        public DateTime LastProcessDate{ get; set; }
        public string Priority{ get; set; }
        public int? PersonCount{ get; set; }
        public string? Email{ get; set; }
    }
}
