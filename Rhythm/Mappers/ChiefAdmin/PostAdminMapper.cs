using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using AutoMapper;
using Rhythm.Models.RecentViewModel;
using Rhythm.Areas.ChiefAdmin.Models;

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
            //post.Category = category;
            //post.Tags = tags;

            return post;
        }

        public PostAdminViewModel ToPostViewModel(Post post)
        {
            return _mapper.Map<Post, PostAdminViewModel>(post);
        }

        public ImageAdminViewModel ToImageViewModel(Post post)
        {
            return new ImageAdminViewModel
            {
                PostId = post.Id,
                ImageDataByte = post.ImageData,
                ImageMime = post.ImageMime
            };
        }

        public Post FromImageViewModelToPost(ImageAdminViewModel imageViewModel, Post post)
        {
            byte[] image = new byte[imageViewModel.ImageData.ContentLength];
            imageViewModel.ImageData.InputStream.Read(image, 0, image.Length);
           
            post.ImageData = image;
            post.ImageMime = imageViewModel.ImageMime;

            return post;
        }


        public List<PostAdminViewModel> ToPostsViewModel(IEnumerable<Post> posts)
        {
            return posts.Select(ToPostViewModel).ToList();
        }
    }
}