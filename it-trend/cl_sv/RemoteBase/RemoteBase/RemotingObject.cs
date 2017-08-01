using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;


namespace RemoteBase
{
    /// <remarks>
    /// Sample object to demonstrate the use of .NET Remoting.
    /// </remarks>
    public class Chat : MarshalByRefObject
    {
       
        Hashtable ht=new Hashtable ();
        ArrayList allOnlineUser = new ArrayList();
        private int key = 0;
        private int userNo = 0;
        user a = new user();
        public bool EnterToChat(string name,ref int num)
        {
            if (allOnlineUser.IndexOf(name) > -1)
                return false;
            else
            {
                //userNo++;
                a.name = name;
                num = ++userNo;
                allOnlineUser.Add(a.name);
                SendMsgToSvr(num, name ," подключился к чату");
                return true;
            }
            
        }
        public void LeaveChat(int num,string name)
        {
            allOnlineUser.Remove(name);
            SendMsgToSvr(num, name, " ушел из чата");
        }
        public ArrayList OnlineUsers()
        {
            return allOnlineUser;
        }

        public int CurrentKey()
        {
            return key;
        }
        public void SendMsgToSvr(int num,string name,string chatMsgFromUsr)
        {
            //chatMsg = chatMsgFromUsr;
            userMsg ab = new userMsg();
            ab.num = num;
            ab.name = name;
            ab.msg = chatMsgFromUsr;
            ht.Add(++key, ab);
        }
        public userMsg GetMsgFromSvr(int lastKey)
        {
            if (key > lastKey)
                return (userMsg)ht[lastKey + 1];
            else
            {
                userMsg ab = new userMsg();
                ab.num = 0;
                ab.name ="";
                ab.msg = "";
                return ab;
            }
        }
        [Serializable()]
        public struct userMsg
        {
            public int num;
            public string name;
            public string msg;
        }
        [Serializable()]
        struct user
        {
            public int num;
            public string name;
        }
    }
}
