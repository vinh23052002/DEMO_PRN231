using AutoMapper;
using Q1.Models;

namespace Q1.Dtos
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Star, StarResponse>()
            .ForMember(x => x.gender, y => y.MapFrom(p => p.Male.Value ? "Male" : "FeMale"))
            .ForMember(x => x.dobString, y => y.MapFrom(p => p.Dob.Value.ToString("MM/dd/yyyy")));


            CreateMap<Movie, MovieResponse>()
                .ForMember(x => x.ReleaseYear, y => y.MapFrom(p => p.ReleaseDate.Value.ToString("yyyy")))
                .ForMember(x => x.ProducerName, y => y.MapFrom(p => p.Producer.Name))
                .ForMember(x => x.DirectorName, y => y.MapFrom(p => p.Director.FullName))
                .ForMember(x => x.Genres, y => y.MapFrom(p => new List<String>()))
                .ForMember(x => x.Starts, y => y.MapFrom(p => new List<String>()));

            CreateMap<Star, StartResponse2>()
            .ForMember(x => x.gender, y => y.MapFrom(p => p.Male.Value ? "Male" : "FeMale"))
            .ForMember(x => x.dobString, y => y.MapFrom(p => p.Dob.Value.ToString("MM/dd/yyyy")))
            .ForMember(x => x.Movies, y => y.MapFrom(p => p.Movies));
        }
    }
}
