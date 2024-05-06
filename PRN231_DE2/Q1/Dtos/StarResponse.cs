namespace Q1.Dtos
{
    public class StarResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool? Male { get; set; }
        public string gender { get; set; }
        public DateTime? Dob { get; set; }
        public string dobString { get; set; }
        public string? Description { get; set; }
        public string? Nationality { get; set; }

    }

    public class StartResponse2
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string gender { get; set; }
        public DateTime? Dob { get; set; }
        public string dobString { get; set; }
        public string? Nationality { get; set; }

        public string? Description { get; set; }

        public ICollection<MovieResponse> Movies { get; set; }
    }
}
