using RestaurantReviewApp.Models;

namespace RestaurantReviewApp.Services
{
    public interface IRestaurantService
    {

        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant?> GetRestaurantByIdAsync(int id);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<bool> UpdateRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);

    }
}
