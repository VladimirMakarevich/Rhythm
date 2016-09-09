using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;


namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository : IRepository
    {
        private DogCodingEntities context = new DogCodingEntities();

    }
}
