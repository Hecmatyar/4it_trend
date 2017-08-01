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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteBase;
using System.Collections;
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Chat obj;
        internal int key = 0;
        internal string yourName;
        internal int yourSymbol;
        //ArrayList alOnlineUser = new ArrayList();
        //ArrayList allOnlineText = new ArrayList();

        private DispatcherTimer tmr = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            HelloGrid.Visibility = System.Windows.Visibility.Visible;
            MessegeGrid.Visibility = System.Windows.Visibility.Hidden;
            tmr.Interval = new TimeSpan(0, 0, 0,1);
            tmr.Tick += new EventHandler(timer1_Tick);
            tmr.Tick += new EventHandler(timer2);
            tmr.Start();
        }        
        private void timer2(object send, EventArgs e)
        {

        }
        int skipCounter = 4;
        StackPanel mystack = new StackPanel();
        private void timer1_Tick(object sender, EventArgs e)
        {                        
            if (obj != null)
            {
                //паараметры моего стека
                mystack.Width = 480;
                mystack.HorizontalAlignment = HorizontalAlignment.Center;
                mystack.VerticalAlignment = VerticalAlignment.Bottom;


                RemoteBase.Chat.userMsg tempStr = (RemoteBase.Chat.userMsg)(obj.GetMsgFromSvr(key));
                if (tempStr.msg.Length > 0)
                {
                    key++;
                    //заполнение  
                    Grid message_grid = new Grid();
                    message_grid.Width = 374;
                    message_grid.RenderTransformOrigin = new Point(10, 10);

                    Color mycolor = new Color();
                    mycolor = Color.FromRgb(226,231,241);
                    SolidColorBrush brush = new SolidColorBrush(mycolor);

                    Color mycolor1 = new Color();
                    mycolor1 = Color.FromRgb(255, 239, 239);
                    SolidColorBrush brush1 = new SolidColorBrush(mycolor1);

                    Color mycolor2 = new Color();
                    mycolor2 = Color.FromRgb(31, 74, 95);
                    SolidColorBrush brush2 = new SolidColorBrush(mycolor2);
                    mycolor2 = Color.FromRgb(106, 8, 8);
                    SolidColorBrush brush3 = new SolidColorBrush(mycolor2);

                    //имя отправителя
                    Label nameclient = new Label();
                    nameclient.Content = tempStr.name + ":";
                    nameclient.FontFamily = new System.Windows.Media.FontFamily("Segoe UI");
                   
                    nameclient.FontSize = 16.0;
                    //текст сообщения
                    TextBlock textclient = new TextBlock();
                    textclient.Text = tempStr.msg;
                    textclient.FontFamily = new System.Windows.Media.FontFamily("Segoe UI");
                    textclient.TextWrapping = TextWrapping.Wrap;
                    textclient.FontSize = 14.0;

                    StackPanel mess = new StackPanel();

                    Grid b = new Grid();
                    b.Height = 10;
                    b.Width = 400;                   
                    mess.Width = 350;                    
                    mess.Children.Add(nameclient);
                    mess.Children.Add(textclient);
                   
                    if (tempStr.name == yourName)
                    {
                        message_grid.Background = brush;                        
                        message_grid.HorizontalAlignment = HorizontalAlignment.Right;
                        nameclient.Foreground = brush2;
                        textclient.Foreground = brush2;
                    }
                    else
                    {
                        message_grid.Background = brush1;                        
                        message_grid.HorizontalAlignment = HorizontalAlignment.Left;
                        nameclient.Foreground = brush3;
                        textclient.Foreground = brush3;
                    }                    
                    message_grid.Children.Add(mess);
                    mystack.Children.Add(b);
                    mystack.Children.Add(message_grid);
                    
                    Scroll.Content = mystack;
                    
                    
                }

                //ArrayList allOnlineText = obj.OnlineText();
                //listBox.ItemsSource = allOnlineText;


                ArrayList onlineUser = obj.OnlineUsers();
                label.Content = onlineUser.Count.ToString();
                skipCounter = 0;
                //проверка количества человек

                if (onlineUser.Count < 2)
                {
                    textBox1.Text = "Подождите второго пользователя!";
                    textBox1.IsEnabled = false;
                }
                else if (textBox1.Text == "Подождите второго пользователя!" && textBox1.IsEnabled == false)
                {
                    textBox1.Text = "";
                    textBox1.IsEnabled = true;
                }
            }
        }
        private void SendMessage()
        {
            if (obj != null && textBox1.Text.Trim().Length>0)
            {
                obj.SendMsgToSvr(yourSymbol,yourName,textBox1.Text);
                textBox1.Text = "";
            }
        }
        struct userMsg
        {
            public int num;
            public string name;
            public string msg;
        }
        
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimaze_Window(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            //отправить на сервер инфу, что мы закрываемся 
            //и уменьшить число пользователей
            if (obj != null)
            {
                obj.LeaveChat(yourSymbol, yourName);
                textBox1.Text = "";
            }
            Close();
        }
        //удаление теста при наведении мышки
        public bool ismouse = false;
        private void textBox_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            textBox1.Text = "";          
            ismouse = true;
            //if (obj != null)
            //{
            //    obj.IsChangesText(yourName);
            //    textBox1.Text = "";
            //}           
        }
        private void textBox1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите ваше сообщение";
            }
            ismouse = false;
            //if (obj != null)
            //    obj.LeaveChangesText(yourName);
           
        }
        //переход к чату
        TcpChannel chan;
        private void label1_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterToChat();           
        }
        private void EnterToChat()
        {
            if (chan == null && textBox.Text.Trim().Length != 0)
            {
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan, false);
                obj = (Chat)Activator.GetObject(typeof(RemoteBase.Chat), "tcp://192.168.50.101:8080/ChatRoom");

                if (!obj.EnterToChat(textBox.Text, ref yourSymbol))
                {
                    MessageBox.Show(textBox.Text + " - такое имя уже занято, введите другое!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    
                    return;
                }
                key = obj.CurrentKey();
                yourName = textBox.Text;
                HelloGrid.Visibility = System.Windows.Visibility.Hidden;
                MessegeGrid.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void button1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SendMessage();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }
        
       
    }
}
