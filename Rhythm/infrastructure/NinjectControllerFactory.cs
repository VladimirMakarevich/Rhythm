using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using Rhythm.Areas.ChiefAdmin.Models;
using Microsoft.AspNet.Identity;
using Rhythm.Authentication;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Repository;
using Rhythm.BL.Provider;
using Rhythm.BL.Interfaces;

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
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            ninjectKernel.Bind<ICommentRepository>().To<CommentRepository>();
            ninjectKernel.Bind<IPostRepository>().To<PostRepository>();
            ninjectKernel.Bind<IRssRepository>().To<RssRepository>();
            ninjectKernel.Bind<ITagRepository>().To<TagRepository>();
            ninjectKernel.Bind<IPortfolioRepository>().To<PortfolioRepository>();

            ninjectKernel.Bind<IArchiveProvider>().To<ArchiveProvider>();
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