using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Models;
using Rhythm.BL.Models;
using System;

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

        internal object ToCommetRecentViewModel(List<RecentComment> comments)
        {
            throw new NotImplementedException();
        }
    }
}