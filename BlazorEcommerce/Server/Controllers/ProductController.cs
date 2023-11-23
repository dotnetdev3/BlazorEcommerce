using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
        new Product
        {
            Id = 1,
            Title = "The Name of the Wind",
            Description = "The Name of the Wind, also referred to as The Kingkiller Chronicle: Day One, is a heroic fantasy novel written by American author Patrick Rothfuss. It is the first book in the ongoing fantasy trilogy The Kingkiller Chronicle, followed by The Wise Man's Fear. It was published on March 27, 2007, by DAW Books.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/56/TheNameoftheWind_cover.jpg?20210808000902",
            Price = 9.99m
        },
        new Product
        {
            Id = 2,
            Title = "The Wise Man's Fear",
            Description = "The Wise Man's Fear is a fantasy novel written by American author Patrick Rothfuss and the second volume in The Kingkiller Chronicle. It was published on March 1, 2011, by DAW Books.[3] It is the sequel to 2007's The Name of the Wind.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7b/The_Wise_Man%27s_Fear.jpg",
            Price = 9.00m
        },
        new Product
        {
            Id = 3,
            Title = "The Hobbit",
            Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published in 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/4/4a/TheHobbit_FirstEdition.jpg/220px-TheHobbit_FirstEdition.jpg",
            Price = 5.00m
        }
        };

        [HttpGet] 
        public async Task<ActionResult<List<Product>>> Get()
        {
            return  Ok(Products);
        }
    }
}
