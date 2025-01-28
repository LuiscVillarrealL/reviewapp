namespace RestaurantReviewApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double AverageRating { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
