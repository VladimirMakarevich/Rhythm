using AutoMapper;
using Ninject.Activation;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper(IContext context)
        {
            MapperConfiguration config = new MapperConfiguration(RegisterMappings);
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        private static void RegisterMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Post, PostViewModel>().ReverseMap();
            config.CreateMap<Comment, CommentViewModel>().ReverseMap();
            config.CreateMap<Post, PostRecentViewModel>().ReverseMap();
            config.CreateMap<Comment, CommentRecentViewModel>().ReverseMap();
            config.CreateMap<Category, CategoryRecentViewModel>().ReverseMap();
            config.CreateMap<Tag, TagRecentViewModel>().ReverseMap();
        }
    }
}