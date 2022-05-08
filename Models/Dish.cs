using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ?Description { get; set; }
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }

        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
    }
}
