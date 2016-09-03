using AutoMapper;
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
        public static MapperConfiguration MapperConfigCategory;
        public static MapperConfiguration MapperConfigTag;
        public static MapperConfiguration MapperConfigComment;

        public static void RegisterMapping()
        {
            MapperConfigCategory = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
            });

            MapperConfigTag = new MapperConfiguration(cfg => {
                cfg.CreateMap<Tag, TagViewModel>().ReverseMap();
            });

            MapperConfigComment = new MapperConfiguration(cfg => {
                cfg.CreateMap<CommentViewModel, Comment>().ReverseMap();
            });
        }
        //public static MapperConfiguration MapperConfig;

        //public static void RegisterMappingCategory()
        //{
        //    MapperConfig = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<TagViewModel, Tag>();
        //    });
        //}
    }
}