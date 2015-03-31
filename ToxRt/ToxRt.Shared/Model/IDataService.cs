using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToxRt.Model
{
    public interface IDataService
    {
        //geters
        Task<List<Message>> GetMessagesByFriendId(long friendId);
        Task<List<Friend>> GetCurrentProfileFriends(long profileId);
        Profile GetProfileByProfileId(long profileId);
    }
}
