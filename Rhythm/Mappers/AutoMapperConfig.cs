using AutoMapper;
using Ninject.Activation;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using Rhythm.Models.RecentViewModel;
using Rhythm.Models.RssFeeds;

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
            config.CreateMap<Post, ImageAdminViewModel>().ReverseMap();
            config.CreateMap<Comment, CommentViewModel>().ReverseMap();
            config.CreateMap<Post, PostRecentViewModel>().ReverseMap();
            config.CreateMap<Comment, CommentRecentViewModel>().ReverseMap();
            config.CreateMap<Category, CategoryRecentViewModel>().ReverseMap();
            config.CreateMap<Tag, TagRecentViewModel>().ReverseMap();
            config.CreateMap<Rss, RssEntityViewModel>().ReverseMap();
            config.CreateMap<Project, ProjectViewModel>().ReverseMap();
            config.CreateMap<Portfolio, PortfolioViewModel>().ReverseMap();

            // Admin area
            config.CreateMap<ChiefUser, ChiefUserAdminViewModel>().ReverseMap();
            config.CreateMap<Portfolio, PortfolioAdminViewModel>().ReverseMap();
            config.CreateMap<Post, PostAdminViewModel>().ReverseMap();
            config.CreateMap<Comment, CommentAdminViewModel>().ReverseMap();
            config.CreateMap<Category, CategoryAdminViewModel>().ReverseMap();
            config.CreateMap<Tag, TagAdminViewModel>().ReverseMap();
            config.CreateMap<Project, ProjectAdminViewModel>().ReverseMap();
            config.CreateMap<Rss, RssAdminViewModel>().ReverseMap();
        }
    }
}