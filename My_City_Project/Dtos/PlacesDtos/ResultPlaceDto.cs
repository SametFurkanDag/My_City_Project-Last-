namespace My_City_Project.Dtos.PlacesDtos
{
    public class ResultPlaceDto
    {

        public Guid PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceLocation { get; set; }
        public Guid VendorId { get; set; }
    }
}
