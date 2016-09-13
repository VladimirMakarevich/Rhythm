﻿using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Model;
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

        public static void RegisterMapping()
        {
            // Создаем связь Категорий
            MapperConfigCategory = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
            });
            // Создаем связь Тэга
            MapperConfigTag = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tag, TagViewModel>().ReverseMap();
            });
            // Создаем связь Комментариев
            MapperConfigComment = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
            });
            // Создаем связь Постов
            MapperConfigPost = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>().ReverseMap();
            });
        }
    }
}