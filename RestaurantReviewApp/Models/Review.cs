namespace RestaurantReviewApp.Models
{
    public class Review
    {

        public int Id { get; set; }
        public User Reviewer { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
