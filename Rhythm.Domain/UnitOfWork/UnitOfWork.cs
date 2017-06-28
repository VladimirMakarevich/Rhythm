using System;
using Rhythm.Domain.Repository;
using Rhythm.Domain.Context;
using System.Threading.Tasks;

namespace Rhythm.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DogCodingContext _db;
        private CategoryRepository _categoryRepository;
        private PostRepository _postRepository;
        private UserRepository _userRepository;
        private TagRepository _tagRepository;
        private RssRepository _rssRepository;
        private PortfolioRepository _portfolioRepository;
        private CommentRepository _commentRepository;
        private ProjectRepository _projectRepository;

        public UnitOfWork(DogCodingContext db)
        {
            _db = db;
        }
        public UnitOfWork()
        {
            _db = new DogCodingContext();
        }

        public CategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_db);

                return _categoryRepository;
            }
        }

        public CommentRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_db);

                return _commentRepository;
            }
        }

        public PortfolioRepository Portfolio
        {
            get
            {
                if (_portfolioRepository == null)
                    _portfolioRepository = new PortfolioRepository(_db);

                return _portfolioRepository;
            }
        }

        public PostRepository Post
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_db);

                return _postRepository;
            }
        }

        public RssRepository Rss
        {
            get
            {
                if (_rssRepository == null)
                    _rssRepository = new RssRepository(_db);

                return _rssRepository;
            }
        }

        public TagRepository Tag
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_db);

                return _tagRepository;
            }
        }

        public UserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);

                return _userRepository;
            }
        }

        public ProjectRepository Project
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_db);

                return _projectRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
            Dispose();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
