namespace cookie_stand_api.Model
{
    public class HourlySales
    {
        public int Id { get; set; }
        public int CookieStandId { get; set; } 
       
        public int SalesAmount { get; set; }
       
        // Navigation property 
        //public CookieStand? CookieStand { get; set; }
    }
}
