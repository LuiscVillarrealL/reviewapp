using Microsoft.EntityFrameworkCore;
using RestaurantReviewApp.Models;
using RestaurantReviewApp.Persistence;

namespace RestaurantReviewApp.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly ApplicationDbContext _dbContext;

        public RestaurantService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return restaurant;
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
                return false;

            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _dbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            return await _dbContext.Restaurants.FindAsync(id);
        }

        public async Task<bool> UpdateRestaurantAsync(Restaurant restaurant)
        {
            var existingRestaurant = await _dbContext.Restaurants.FindAsync(restaurant.Id);
            if (existingRestaurant == null)
                return false;

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Location = restaurant.Location;
            existingRestaurant.AverageRating = restaurant.AverageRating;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
