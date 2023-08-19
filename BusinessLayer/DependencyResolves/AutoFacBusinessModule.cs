using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolves
{
    public class AutoFacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>();
            builder.RegisterType<EfAboutDal>().As<IAboutDAL>();

            builder.RegisterType<AnnouncementsManager>().As<IAnnouncementsService>();
            builder.RegisterType<EfAnnouncementsDal>().As<IAnnouncementsDAL>();

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDAL>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDAL>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDAL>();

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDAL>();

            builder.RegisterType<ContactBoxManager>().As<IContactBoxService>();
            builder.RegisterType<EfContactBoxDal>().As<IContactBoxDAL>();

            builder.RegisterType<NewsLetterManager>().As<INewsLetterService>();
            builder.RegisterType<EfNewsLetterDal>().As<INewsLetterDAL>();

            builder.RegisterType<WriterManager>().As<IWriterService>();
            builder.RegisterType<EfWriterDal>().As<IWriterDAL>();

            builder.RegisterType<WritersMessageManager>().As<IWritersMessageService>();
            builder.RegisterType<EfWritersMessageDal>().As<IWritersMessageDAL>();

            builder.RegisterType<WriterUserManager>().As<IWriterUserService>();
            builder.RegisterType<EfWriterUserDal>().As<IWriterUserDAL>();
        }
    }
}
