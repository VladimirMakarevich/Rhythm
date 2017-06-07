using Rhythm.Domain.Repository;

namespace Rhythm.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        CategoryRepository Category { get; }
        PostRepository Post { get; }
        UserRepository User { get; }
        TagRepository Tag { get; }
        RssRepository Rss { get; }
        PortfolioRepository Portfolio { get; }
        CommentRepository Comment { get; }
        ProjectRepository Project { get; }
        void Save();
    }
}
