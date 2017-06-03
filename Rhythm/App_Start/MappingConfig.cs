using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm
{
    public static class MappingConfig
    {
        //Определяем поля, типа MapperConfiguration
        public static MapperConfiguration MapperConfigCategory;
        public static MapperConfiguration MapperConfigTag;
        public static MapperConfiguration MapperConfigComment;
        public static MapperConfiguration MapperConfigPost;
        public static MapperConfiguration MapperConfigPortfolio;
        public static MapperConfiguration MapperConfigChiefUser;

        public static void RegisterMapping()
        {
            // Создаем связь Категорий
            MapperConfigCategory = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryAdminViewModel>().ReverseMap();
            });
            // Создаем связь Тэга
            MapperConfigTag = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tag, TagAdminViewModel>().ReverseMap();
            });
            // Создаем связь Комментариев
            MapperConfigComment = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentAdminViewModel>().ReverseMap();
            });
            // Создаем связь Постов
            MapperConfigPost = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostAdminViewModel>().ReverseMap();
            });
            MapperConfigPortfolio = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Portfolio, PortfolioAdminViewModel>().ReverseMap();
            });
            MapperConfigChiefUser = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChiefUser, ChiefUserAdminViewModel>().ReverseMap();
            });
        }
    }
}