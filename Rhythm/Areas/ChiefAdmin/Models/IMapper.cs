using System;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public interface IMapperCategory
    {
        object Map(object source, Type sourceType, Type destinationType);

    }
    public interface IMapperTag
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
