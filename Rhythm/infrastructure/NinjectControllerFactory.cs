using System;
using Ninject;
using System.Web.Mvc;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Repository;
using Rhythm.BL.Provider;
using Rhythm.BL.Interfaces;
using AutoMapper;
using Rhythm.Mappers;
using Rhythm.Mappers.ChiefAdmin;
using System.Collections.Generic;

namespace Rhythm.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // AutoMapperConfiguration binding
            _kernel.Bind<IMapper>().ToMethod(AutoMapperConfig.GetMapper).InSingletonScope();

            // Mappers
            _kernel.Bind<CommentMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<PostMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<AboutMeMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<CategoryMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<RecentContentMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<SearchResultMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<TagMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<ContentAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<CategoryAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<CommentAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<PostAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<TagAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<CategoryAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<PortfolioAdminMapper>().ToSelf().InSingletonScope();
            _kernel.Bind<UserAdminMapper>().ToSelf().InSingletonScope();

            // Repositories
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            _kernel.Bind<ICommentRepository>().To<CommentRepository>();
            _kernel.Bind<IPostRepository>().To<PostRepository>();
            _kernel.Bind<IRssRepository>().To<RssRepository>();
            _kernel.Bind<ITagRepository>().To<TagRepository>();
            _kernel.Bind<IPortfolioRepository>().To<PortfolioRepository>();

            // Providers
            //ninjectKernel.Bind<IArchiveProvider>().To<ArchiveProvider>();
            _kernel.Bind<IUserProvider>().To<UserProvider>();
            _kernel.Bind<ICategoryProvider>().To<CategoryProvider>();
            _kernel.Bind<ICommentProvider>().To<CommentProvider>();
            _kernel.Bind<IPostProvider>().To<PostProvider>();
            _kernel.Bind<IRssProvider>().To<RssProvider>();
            _kernel.Bind<ITagProvider>().To<TagProvider>();
            _kernel.Bind<IPortfolioProvider>().To<PortfolioProvider>();
        }
    }
}