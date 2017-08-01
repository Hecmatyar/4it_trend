<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ValidationPage.aspx.cs"     
    Inherits="Zero_2.Page.ValidationPage" %>

<asp:Content ID ="content1" ContentPlaceHolderID ="head" runat="server">  
    <link href="/style/stylesheet2.css" rel="stylesheet" type="text/css" />  
</asp:Content>

<asp:Content ID ="content2" ContentPlaceHolderID ="body" runat="server">
    <div class="validationpage">  
        <asp:Label ID="Label17" runat="server" BackColor="White" ForeColor="#003399" Height="1px" Text=""></asp:Label>
        <div class ="imagefirm">
            <asp:Image ID="image1" runat="server"  src="/Image/ks.jpg" ImageAlign="Middle"/>
        </div>
        <br />

        <div class="leftvalidation" style="float:left; ">
            <div class="left1">
                <asp:Label ID="firm" runat="server" BackColor="White" ForeColor="#7ca6ff" Height="20px" Text="ПРЕДПРИЯТИЕ"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" 
                    Text="Общество с ограниченной ответственностью «МеталлТрансИзолит-Астора» - современное, многопрофильное производство,
                    входящее в пятерку лучших поставщиков толстолистового проката из углеродистых, низколегированных, конструкционных и 
                    легированных марок сталей."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI">
                </asp:Label>   
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" 
                    Text="«МеталлТрансИзолит-Астора» является лидером рынка СНГ аморфных и нанокристаллических сплавов и крупнейшим 
                    российским производителем товаров для дома и семьи из нержавеющей и углеродистой стали"
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI"></asp:Label>
            </div>
            <div class="left2">
                <asp:Label ID="Label3" runat="server" BackColor="White" ForeColor="#7ca6ff" Height="20px" Text="АТТЕСТАЦИЯ"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" 
                    Text="В деятельности организации большое внимание удлеяется аттестации сотрудников, целью которой является        
                    проверка уровня подготовки, мастерства, квалификации сотрудников предприятия."
                    Width="600px" ForeColor="#626262" Font-Names="Segoe UI">
                </asp:Label>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" 
                    Text="Утвержденные даты проведения аттестаций"
                    Width="600px" ForeColor="#006666" Font-Names="Segoe UI">
                </asp:Label>
                <br />                
                <asp:Label ID="Label6" runat="server" 
                    Text="- Охрана труда и техническа безопасность: "
                    ForeColor="#006666" Font-Names="Segoe UI">
                </asp:Label>
                <asp:Label ID="Label8" runat="server" 
                    Text=""
                    ForeColor="#7ca6ff" Font-Names="Segoe UI">
                </asp:Label>
                <br />                
                <asp:Label ID="Label7" runat="server" 
                    Text="- Электробезопасность: "
                    ForeColor="#006666" Font-Names="Segoe UI">
                </asp:Label>
                <asp:Label ID="Label9" runat="server" 
                    Text=""
                    ForeColor="#7ca6ff" Font-Names="Segoe UI">
                </asp:Label>
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
        </div>        
    </div>
    &nbsp;
</asp:Content>





