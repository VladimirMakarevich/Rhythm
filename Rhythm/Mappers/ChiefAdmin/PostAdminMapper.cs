using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using System;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class PostAdminMapper
    {
        private IMapper _mapper;

        public PostAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Post ToPost(PostAdminViewModel postViewModel, List<Tag> tags, Category category)
        {
            var post = _mapper.Map<PostAdminViewModel, Post>(postViewModel);

            return post;
        }

        public PostAdminViewModel ToPostViewModel(Post post)
        {
            return _mapper.Map<Post, PostAdminViewModel>(post);
        }

        public ImageAdminViewModel ToImageViewModel(Post post)
        {
            var imageViewModel = _mapper.Map<Post, ImageAdminViewModel>(post);
            if (post.ImagePath != null)
            {
                imageViewModel.ImageData = System.IO.File.ReadAllBytes(post.ImagePath);
            }

            return imageViewModel;
        }

        //public Post FromImageViewModelToPost(ImageAdminViewModel imageViewModel, Post post)
        //{
        //    byte[] image = new byte[imageViewModel.ImageData.ContentLength];
        //    imageViewModel.ImageData.InputStream.Read(image, 0, image.Length);

        //    post.ImageData = image;
        //    post.ImageMime = imageViewModel.ImageMime;

        //    return post;
        //}


        public List<PostAdminViewModel> ToPostsViewModel(IEnumerable<Post> posts)
        {
            return posts.Select(ToPostViewModel).ToList();
        }

        public Post FromImagePathToPost(string filePath, string imageMime, Post post)
        {
            post.ImagePath = filePath;
            post.ImageMime = imageMime;

            return post;
        }
    }
}