using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Core;
using Windows.Storage;
using SQLitePCL;

namespace ToxRt.Model
{
    public class DataService : IDataService
    {
        #region Fields
        private readonly SQLiteConnection _connection = new SQLiteConnection("tox_messages.db"); //tmp        
        #endregion
        #region Properties

        #endregion
        #region Ctors and Methods
        public async Task<List<Message>> GetMessagesByFriendId(int friendId)
        {
            var messeges = new List<Message>();
            using (var statement = _connection.Prepare("SELECT * FROM MESSAGES WHERE SenderID= ?"))
            {
                statement.Bind(1, friendId);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    messeges.Add(new Message()
                    {
                        MessageId = int.Parse(statement[0].ToString()),
                        Sender = GetFriendByFriendId((int)statement[1]),
                        MessageText = (string)statement[2],
                        MessageDate = DateTime.Parse(statement[3].ToString())
                    });
                }
            }
            return messeges;
        }

        private Friend GetFriendByFriendId(int friendId)
        {
            var friend = new Friend();
            using (var statement = _connection.Prepare("SELECT * FROM FRIENDS WHERE FriendId = ?"))
            {
                statement.Bind(1, friendId);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    friend.FriendId = int.Parse(statement[0].ToString());
                    friend.ScreenName = (string)statement[1];
                    friend.StatusMessage = (string)statement[2];
                }
            }
            return friend;
        }

        public async Task<List<Friend>> GetCurrentProfileFriends(int profileId)
        {
            var friends = new List<Friend>();
            using (var statement = _connection.Prepare("SELECT * FROM FRIENDS WHERE ProfileId= ?")) //tmp
            {
                statement.Bind(1, profileId);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    friends.Add(new Friend()
                    {
                        FriendId = int.Parse(statement[0].ToString()),
                        ScreenName = (string)statement[1],
                        StatusMessage = (string)statement[2],
                        ToxId = (string)statement[3],
                        ProfileId = int.Parse(statement[4].ToString())

                    });
                }
            }
            return friends;
        }

        public Profile GetProfileByProfileId(int profileId)
        {
            var profile = new Profile();
            using (var statement = _connection.Prepare("SELECT * FROM PROFILES WHERE FriendId = ?"))
            {
                statement.Bind(1, profileId);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    profile.FriendId = int.Parse(statement[0].ToString());
                    profile.ScreenName = (string)statement[1];
                    profile.StatusMessage = (string)statement[2];
                    profile.ToxId = (string)statement[3];
                    profile.ProfileLanguage = (string)statement[4];
                    profile.ProfileTheme = (string)statement[5];
                    profile.AudioNotifications = int.Parse(statement[6].ToString());
                    profile.CloseToTray = int.Parse(statement[7].ToString());
                    profile.IsDefault = int.Parse(statement[8].ToString());
                    profile.ProfileName = (string)statement[9];    //used to load profile
                }
            }
            return profile;
        }

        public Profile GetDefaultProfile()
        {
            var profile = new Profile();
            using (var statement = _connection.Prepare("SELECT * FROM PROFILES WHERE IsDefault = 1")) //1 is true
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    profile = new Profile();
                    var a = int.Parse(statement[0].ToString());
                    profile.FriendId = int.Parse(statement[0].ToString());
                    profile.ScreenName = (string)statement[1];
                    profile.StatusMessage = (string)statement[2];
                    profile.ToxId = (string)statement[3];
                    profile.ProfileLanguage = (string)statement[4];
                    profile.ProfileTheme = (string)statement[5];
                    profile.AudioNotifications = int.Parse(statement[6].ToString());
                    profile.CloseToTray = int.Parse(statement[7].ToString());
                    profile.IsDefault = int.Parse(statement[8].ToString());
                    profile.ProfileName = (string)statement[9];    //used to load profile
                }
                else
                {
                    return null;  //no profile is created yet
                }
            }
            return profile;
        }

        public void InsertNewProfile(Profile profile)
        {
            using (var statement = _connection.Prepare(@"INSERT INTO PROFILES ( ScreenName,StatusMessage,ToxId,Language,Theme,AudioNotifications,CloseToTray,IsDefault,ProfileName)
                                            VALUES( @ScreenName,@StatusMessage,@ToxId,@Language,@Theme,@AudioNotifications,@CloseToTray,@IsDefault,@ProfileName);"))
            {
                statement.Bind("@ScreenName", profile.ScreenName);
                statement.Bind("@StatusMessage", profile.StatusMessage);
                statement.Bind("@ToxId", profile.ToxId);
                statement.Bind("@Language", profile.ProfileLanguage);
                statement.Bind("@Theme", profile.ProfileTheme);
                statement.Bind("@AudioNotifications", profile.AudioNotifications);
                statement.Bind("@CloseToTray", profile.CloseToTray);
                statement.Bind("@IsDefault", profile.IsDefault);
                statement.Bind("@ProfileName", profile.ProfileName);

                statement.Step();
            }
        }

        public void UpadteProfile(Profile profile)
        {
            using (
                var statement =
                    _connection.Prepare(
                        @"UPDATE PROFILES SET ScreenName=@ScreenName,StatusMessage=@StatusMessage,ToxId=@ToxId,Language=@Language,Theme=@Theme,
AudioNotifications=@AudioNotifications,CloseToTray=@CloseToTray,IsDefault=@IsDefault,ProfileName=@ProfileName WHERE ProfileId=@ProfileId;")
                )
            {
                statement.Bind("@ScreenName", profile.ScreenName);
                statement.Bind("@StatusMessage", profile.StatusMessage);
                statement.Bind("@ToxId", profile.ToxId);
                statement.Bind("@Language", profile.ProfileLanguage);
                statement.Bind("@Theme", profile.ProfileTheme);
                statement.Bind("@AudioNotifications", profile.AudioNotifications);
                statement.Bind("@CloseToTray", profile.CloseToTray);
                statement.Bind("@IsDefault", profile.IsDefault);
                statement.Bind("@ProfileName", profile.ProfileName);
                statement.Bind("@ProfileId", profile.ProfileId);

                statement.Step();
            }

        }

        public async Task<List<DHT_Node>> LoadAllDhtNodes()
        {
            var nodes = new List<DHT_Node>();
            using (var statement = _connection.Prepare("SELECT * FROM DHT_Nodes"))  //i might want to load only "UP" ones 
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    nodes.Add(new DHT_Node()
                    {
                        NodeId = int.Parse(statement[0].ToString()),
                        Ipv4 = (string)statement[1],
                        IpV6 = (string)statement[2],
                        Port = int.Parse(statement[3].ToString()),
                        ClientId = (string)statement[4],
                        Maintainer = (string)statement[5],
                        Location = (string)statement[6],
                        Status = (string)statement[7]
                    });
                }
            }
            return nodes;
        }

        public void AddFriendRequest(FriendRequest request)
        {
            using (var statement = _connection.Prepare(@"INSERT INTO FriendRequest ( ToxId,Message) VALUES ( @ToxId,@Message);"))
            {
                statement.Bind("@ToxId", request.ToxId);
                statement.Bind("@Message", request.RequestMessage);
                statement.Step();
            }
        }

        public async Task<List<FriendRequest>> GetAllFriendRequest()
        {
            var requests = new List<FriendRequest>();
            using (var statement = _connection.Prepare("SELECT * FROM FriendRequest"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    requests.Add(new FriendRequest()
                    {
                        FriendRequestId = int.Parse(statement[0].ToString()),
                        ToxId = (string)statement[1].ToString(),
                        RequestMessage = (string)statement[2]
                    });
                }
            }
            return requests;
        }

        public void RemoveFriendRequest(string friendRequestId)
        {
            using (var statement = _connection.Prepare("DELETE FROM FriendRequest WHERE ToxId = ?"))
            {
                statement.Bind(1, friendRequestId);
                statement.Step();
            }
        }

        public void RemoveAllFriendRequest()
        {
            using (var statement = _connection.Prepare("DELETE FROM FriendRequest"))
            {
                statement.Step();
            }
        }

        public bool FriendRequestExists(string friendRequestId)
        {
            using (var statement = _connection.Prepare("SELECT * FROM FriendRequest WHERE ToxId = ?"))
            {
                statement.Bind(1, friendRequestId);
                if (statement.Step() == SQLiteResult.EMPTY)
                {
                    statement.Dispose();
                    return false;
                }
            }
            return true;
        }

        public FriendRequest GetFriendRequestById(int friendRequestId)
        {
            var request = new FriendRequest();
            using (var statement = _connection.Prepare("SELECT * FROM FriendRequest WHERE RequestId = ?"))
            {
                statement.Bind(1, friendRequestId);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    request.FriendRequestId = int.Parse(statement[0].ToString());
                    request.ToxId = statement[1].ToString();
                    request.RequestMessage = (string)statement[2];
                }
            }
            return request;
        }

        #endregion

    }
}
