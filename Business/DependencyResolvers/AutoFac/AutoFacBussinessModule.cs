using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBussinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogDal>().As<IBlogDal>();
            builder.RegisterType<BlogManager>().As<IBlogService>();

            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();


            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As <IUserDal>();





        }
    }
}
