using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Models
{
    /// <summary>
    /// Stores a suggestion for where to eat.
    /// </summary>
    public class Top5Recommendation
    {
        /// <summary>
        /// Creates a new Recommendation.
        /// </summary>
        /// <param name="rank">Required, Read-Only. Rank of the Restaurant.</param>
        /// <param name="name">Required. Name of the Restaurant.</param>
        /// <param name="address">Required. Address of the Restaurant.</param>
        /// <param name="phone">Optional. Phone Number of the Restaurant.</param>
        /// <param name="dish">Optional. Default is "It's All Tasty!"</param>
        /// <param name="link">Optional. Default is "Coming Soon"</param>
        public Top5Recommendation(int rank, string name, string address, string phone = null, string dish = null, string link = null)
        {
            // Required Parameters
            Rank = rank;
            Name = name;
            Address = address;
            // Optional Parameters
            PhoneNumber = phone;
            FavDish = dish;
            WebsiteLink = link;
        }

        public static Top5Recommendation[] GetTop5()
        {
            Top5Recommendation[] top5 = {
                new Top5Recommendation(
                    rank: 1,
                    name: "Cafe Rio",
                    address: "2244 University Pkwy, Provo, UT 84604",
                    phone: "(801) 375-5133",
                    dish: "Sweet Pork Burrito"
                    ),
                new Top5Recommendation(
                    rank: 2,
                    name: "Bombay House",
                    address: "463 N University Ave, Provo, UT 84604",
                    link: "https://bombayhouse.com/"
                    ),
                new Top5Recommendation(
                    rank: 3,
                    name: "Costco Food Court",
                    address: "648 E 800 S, Orem, UT 84097",
                    dish: "Pizza Slice"
                    ),
                new Top5Recommendation(
                    rank: 4,
                    name: "MOA Cafe",
                    address: "500 Campus Dr, Provo, UT 84602",
                    link: "dining.byu.edu",
                    phone: "(801) 422-6990"
                    ),
                new Top5Recommendation(
                    rank: 5,
                    name: "The Skyroom Restaurant",
                    address: "Ernest L Wilkinson Student Center, 6th Floor, Provo, UT 84602",
                    phone: "(801) 422-9020",
                    link: "https://dining.byu.edu/skyroom/"
                    )
                };

            return top5;
        }

        /// <summary>
        /// Relative rank of the restaurant compared to others in Provo. Read-only.
        /// </summary>
        [Required]
        public int Rank { get; }

        /// <summary>
        /// Name of the restaurant.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The submitter's favorite dish at the restaurant.
        /// </summary>
        public string FavDish { get; set; }
        
        /// <summary>
        /// Address of the restaurant.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Phone number of the restaurant.
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The website URL for the restaurant (if they have one).
        /// </summary>
        public string WebsiteLink { get; set; } = "Coming Soon";
    }
}
