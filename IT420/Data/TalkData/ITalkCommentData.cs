using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public interface ITalkCommentData
    {
        IEnumerable<TalkComment> GetAll(int talkId);
        TalkComment GetById(int commentId);
        void Add(TalkComment newComment);
        void Update(TalkComment updatedComment);
        void Delete(TalkComment comment);
        Task<bool> Commit();
    }
}
