namespace CinemaWatcher.Entities.EntitiesModels
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Duration { get; set; }
        public DateTime DateOfPublish { get; set; }
    }
}
