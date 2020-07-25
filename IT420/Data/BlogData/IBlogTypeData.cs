using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.BlogData
{
    public interface IBlogTypeData
    {
        IEnumerable<BlogType> GetAll();
        BlogType GetType(int typeId);
        BlogType Update(BlogType updatedType);
        BlogType Add(BlogType newType);
        Task<bool> Commit();
    }
}
