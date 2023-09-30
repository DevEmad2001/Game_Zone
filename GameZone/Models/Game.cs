
namespace GameZone.Models
{
    public class Game:BaseEntity
    {
        [Required]
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; }=new List<GameDevice>();// relation many to many

    }
}
