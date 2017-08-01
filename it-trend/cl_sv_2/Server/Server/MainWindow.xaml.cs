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
using System.Collections;

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    enum Command
    {
        Login,      
        Logout,     
        Message,    
        List,       
        Null       
    }



    public partial class MainWindow : Window
    {
        struct ClientInfo
        {
            public Socket socket;   
            public string strName;  
        }

        ArrayList clientList;
        Socket serverSocket;

        byte[] byteData = new byte[1024];
        public static int allData = 0;
        public void PlusData(int message)
        {
            allData += message;

            alldata.Dispatcher.BeginInvoke(new Action(delegate () {
                alldata.Content = allData.ToString() + " бит";
            }));
         
        }
        public MainWindow()
        {
            clientList = new ArrayList();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Stream,
                                         ProtocolType.Tcp);

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1000);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(4);
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
        }
        private void OnAccept(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(OnReceive), clientSocket);
        }

        private void OnReceive(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.EndReceive(ar);
            Data msgReceived = new Data(byteData);
            Data msgToSend = new Data();

            byte[] message;
            msgToSend.cmdCommand = msgReceived.cmdCommand;
            msgToSend.strName = msgReceived.strName;

            switch (msgReceived.cmdCommand)
            {
                case Command.Login:
                   
                    ClientInfo clientInfo = new ClientInfo();
                    clientInfo.socket = clientSocket;
                    clientInfo.strName = msgReceived.strName;

                    clientList.Add(clientInfo);

                   
                    msgToSend.strMessage = msgReceived.strName + " присоединился к чату";
                    break;

                case Command.Logout:
                    int nIndex = 0;
                    foreach (ClientInfo client in clientList)
                    {
                        if (client.socket == clientSocket)
                        {
                            clientList.RemoveAt(nIndex);
                            break;
                        }
                        ++nIndex;
                    }

                    clientSocket.Close();

                    msgToSend.strMessage = msgReceived.strName + " ушел из чата";
                    break;

                case Command.Message:

                    if(msgReceived.strMessage == "<BYTE>")
                    {
                        msgToSend.strMessage = "<BYTE>" + ": " + allData.ToString();
                    }
                    else
                        msgToSend.strMessage = msgReceived.strName + ": " + msgReceived.strMessage;
                    break;

                case Command.List:

                    msgToSend.cmdCommand = Command.List;
                    msgToSend.strName = null;
                    msgToSend.strMessage = null;

                    foreach (ClientInfo client in clientList)
                    {
                        msgToSend.strMessage += client.strName + "*";
                    }

                    message = msgToSend.ToByte();
                   
                    clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                            new AsyncCallback(OnSend), clientSocket);
                    break;
            }

            if (msgToSend.cmdCommand != Command.List)   
            {
                message = msgToSend.ToByte();

                foreach (ClientInfo clientInfo in clientList)
                {
                    if (clientInfo.socket != clientSocket ||
                        msgToSend.cmdCommand != Command.Login)
                    {
                        clientInfo.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                            new AsyncCallback(OnSend), clientInfo.socket);
                    }
                }
                txtLog.Dispatcher.BeginInvoke(new Action(delegate () {
                    txtLog.Items.Add(msgToSend.strMessage);
                    PlusData(message.Length);
                }));


                
            }
            if (msgReceived.cmdCommand != Command.Logout)
            {
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
            }
        }
        public void OnSend(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.EndSend(ar);
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
