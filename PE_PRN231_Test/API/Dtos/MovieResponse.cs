namespace API.Dtos
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int RelatedYear { get; set; }
        public string? Description { get; set; }
        public string Language { get; set; } = null!;
        public int? ProducerId { get; set; }
        public int? DirectorId { get; set; }
        public string ProducerName { get; set; }
        public string DirectorName { get; set; }
        public virtual ICollection<GenraResponse> Genres { get; set; }
        public virtual ICollection<StarsResponse> Stars { get; set; }

    }
}
