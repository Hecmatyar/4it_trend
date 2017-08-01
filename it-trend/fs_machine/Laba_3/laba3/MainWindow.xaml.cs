using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace laba3
{
    class MyStack
    {
        List<string> stack = new List<string>();
        public int Count
        {
            get { return stack.Count; }
        }

        public string ToSrting()
        {
            string temp = "";
            foreach (string ch in stack)
            {
                temp += ch;
            }
            return temp;
        }

        public string ToSrtingReverse()
        {
            string temp = "";
            foreach (string ch in stack)
            {
                temp = ch + temp;
            }
            return temp;
        }
        public void Push(string item)
        {
            stack.Add(item);
        }

        public string Pop()
        {
            string temp = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return temp;
        }

        public string Peek()
        {
            return stack[stack.Count - 1];
        }

        public void Reverse()
        {
            stack.Reverse();
        }

        public string GetItem(int item)
        {
            return stack[item];
        }
    } // Стек, реализованный через анальное отверстие

    class Rules
    {
        List<List<string>> RuleList = new List<List<string>>();
        //Заполнение  правил вывода
        public Rules()
        {
            FillRules();
        }

        public void Replace(string str1, string str2)
        {
            for (int i = 0; i < RuleList.Count; i++)
                for (int j = 0; j < RuleList[i].Count; j++)
                    if (RuleList[i][j] == str1)
                        RuleList[i][j] = str2;
        }

        void FillRules()
        {
            RuleList.Add("S a = F".Split(' ').ToList<string>());
            RuleList.Add("F F + T".Split(' ').ToList<string>());
            RuleList.Add("F F - T".Split(' ').ToList<string>());
            RuleList.Add("F T".Split(' ').ToList<string>());
            RuleList.Add("T T * E".Split(' ').ToList<string>());
            RuleList.Add("T T / E".Split(' ').ToList<string>());
            RuleList.Add("T E".Split(' ').ToList<string>());
            RuleList.Add("E ( F )".Split(' ').ToList<string>());
            RuleList.Add("E a".Split(' ').ToList<string>());     //а - идентификатор или римское число   
        }
        public int GetRulesLeft(List<string> ruleIn)
        {
            int i = 0;
            foreach (List<string> rule in GetRulesRight())
                if (rule.SequenceEqual(ruleIn))
                    return i;
                else
                    i++;

            return -1;
        }

        public List<List<string>> GetRulesRight()
        {
            List<List<string>> rulesRight = new List<List<string>>();

            foreach (List<string> rule in RuleList)
            {
                List<string> temp = new List<string>(rule);
                temp.RemoveAt(0);
                rulesRight.Add(temp);
            }

            return rulesRight;
        }
        // левые
        public List<string> LeftSymbols(string ch)
        {
            List<string> list = new List<string>();

            foreach(List<string> a in RuleList)
                if (a[0]==ch)
                    if (!list.Contains(a[1]))
                        list.Add(a[1]);
            return list;
        }
        //правые
        public List<string> RightSymbols(string ch)
        {
            List<string> list = new List<string>();

            foreach (List<string> a in RuleList)
                if (a[0] == ch)
                    if (!list.Contains(a[a.Count-1]))
                        list.Add(a[a.Count - 1]);
            return list;
        }

        //крайние нетерминалы
        public List<string> LeftTerminalSymbols(string chr, List<string> terminal)
        {
            List<string> list = new List<string>();

            foreach (List<string> rule in RuleList)
                if (rule[0] == chr)
                    for (int i = 1; i < rule.Count; i++) 
                        if (terminal.Contains(rule[i]))
                        {
                            if (!list.Contains(rule[i]))
                                list.Add(rule[i]);
                            break;
                        }
            return list;
        }

        //правые
        public List<string> RightTerminalSymbols(string ch, List<string> terminal)
        {
            List<string> list = new List<string>();
            foreach (List<string> rule in RuleList)
                if (rule[0] == ch)
                {
                    List<string> mass = new List<string>(rule);
                    mass.RemoveAt(0);
                    mass.Reverse();

                    for (int i = 0; i < mass.Count; i++)
                        if (terminal.Contains(mass[i]))
                        {
                            if (!list.Contains(mass[i]))
                            {
                                list.Add(mass[i]);
                            }
                            break;
                        }
                }
            return list;
        }

        public List<string> GetRuleRightId(int id)
        {
            List<string> temp = new List<string>(RuleList[id-1]);
            temp.RemoveAt(0);
            return temp;
        }

    } // Правила вывода

    class Node
    {
        public string Name { get; set; }
        public List<int> Childs = new List<int>();

        public Node(string name)
        {
            this.Name = name;
        }

    } // Вершина

    class Tree // Дерево
    {
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        int freeSpace = 0;

        string visualTreeString = "";

        public void addNode(Node node)
        {
            nodes[freeSpace] = node;
            freeSpace++;
        }

        public void addChilds(int id, List<Node> childList)
        {
            foreach(Node child in childList)
            {
                nodes[id].Childs.Add(freeSpace);
                nodes[freeSpace] = child;
                freeSpace++;

            }
        }

        public void printTree(int id, int deep)
        {
            int num = 1;
            foreach (int child in nodes[id].Childs)
            {
                for (int i = 0; i < deep; i++)
                    visualTreeString += "    ";


                if (num == deep - 1)
                    visualTreeString += "├───";
                else
                    visualTreeString += "└───";

                visualTreeString += nodes[child].Name + Environment.NewLine;
                printTree(child, deep + 1);
                num++;
            }
        }

        public string getStringTree()
        {
            printTree(0, 0);
            return visualTreeString;
        }
    }

    public partial class MainWindow : Window
    {
        #region Поля класса
        string start = "S"; // Начальный не терминал
        string startSymbol = "!S!"; // Начальный символ
        string endSymbol = "!E!"; // Конечный символ

        Tree tree = new Tree(); // Дерево вывода

        List<string> terminal = new List<string>{ "a", "=", "+", "*", "/", "(", ")", "-" };    //Мн-во терминальных символов
        List<string> no_terminal = new List<string>{ "S", "F", "T", "E" };

        Rules rules = new Rules(); // Правила грамматики
        Rules octovRules = new Rules(); // Оставные правила грамматики

        Dictionary<string, List<string>> LeftmostSymbols = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> RightmostSymbols = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> RightmostTerminalSymbols = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> LeftmostTerminalSymbols = new Dictionary<string, List<string>>();
        string[][] matrPred; // Матрица предшествования

        List<int> sequence; // Последовательность правил вывода
        #endregion

        #region Крайние символы
        public void Left_M()
        {
            foreach(string ch in no_terminal)
            {
                LeftmostSymbols[ch] = new List<string>();                
            }
            foreach(string a in LeftmostSymbols.Keys)
            {
                foreach(string str in rules.LeftSymbols(a))
                {
                    LeftmostSymbols[a].Add(str);
                }
            }
            //2 прогон
            foreach (string ch in LeftmostSymbols.Keys)
            { 
                int j = 0;
                int max = 1;
                var keys = LeftmostSymbols[ch].ToArray();
                while (j < max)
                {
                    string ad = keys[j];
                    if (no_terminal.Contains(ad))
                    {
                        foreach( string ad1 in rules.LeftSymbols(ad))
                        {
                            if (!LeftmostSymbols[ch].Contains(ad1))
                            {
                                LeftmostSymbols[ch].Add(ad1);
                            }
                        }
                    }
                    j++;
                    keys = LeftmostSymbols[ch].ToArray();
                    max = keys.Count();
                }
            }
            LexemTable.Text += "Крайние левые символы" + Environment.NewLine;
            foreach (string a in LeftmostSymbols.Keys)
            {
                LexemTable.Text += a + " : ";
                foreach (string ch in LeftmostSymbols[a])
                    LexemTable.Text += ch + " ";
                LexemTable.Text += Environment.NewLine;                
            }
            LexemTable.Text += Environment.NewLine;
        }

        public void Right_M()
        {
            foreach (string ch in no_terminal)
            {
                RightmostSymbols[ch] = new List<string>();
            }
            foreach (string a in RightmostSymbols.Keys)
            {
                foreach (string str in rules.RightSymbols(a))
                {
                    RightmostSymbols[a].Add(str);
                }
            }
            //2 прогон
            foreach(string ch in RightmostSymbols.Keys)
            { 
                int j = 0;
                int max = 1;
                var keys = RightmostSymbols[ch].ToArray();
                while (j < max)
                {
                    string ad = keys[j];
                    j++;
                    if (no_terminal.Contains(ad))
                    {
                        foreach (string ad1 in rules.RightSymbols(ad))
                        {
                            if (!RightmostSymbols[ch].Contains(ad1))
                            {
                                RightmostSymbols[ch].Add(ad1);
                            }
                        }
                    }
                    keys = RightmostSymbols[ch].ToArray();
                    max = keys.Count();
                }
            }
            LexemTable.Text += "Крайние правые символы" + Environment.NewLine;
            foreach (string a in RightmostSymbols.Keys)
            {                
                LexemTable.Text += a + " : ";
                foreach (string ch in RightmostSymbols[a])
                    LexemTable.Text += ch + " ";
                LexemTable.Text += Environment.NewLine;
            }
            LexemTable.Text += Environment.NewLine;
        }
        #endregion

        #region Крайние терминальные символы
        public void RightTerm()
        {
            foreach (string ch in no_terminal)
            {
                RightmostTerminalSymbols[ch] = new List<string>();
            }

            foreach (string a in RightmostTerminalSymbols.Keys)
            {
                foreach (string str in rules.RightTerminalSymbols(a,terminal))
                {
                    RightmostTerminalSymbols[a].Add(str);
                }
            }
            //2 прогон
            foreach (string ch in RightmostTerminalSymbols.Keys)
            {
                foreach(string symbol in RightmostSymbols[ch])
                {
                    if (no_terminal.Contains(symbol))
                    {
                        foreach(string symbol2 in rules.RightTerminalSymbols(symbol, terminal))
                        {
                            if (!RightmostTerminalSymbols[ch].Contains(symbol2)) { RightmostTerminalSymbols[ch].Add(symbol2); }
                        }
                    }
                }
            }
            LexemTable.Text += "Крайние правые терминальные символы" + Environment.NewLine;
            foreach (string a in RightmostTerminalSymbols.Keys)
            {
                LexemTable.Text += a + " : ";
                foreach (string ch in RightmostTerminalSymbols[a])
                    LexemTable.Text += ch + " ";
                LexemTable.Text += Environment.NewLine;
            }
            LexemTable.Text += Environment.NewLine;
        }

        public void LeftTerm()
        {
            foreach (string ch in no_terminal)
            {
                LeftmostTerminalSymbols[ch] = new List<string>();
            }

            foreach (string a in LeftmostTerminalSymbols.Keys)
            {
                foreach (string str in rules.LeftTerminalSymbols(a, terminal))
                {
                    LeftmostTerminalSymbols[a].Add(str);
                }
            }
            //2 прогон
            foreach (string ch in LeftmostTerminalSymbols.Keys)
            {
                foreach (string symbol in LeftmostSymbols[ch])
                {
                    if (no_terminal.Contains(symbol))
                    {
                        foreach (string symbol2 in rules.LeftTerminalSymbols(symbol, terminal))
                        {
                            if (!LeftmostTerminalSymbols[ch].Contains(symbol2)) { LeftmostTerminalSymbols[ch].Add(symbol2); }
                        }
                    }
                }
            }
            LexemTable.Text += "Крайние левые терминальные символы" + Environment.NewLine;
            foreach (string a in LeftmostTerminalSymbols.Keys)
            {
                LexemTable.Text += a + " : ";
                foreach (string ch in LeftmostTerminalSymbols[a])
                    LexemTable.Text += ch + " ";
                LexemTable.Text += Environment.NewLine;
            }
            LexemTable.Text += Environment.NewLine;
        }
        #endregion

        #region Матрица предшествования
        private void MatrPred()
        {
            matrPred = new string[terminal.Count()+1][];
            for (int i = 0; i < matrPred.Count(); i++)
            {
                matrPred[i] = new string[terminal.Count()+1];
                for (int j = 0; j < matrPred[i].Count(); j++)
                    matrPred[i][j] = " ";
            }
            int numTerm = 0;
            foreach (string term in terminal)
            {
                foreach (var rule in rules.GetRulesRight())
                {
                    int i = 0;
                    while (i<rule.Count-2)
                    {
                        if (rule[i] == term && no_terminal.Contains(rule[i + 1]) && terminal.Contains(rule[i + 2]))
                            matrPred[numTerm][numOfTerminal(rule[i + 2])] = "=";
                        if (rule[i] == term && terminal.Contains(rule[i + 1]))
                            matrPred[numTerm][numOfTerminal(rule[i + 1])] = "=";
                        i++;
                    }

                    i = 0;
                    while (i < rule.Count - 1)
                    {
                        if (rule[i] == term && no_terminal.Contains(rule[i + 1]))
                            foreach (var ch in LeftmostTerminalSymbols[rule[i + 1]])
                                matrPred[numTerm][numOfTerminal(ch)] = "<";
                        i++;
                    }

                    i = 1;
                    while (i < rule.Count)
                    {
                        if (rule[i] == term && no_terminal.Contains(rule[i - 1]))
                            foreach (var ch in RightmostTerminalSymbols[rule[i - 1]])
                                matrPred[numOfTerminal(ch)][numTerm] = ">";
                        i++;
                    }
                }
                numTerm++;
            }

            foreach (string ch in LeftmostTerminalSymbols[start])
                matrPred[terminal.Count()][numOfTerminal(ch)] = "<";

            foreach (string ch in RightmostTerminalSymbols[start])
                matrPred[numOfTerminal(ch)][terminal.Count()] = ">";

            LexemTable.Text += "Матрица предшествования: " + Environment.NewLine;
            //вывод
            foreach (var rows in matrPred)
            {
                LexemTable.Text += "[";
                foreach (var columns in rows)
                    if (columns != " ") { LexemTable.Text += " |" + columns + "|,"; }
                    else LexemTable.Text += " | |,";
                LexemTable.Text += "]";
                LexemTable.Text += Environment.NewLine;
            }
            LexemTable.Text += Environment.NewLine;
        }
        #endregion

        #region МП-Автомат
        public bool PDA(string str)
        {
            terminal.Add(startSymbol);
            MyStack stackString = new MyStack();
            List<int> listRules = new List<int>();
            MyStack magazine = new MyStack();

            magazine.Push(startSymbol);

            stackString = partitionString(str);

            stackString.Push(endSymbol);
            stackString.Reverse();

            string firstTerminal = "";

            int curr = 0;
            firstTerminal = magazine.GetItem(curr);
            
            while (firstTerminal != startSymbol || stackString.Peek() != endSymbol)
            {
                string temp = "";
                foreach (int ru in listRules)
                    temp += ru.ToString();
                LexemTable.Text += "{ " + stackString.ToSrtingReverse() + "; " + magazine.ToSrting() + "; " + temp + " }" + Environment.NewLine;

                string tempMatr = matrPred[numOfTerminal(firstTerminal)][numOfTerminal(stackString.Peek())];
                if (tempMatr == "<" || tempMatr == "=")
                    magazine.Push(stackString.Pop());
                else if (stackString.Count != 0 && tempMatr == ">")
                {
                    List<string> rule = new List<string>();

                    while (magazine.Peek() == "E")
                        rule.Add(magazine.Pop());
                    rule.Add(magazine.Pop());

                    while (magazine.Peek() == "E" || matrPred[numOfTerminal(magazine.Peek())][numOfTerminal(firstTerminal)] == "=")
                        rule.Add(magazine.Pop());

                    rule.Reverse();

                    if (octovRules.GetRulesLeft(rule) != -1)
                    {
                        magazine.Push("E");
                        listRules.Add(octovRules.GetRulesLeft(rule) + 1);
                    }
                    else
                        return false;
                }
                else
                    return false;

                curr = magazine.Count - 1;
                while (!terminal.Contains(magazine.GetItem(curr)) && !(magazine.GetItem(curr) == startSymbol))
                    curr--;
                firstTerminal = magazine.GetItem(curr);

            }
            sequence = new List<int>(listRules);
            sequence.Reverse();

            LexemTable.Text += Environment.NewLine;
            LexemTable.Text += "Последовательность правил:";
            foreach (int i in sequence)
                LexemTable.Text +=" " + i.ToString();

            LexemTable.Text += Environment.NewLine;
            return true;
        }

        private MyStack partitionString(string str)
        {
            MyStack stackStr = new MyStack();
            foreach (char ch in str)
                stackStr.Push(ch.ToString());
            return stackStr;
        }

        private int numOfTerminal(string name)
        {
            int i = 0;
            if (name == startSymbol || name == endSymbol)
                return terminal.Count()-1;
            foreach (string term in terminal)
                if (term == name)
                    return i;
                else
                    i++;
            return -1;
        }
        #endregion

        #region Дерево вывода
        public void FillTree()
        {
            tree.addNode(new Node(start));

            List<string> usedRuleList = new List<string>();
            usedRuleList.Add("E");

            foreach (int rule in sequence)
            {
                int num = usedRuleList.Count - 1;
                while (num > 0)
                    if (usedRuleList[num] != "E")
                        num--;
                    else
                        break;
                List<Node> childList = new List<Node>();
                foreach (var chr in octovRules.GetRuleRightId(rule))
                {
                    childList.Add(new Node(chr));
                    usedRuleList.Add(chr);
                }
                tree.addChilds(num, childList);

                usedRuleList[num] = "U";
            }
            LexemTable.Text += tree.getStringTree();
        }
        #endregion

        #region // animation at c erunda
        public void MegaAnimation()
        {
            if (sprav == true)
            {
                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    From = 296,
                    To = 529,
                    Duration = TimeSpan.FromSeconds(0.18)
                };
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));
                Storyboard.SetTarget(heightAnimation, Tree_Window);
                Storyboard s = new Storyboard();
                s.Children.Add(heightAnimation);
                s.Begin();

                DoubleAnimation animation1;
                Storyboard storyboardFade2 = new Storyboard();
                animation1 = new DoubleAnimation(1, 0.95, new Duration(TimeSpan.FromSeconds(0.18)));
                Storyboard.SetTargetName(animation1, Tree_Window.Name);
                Storyboard.SetTargetProperty(animation1, new PropertyPath(Window.OpacityProperty));
                storyboardFade2.Children.Add(animation1);

                SolidColorBrush brush = new SolidColorBrush();
                Tree_Window.Background = brush;
                ColorAnimation da = new ColorAnimation();
                da.From = Color.FromArgb(255, 255, 255, 255);
                da.To = Color.FromArgb(255, 49, 52, 52);
                da.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                brush.BeginAnimation(SolidColorBrush.ColorProperty, da);

                SolidColorBrush brush1 = new SolidColorBrush();
                Hand.Background = brush1;
                ColorAnimation da1 = new ColorAnimation();
                da1.From = Color.FromArgb(255, 241, 241, 241);
                da1.To = Color.FromArgb(255, 49, 52, 52);
                da1.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                brush1.BeginAnimation(SolidColorBrush.ColorProperty, da1);

                var animation2 = new ThicknessAnimation();
                animation2.To = new Thickness(0, 27, 0, 0);
                animation2.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                Storyboard.SetTarget(animation2, Tree_Window);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(MarginProperty));
                storyboardFade2.Children.Add(animation2);
                storyboardFade2.Begin(Tree_Window);
                LexemTable.Foreground = Brushes.White;
            }
            else
            {
                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    To = 296,
                    From = 519,
                    Duration = TimeSpan.FromSeconds(0.18)
                };
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));
                Storyboard.SetTarget(heightAnimation, Tree_Window);
                Storyboard s = new Storyboard();
                s.Children.Add(heightAnimation);
                s.Begin();

                DoubleAnimation animation1;
                Storyboard storyboardFade2 = new Storyboard();
                animation1 = new DoubleAnimation(0.95, 1, new Duration(TimeSpan.FromSeconds(0.18)));
                Storyboard.SetTargetName(animation1, Tree_Window.Name);
                Storyboard.SetTargetProperty(animation1, new PropertyPath(Window.OpacityProperty));
                storyboardFade2.Children.Add(animation1);

                SolidColorBrush brush = new SolidColorBrush();
                Tree_Window.Background = brush;
                ColorAnimation da = new ColorAnimation();
                da.To = Color.FromArgb(255, 255, 255, 255);
                da.From = Color.FromArgb(255, 49, 52, 52);
                da.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                brush.BeginAnimation(SolidColorBrush.ColorProperty, da);

                SolidColorBrush brush1 = new SolidColorBrush();
                Hand.Background = brush1;
                ColorAnimation da1 = new ColorAnimation();
                da1.To = Color.FromArgb(255, 217, 224, 223);
                da1.From = Color.FromArgb(255, 49, 52, 52);
                da1.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                brush1.BeginAnimation(SolidColorBrush.ColorProperty, da1);

                var animation2 = new ThicknessAnimation();
                animation2.To = new Thickness(0, 255, 0, 0);
                animation2.Duration = new Duration(TimeSpan.FromSeconds(0.18));
                Storyboard.SetTarget(animation2, Tree_Window);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(MarginProperty));
                storyboardFade2.Children.Add(animation2);
                storyboardFade2.Completed += metod_spravka;
                storyboardFade2.Begin(Tree_Window);
                LexemTable.Foreground = Brushes.Black;
            }
        }              
        private void metod_spravka(object sender, EventArgs e)
        {
            sprav = true;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }      
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimaze_Window(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public bool sprav=true;
        private void Click_Maximaze(object sender, MouseButtonEventArgs e)
        {                            
            MegaAnimation(); sprav = false;
        }
        private void LexemTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MegaAnimation(); sprav = false;
        }
        #endregion//animation

        private void Start_Analysis_Click(object sender, RoutedEventArgs e)
        {
            foreach (string noTerm in no_terminal)
                octovRules.Replace(noTerm, "E");

            
            //открытие файла со строкой
            string filename="", filepath="";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "txt Files (*.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filepath = dlg.FileName;   //путь к файлу
                filename = dlg.SafeFileName;   //имя файла    
            }
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            string input = sr.ReadLine();
            label_file.Content = "file name: " + filename;
            inp_out_str.Content += "Входная строка: "+input;
            //lexicalAnalysis(input);
            Left_M();
            Right_M();
            RightTerm();
            LeftTerm();
            MatrPred();
            AAA(input);
            inp_out_str.Content += "     Измененная строка: " + change_string;
            //string inp = "a=a-(a)";
            PDA(change_string);           
            //PDA(inp);
            Label_String.Content = input;
            FillTree();           
        }
        public string change_string = "";
        public void AAA(string lexString)
        {
            string a = "";
            char KA_Check;
            for (int i = 0; i < lexString.Length; i++)
            {
                KA_Check = lexString[i];
                if ('a' <= KA_Check && KA_Check <= 'z' || (KA_Check == 'X' ||
                            '0' <= KA_Check && KA_Check <= '9' || KA_Check == 'V' || KA_Check == 'I'))
                {
                    a += "a";
                }
                else a += KA_Check;
            }
            change_string = a[0].ToString();
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] != a[i]) { change_string += a[i]; }
                else if (a[i - 1] == a[i] && a[i] != 'a') { change_string += a[i]; }
            }
        }
        #region Конечный автомат
        public void lexicalAnalysis(string lexString)
        {
            string identificator = "";
            string StatusAnalysis = "Start";
            string LastStatus = "Start";            
            int Last_i = 0;
            char KA_Check;
            for (int i = 0; i < lexString.Length; i++)
            {
                KA_Check = lexString[i];
                //начало выражения
                switch (StatusAnalysis)
                {
                    //начало
                    case "Start":
                        if ('a' <= KA_Check && KA_Check <= 'z' || (KA_Check == 'X' || 
                            '0' <= KA_Check && KA_Check <= '9' ||KA_Check == 'V' || KA_Check == 'I'))
                        { StatusAnalysis = "Operand"; }
                        break;
                    //левый операнд
                    case "Operand":
                        if ('a' <= KA_Check && KA_Check <= 'z' || (KA_Check == 'X' ||
                            '0' <= KA_Check && KA_Check <= '9' || KA_Check == 'V' || KA_Check == 'I'))
                        { StatusAnalysis = "Operand"; }                        
                        else if (KA_Check == '=') 
                        { StatusAnalysis = "Assigned"; }                        
                        break;
                    //присваивание
                    case "Other":
                        if (KA_Check == '=' || KA_Check == '+' || KA_Check == '-' || KA_Check == '*' 
                            || KA_Check == '/' || KA_Check == '(' || KA_Check == ')')
                        { StatusAnalysis = "Other"; }
                        else { StatusAnalysis = "Operand"; }
                        break;
                    case "Assigned":
                        if ('a' <= KA_Check && KA_Check <= 'z' || (KA_Check == 'X' ||
                            '0' <= KA_Check && KA_Check <= '9' || KA_Check == 'V' || KA_Check == 'I'))
                        { StatusAnalysis = "Operand"; }
                        else if (KA_Check == '(') { StatusAnalysis = "Other"; }
                        else { StatusAnalysis = "Other"; }
                        break;
                }
                //идентификатор отправляется в таблицу
                if (StatusAnalysis == "Operand" && LastStatus == "Start")
                {
                    if ((i - Last_i) < 32)
                    {
                        identificator = lexString.Substring(Last_i, i - Last_i);
                        Last_i = i;
                        change_string += "a";
                    }
                }
                if (StatusAnalysis == "Operand" && LastStatus == "Other")
                {
                    if ((i - Last_i) < 32)
                    {
                        identificator = lexString.Substring(Last_i, i - Last_i);
                        Last_i = i;
                        change_string += "a";
                    }
                }
                if (StatusAnalysis == "Other" && LastStatus == "Operand")
                {
                    identificator = lexString.Substring(Last_i, i - Last_i);
                    Last_i = i;
                    change_string += KA_Check;
                }
                LastStatus = StatusAnalysis;
            }                
        }
        #endregion
    }
}
