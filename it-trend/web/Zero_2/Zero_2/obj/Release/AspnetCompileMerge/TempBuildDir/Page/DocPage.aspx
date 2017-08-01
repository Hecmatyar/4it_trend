<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="DocPage.aspx.cs" 
    
    Inherits="Zero_2.Page.DocPage" %>

<asp:Content ID ="content1" ContentPlaceHolderID ="head" runat="server">  
    <link href="/style/StyleSheet2.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID ="content2" ContentPlaceHolderID ="body" runat="server">
  <div class="validationpage">  
        <asp:Label ID="Label17" runat="server" BackColor="White" ForeColor="#003399" Height="1px" Text=""></asp:Label>
        <div class ="imagefirm">
            <asp:Image ID="image1" runat="server"  src="/Image/bodet.jpg" ImageAlign="Middle"/>
        </div>
        <br />

        <div class="leftvalidation" style="float:left; ">
            <div class="left1">
                <asp:Label ID="firm" runat="server" BackColor="White" ForeColor="#7ca6ff" Height="20px" Text="ДОКУМЕНТЫ"></asp:Label>
                <br />
                <br />                
                <asp:Label ID="Label2" runat="server" 
                    Text="Порядок проведения аттестации (подпункт в) пункта 1 настоящей статьи) устанавливается трудовым 
                    законодательством Приднестровской Молдавской Республики, локальными нормативными актами, принимаемыми 
                    с учетом мнения представительного органа работников."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" 
                    Text="При  проведении  аттестации,  которая    может    послужить
                    основанием для увольнения работников в соответствии с подпунктом  2)
                    подпункта в)  пункта  1  статьи  81  настоящего  Кодекса,  в  состав
                    аттестационной  комиссии  в  обязательном  порядке  включается  член
                    комиссии от соответствующего выборного профсоюзного органа."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI"></asp:Label>  
                <br /> 
                <br />                 
                <a href="http://www.minjust.org/web.nsf/767eb8a58ad76a2bc22574d5002acf15/6b93855f22f2898ac22575d70030046d!OpenDocument" target="_blank"
                    style="color:#7ca6ff; Font:Segoe UI; float:left;">Трудовой кодекс ПМР</a>
                <br />
                 
            </div>

            <div class="left2">
                <asp:Label ID="Label3" runat="server" BackColor="White" ForeColor="#7ca6ff" Height="20px" Text="АТТЕСТАЦИЯ"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" 
                    Text="В состав аттестационной комиссии при проведении планвоой аттестации 
                    входит представитель государственной службы по охране труда и производственной безопасности при аттестации."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI"></asp:Label>
                <br />  
                <br />            
                <asp:Label ID="Label4" runat="server" 
                    Text="На данный момент на предприятии «МеталлТрансИзолит-Астора» аттестацию проходят:"
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>                
                <br />
                <asp:Label ID="Label8" runat="server" BackColor="White" ForeColor="#006666" Text="Инженерно-технический персонал: 1 раз в 3 года"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" BackColor="White" ForeColor="#006666" Text="Рядовые сотрудники: 1 раз в год"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label10" runat="server" Text="Аттестация включает в себя сдачу дисциплин:"
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>    
                <br />
                <asp:Label ID="Label11" runat="server" Text=" - Охрана труда и техническа безопасность"
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>    
                <br />
                <asp:Label ID="Label12" runat="server" Text=" - Электробезопасность"
                     Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>    
                <br />    
             </div>

             <div class="left3">
                <asp:Label ID="Label14" runat="server" BackColor="White" ForeColor="#7ca6ff" Text="СОТРУДНИКУ ПРЕДПРИЯТИЯ"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label15" runat="server" Text="Инженерно-технический персонал и Рядовые сотрудники могут просмотреть 
                    информацию о предстоящих аттестациях, датах их проведения, состве комиссии и личных аттестационных 
                    задолжностях в своем профиле."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>    
                <br />
                <br />
                <asp:Label ID="Label16" runat="server" Text="Рядовой сотрудник может подать заявление на повышение разряда. 
                    Заявление будет приянто к рассмотрению, если сотрудник соответствует всем необходимым параметрам (стаж на 
                    предыдущем разряде не менее 3 лет, отсутствие серьезных выговоров)"
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI" ></asp:Label>                
             </div>
        </div>  
       
        <div class="rightvalidation"  style= "float:right;">
             <div class="redphone" style="padding:8px 8px 8px 8px; background:white;"> 
                    <asp:Image ID="image2" runat="server"  src="/Image/redl.jpg" ImageAlign="Middle" Width="290px"/>                    
            </div>
            <div class="contacts">
                <div class="cont">Наши филиалы</div>
                <div class="contul">
                    <ul class="ul">
                        <li><a href="Contacts.aspx">Филиал в г. Астора</a></li>
                        <li><a href="Contacts.aspx">Филиал в г. Анор Лондо</a></li>                                  
                        <li><a href="Contacts.aspx">Филиал в г. Минас-Тирит</a></li>
                        <li><a href="Contacts.aspx">Филиал в г. Айнкрад</a></li>
                        <li><a href="Contacts.aspx">Филиал в г. Кхазад-Дум</a></li>
                    </ul>  
                </div>
            </div>
            <div class="contacts">
                <div class="cont">Министрество регионального развития</div>
                <div class="contimage">
                   <asp:Image ID="image3" runat="server" src="/Image/ministry.png" ImageAlign="Middle" Width="200px"/>
                </div>
            </div>
        </div>        
    </div>
    &nbsp;
</asp:Content>