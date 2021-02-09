using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Models
{
    /// <summary>
    /// Stores a suggestion for where to eat.
    /// </summary>
    public class UserRecommendation
    {
        /// <summary>
        /// A User entered restaurant recommendation.
        /// </summary>
        /// <param name="submitter">Name of the Submitter</param>
        /// <param name="name">Name of the Restaurant</param>
        /// <param name="phone">Phone number of the restaurant</param>
        /// <param name="dish">Name of the favorite dish</param>
        public UserRecommendation(string submitter, string name, string phone, string dish)
        {
            // Required Parameters
            Submitter = submitter;
            Name = name;
            PhoneNumber = phone;
            FavDish = dish;
        }

        /// <summary>
        /// Parameterless constructor, used by the app to create objects from the view.
        /// </summary>
        public UserRecommendation() { }

        /// <summary>
        /// The name of the person submitting the Recommendation.
        /// </summary>
        [Required]
        [Display(Name = "Your Name")]
        public string Submitter { get; set; }

        /// <summary>
        /// Name of the restaurant.
        /// </summary>
        [Required]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        /// <summary>
        /// The submitter's favorite dish at the restaurant.
        /// </summary>
        [Required]
        [Display(Name = "Favorite Dish")]
        public string FavDish { get; set; }

        /// <summary>
        /// Phone number of the restaurant.
        /// </summary>
        [Required(ErrorMessage = "Phone must be in format: (###) ###-####")]
        [RegularExpression(@"^\([\d]{3}\) [\d]{3}-[\d]{4}$",
            ErrorMessage ="Phone must be in format: (###) ###-####")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
