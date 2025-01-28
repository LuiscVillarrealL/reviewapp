using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewApp.Dto;
using RestaurantReviewApp.Models;
using RestaurantReviewApp.Persistence;
using RestaurantReviewApp.Services;

namespace RestaurantReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            var createdRestaurant = await _restaurantService.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = createdRestaurant.Id }, createdRestaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] RestaurantDto restaurantDto)
        {
            if (id != restaurantDto.Id)
                return BadRequest();

            var restaurant = _mapper.Map<Restaurant>(restaurantDto);

            var success = await _restaurantService.UpdateRestaurantAsync(restaurant);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var success = await _restaurantService.DeleteRestaurantAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

    }
}
