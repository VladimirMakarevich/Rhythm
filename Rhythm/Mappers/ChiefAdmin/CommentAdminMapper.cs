using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Models;
using Rhythm.BL.Models;
using System;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class CommentAdminMapper
    {
        private IMapper _mapper;

        public CommentAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CommentAdminViewModel ToCommentViewModel(Comment comment)
        {
            return _mapper.Map<Comment, CommentAdminViewModel>(comment);
        }

        public Comment ToComment(CommentAdminViewModel commentViewModel)
        {
            return _mapper.Map<CommentAdminViewModel, Comment>(commentViewModel);
        }

        public List<CommentAdminViewModel> ToCommentsViewModel(IEnumerable<Comment> comments)
        {
            return comments.Select(ToCommentViewModel).ToList();
        }
    }
}