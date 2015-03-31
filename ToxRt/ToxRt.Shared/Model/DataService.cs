using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace ToxRt.Model
{
    public class DataService:IDataService
    {
        #region Fields
        private readonly SQLiteConnection _connection = new SQLiteConnection(@"\Data\tox_messages.sqlite"); //tmp
        #endregion
        #region Properties

        #endregion
        #region Ctors and Methods
        public async Task<List<Message>> GetMessagesByFriendId(long friendId)
        {
            var messeges = new List<Message>();
            using (var statement = _connection.Prepare("SELECT * FROM MESSAGES WHERE SenderID= ?")) //tmp
            {
                statement.Bind(1, friendId);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    messeges.Add(new Message()
                    {
                        MessageId = (int)statement[0],
                        Sender = GetFriendByFriendId((long)statement[1]),
                        MessageText = (string)statement[2],
                        MessageDate = (DateTime)statement[0]
                    });
                }
            }
            return messeges;
        }

        private Friend GetFriendByFriendId(long friendId)
        {
            var friend = new Friend();
            using (var statement = _connection.Prepare("SELECT * FROM FRIENDS WHERE FriendId = ?"))
            {
                statement.Bind(1, friendId);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    friend.FriendId = (int)statement[0];
                    friend.ScreenName = (string)statement[1];
                    friend.StatusMessage = (string)statement[2];
                }
            }
            return friend;
        }

        public async Task<List<Friend>> GetCurrentProfileFriends(long profileId)
        {
            var friends = new List<Friend>();
            using (var statement = _connection.Prepare("SELECT * FROM FRIENDS WHERE ProfileId= ?")) //tmp
            {
                statement.Bind(1, profileId);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    friends.Add(new Friend()
                    {
                        FriendId = (int)statement[0],
                        ScreenName = (string)statement[1],
                        StatusMessage = (string)statement[2],
                        ToxId = (string)statement[3],
                        ProfileId = (int)statement[4]

                    });
                }
            }
            return friends;
        }

        public Profile GetProfileByProfileId(long profileId)
        {
            var profile = new Profile();
            using (var statement = _connection.Prepare("SELECT * FROM PROFILES WHERE FriendId = ?"))
            {
                statement.Bind(1, profileId);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    profile.FriendId = (int)statement[0];
                    profile.ScreenName = (string)statement[1];
                    profile.StatusMessage = (string)statement[2];
                    // ... fill the navigation collections 
                }
            }
            return profile;
        }
        #endregion
       
    }
}
