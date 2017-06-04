using System;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Repository;
using Rhythm.BL.Provider;
using Rhythm.BL.Interfaces;
using AutoMapper;
using Rhythm.Mappers;
using Rhythm.Mappers.ChiefAdmin;

namespace Rhythm.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            // AutoMapperConfiguration binding
            ninjectKernel.Bind<IMapper>().ToMethod(AutoMapperConfig.GetMapper).InSingletonScope();

            // Mappers
            ninjectKernel.Bind<CommentMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PostMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<AboutMeMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<CategoryMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<RecentContentMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<SearchResultMapper>().ToSelf().InSingletonScope(); 
            ninjectKernel.Bind<TagMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<ContentAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<CategoryAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<CommentAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PostAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<TagAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<CategoryAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<PortfolioAdminMapper>().ToSelf().InSingletonScope();
            ninjectKernel.Bind<UserAdminMapper>().ToSelf().InSingletonScope();

            // Repositories
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            ninjectKernel.Bind<ICommentRepository>().To<CommentRepository>();
            ninjectKernel.Bind<IPostRepository>().To<PostRepository>();
            ninjectKernel.Bind<IRssRepository>().To<RssRepository>();
            ninjectKernel.Bind<ITagRepository>().To<TagRepository>();
            ninjectKernel.Bind<IPortfolioRepository>().To<PortfolioRepository>();

            // Providers
            //ninjectKernel.Bind<IArchiveProvider>().To<ArchiveProvider>();
            ninjectKernel.Bind<IUserProvider>().To<UserProvider>();
            ninjectKernel.Bind<ICategoryProvider>().To<CategoryProvider>();
            ninjectKernel.Bind<ICommentProvider>().To<CommentProvider>();
            ninjectKernel.Bind<IPostProvider>().To<PostProvider>();
            ninjectKernel.Bind<IRssProvider>().To<RssProvider>();
            ninjectKernel.Bind<ITagProvider>().To<TagProvider>();
            ninjectKernel.Bind<IPortfolioProvider>().To<PortfolioProvider>();
        }
    }
}