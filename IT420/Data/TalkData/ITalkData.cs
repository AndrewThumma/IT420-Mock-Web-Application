using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public interface ITalkData
    {
        IEnumerable<Talk> GetTalksByType(int typeId);
        IEnumerable<Talk> GetTalksByName(string searchTerm, int typeId);
        Talk GetNewest();
        Talk GetTalkById(int talkId);
        void Add(Talk newTalk);
        void Update(Talk updatedTalk);
        void Delete(Talk talk);
        Task<bool> Commit();
    }
}
