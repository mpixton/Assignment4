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
    public class Recommendation
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
        public Recommendation(int rank, string name, string address, string phone = null, string dish = null, string link = null)
        {
            // Required Parameters
            Rank = rank;
            Name = name;
            Address = address;
            // Optional Parameters
            PhoneNumber = phone;
            FavDish = dish ?? "It's all tasty!";
            WebsiteLink = link ?? "Coming Soon";
        }

        /// <summary>
        /// Relative rank of the restaurant compared to others in Provo. Read-only.
        /// </summary>
        [Required]
        public int Rank { get; } = 0;

        /// <summary>
        /// The name of the person submitting the Recommendation.
        /// </summary>
        public string Submitter { get; set; }

        /// <summary>
        /// Name of the restaurant.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The submitter's favorite dish at the restaurant.
        /// Default: "It's All Tasty!"
        /// </summary>
        public string? FavDish { get; set; }
        
        /// <summary>
        /// Address of the restaurant.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Phone number of the restaurant.
        /// </summary>
        [Phone]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// The website URL for the restaurant (if they have one).
        /// Default: "Coming Soon"
        /// </summary>
        public string? WebsiteLink { get; set; }
    }
}
