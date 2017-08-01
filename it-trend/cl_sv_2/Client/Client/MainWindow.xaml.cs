using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;


namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Null        //No command
    }
    public partial class MainWindow : Window
    {
        public Socket clientSocket;
        public string strName;
        private byte[] byteData = new byte[1024];
        public static bool conn = true;

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            strName = NameClient.Text;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry ipHost = Dns.Resolve("127.0.0.1");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 1000);

            clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);

            Log.Visibility = Visibility.Hidden;
            
        }
        private void OnConnect(IAsyncResult ar)
        {
            clientSocket.EndConnect(ar);

            Data msgToSend = new Data();
            msgToSend.cmdCommand = Command.Login;
            NameClient.Dispatcher.BeginInvoke(new Action(delegate () {
                msgToSend.strName = NameClient.Text;
            }));
           
            msgToSend.strMessage = null;

            byte[] b = msgToSend.ToByte();

            clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
        }
        private void OnSend(IAsyncResult ar)
        {
            clientSocket.EndSend(ar);
            if (conn)
            {
               
                Load();
                conn = false;
            }
        }








        public MainWindow()
        {
            InitializeComponent();
            Log.Visibility = Visibility.Visible;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Data msgToSend = new Data();

            msgToSend.strName = strName;
            msgToSend.strMessage = txtMessage.Text;
            msgToSend.cmdCommand = Command.Message;

            byte[] byteData = msgToSend.ToByte();

            clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

            txtMessage.Text = null;
        }
        private void OnReceive(IAsyncResult ar)
        {
            clientSocket.EndReceive(ar);

            Data msgReceived = new Data(byteData);
            switch (msgReceived.cmdCommand)
            {
                case Command.Message:
                    break;
                case Command.List:
                    txtChatBox.Dispatcher.BeginInvoke(new Action(delegate () {
                        txtChatBox.Items.Add(strName + " присоединился к чату");
                    }));                    
                    break;
            }

            if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
                txtChatBox.Dispatcher.BeginInvoke(new Action(delegate () {
                    string[] a = msgReceived.strMessage.Split(':');
                    if (a[0].Trim() == "<BYTE>")
                    {
                        bytedata.Content = "Объем данных: " + a[1] + " байт";
                    }
                    else 
                    txtChatBox.Items.Add(msgReceived.strMessage);
                }));

            byteData = new byte[1024];
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }
        private void Load()
        {
            Data msgToSend = new Data();
            msgToSend.cmdCommand = Command.List;
            msgToSend.strName = strName;
            msgToSend.strMessage = null;

            byteData = msgToSend.ToByte();

            clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

            byteData = new byte[1024];
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtMessage.Text != null)
            {
                Send_Click(sender, null);
            }
        }

        private void Vis_data_Click(object sender, RoutedEventArgs e)
        {
            Data msgToSend = new Data();

            msgToSend.strName = strName;
            msgToSend.strMessage = "<BYTE>";
            msgToSend.cmdCommand = Command.Message;

            byte[] byteData = msgToSend.ToByte();

            clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
        }
    }




    class Data
    {        
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }
        
        public Data(byte[] data)
        {
            
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);
            
            int nameLen = BitConverter.ToInt32(data, 4);
           
            int msgLen = BitConverter.ToInt32(data, 8);
            
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;
           
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }
        
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();
            
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));
           
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));
           
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));
            
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));
            
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      
        public string strMessage;  
        public Command cmdCommand;  
    }
}
