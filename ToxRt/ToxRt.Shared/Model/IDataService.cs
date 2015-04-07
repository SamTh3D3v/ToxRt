using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToxRt.Model
{
    public interface IDataService
    {
        //geters
        Task<List<Message>> GetMessagesByFriendId(int friendId);
        Task<List<Friend>> GetCurrentProfileFriends(int profileId);
        Profile GetProfileByProfileId(int profileId);
        Profile GetDefaultProfile();
        void InsertNewProfile(Profile profile);
        void UpadteProfile(Profile profile);
        Task<List<DHT_Node>> LoadAllDhtNodes();
    }
}
