using System.ComponentModel.DataAnnotations;

namespace CinemaWatcher.Entities.EntitiesModels
{
    public class Series
    {
        [Required]
        public int SerieId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Duration { get; set; }
        public DateTime DateOfPublish { get; set; }
    }
}
