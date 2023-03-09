

namespace AnimeAPI.Models
{
    public class Anime
    {
        public int Id { get; set; }

        public string TitleJP { get; set; }

        public string TitleEN { get; set; }

        public string Image { get; set; }

        public DateTime RelaseDate { get; set; }

        public bool IsFinished { get; set; }

        public string Description { get; set; }
    }
}
