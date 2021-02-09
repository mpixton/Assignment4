using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Models
{
    public class RecommendationStorage
    {
        private static List<UserRecommendation> recommendations = new List<UserRecommendation>();

        public static IEnumerable<UserRecommendation> Recommendations => recommendations;

        /// <summary>
        /// Adds a Recommendation to memory storage.
        /// </summary>
        /// <param name="Rec">Restaurant Recommendation to add.</param>
        public static void AddRecommendation(UserRecommendation Rec)
        {
            recommendations.Add(Rec);
        }
    }
}
