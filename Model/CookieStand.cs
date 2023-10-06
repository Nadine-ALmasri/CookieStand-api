namespace cookie_stand_api.Model
{
    public class CookieStand
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }

        // Navigation property 
        public List<HourlySales>? HourlySales { get; set; }
    }
}
