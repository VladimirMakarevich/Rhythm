using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Models;
using Rhythm.BL.Models;
using System;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers
{
    public class CommentMapper
    {
        private IMapper _mapper;

        public CommentMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<CommentViewModel> ToCommentsViewModel(IEnumerable<Comment> comments)
        {
            return comments.Select(ToCommentViewModel).ToList();
        }

        public CommentViewModel ToCommentViewModel(Comment comment)
        {
            return _mapper.Map<Comment, CommentViewModel>(comment);
        }

        public List<CommentRecentViewModel> ToCommetRecentViewModel(List<Comment> comments, IEnumerable<Post> posts)
        {
            List<CommentRecentViewModel> commentRecentListViewModel = new List<CommentRecentViewModel>();

            comments.ForEach(comment =>
            {
                var post = posts.SingleOrDefault(p => p.Id == comment.Id);

                commentRecentListViewModel.Add(new CommentRecentViewModel
                {
                    CommentContent = comment.CommentMessage,
                    PostAddedDate = comment.PostedOn,
                    NameUserSender = comment.NameUserSender,
                    Id = comment.PostId
                });
            });

            return commentRecentListViewModel;
        }
    }
}