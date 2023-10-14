namespace cookie_stand_api.Model.DTO
{
    public class CookieStandDTO
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }
    }
    public class CookiePost
    {
        public int id { get; set; }
        public string Location { get; set; }
      
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
      
    }
}
