namespace Flight_Finder.Api.DTO
{
    public class Filter
    {
        public string? DepartureLocation { get; set; }
        public string? ArrivalLocation { get; set; }
        public DateTime? TravelDate { get; set; }
        public double? LowPrice { get; set; } = 0;
        public double? HighPrice { get; set; }

    }
}
