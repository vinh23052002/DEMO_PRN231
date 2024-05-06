namespace API.Dtos
{
    public class DirectorsResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MovieResponse> Movies { get; set; }

    }

    public class DirectorResponse2
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string DobString { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;

    }

}
