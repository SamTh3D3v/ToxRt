﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLitePCL;

namespace ToxRt.Model
{
    public class DataService:IDataService
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
                        MessageId = (int)statement[0],
                        Sender = GetFriendByFriendId((int)statement[1]),
                        MessageText = (string)statement[2],
                        MessageDate = (DateTime)statement[3]
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
                    friend.FriendId = (int)statement[0];
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

        public Profile GetProfileByProfileId(int profileId)
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
                    profile.ToxId = (string)statement[3];
                    profile.ProfileLanguage = (string)statement[4];
                    profile.ProfileTheme = (string)statement[5];
                    profile.AudioNotifications = (int)statement[6];
                    profile.CloseToTray = (int)statement[7];
                    profile.IsDefault = (int)statement[8];
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
                    var a =  int.Parse(statement[0].ToString());
                    profile.FriendId = int.Parse(statement[0].ToString());
                    profile.ScreenName = (string)statement[1];
                    profile.StatusMessage = (string)statement[2];
                    profile.ToxId = (string)statement[3];
                    profile.ProfileLanguage = (string)statement[4];
                    profile.ProfileTheme = (string)statement[5];
                    profile.AudioNotifications = int.Parse(statement[6].ToString());
                    profile.CloseToTray = int.Parse(statement[7].ToString());
                    profile.IsDefault =int.Parse(statement[8].ToString());
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

        #endregion
       
    }
}
