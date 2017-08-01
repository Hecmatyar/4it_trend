<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Page/MasterPageEmployees.Master" 
    AutoEventWireup="true" 
    CodeBehind="Profile.aspx.cs" 
    Inherits="Zero_2.Page.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/style/StyleFile.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="profilepage">
        <div class="infoprofile">
            <div class="leftprofile" style="float:left;">
                <br />
                <asp:Label ID="Label30" runat="server" ForeColor="#fffffe" Text="Пользователь" 
                    style="font-size:24px; margin-left:14px; font-family:'Segoe UI';"></asp:Label>
                <asp:Label ID="workinfo" runat="server" ForeColor="#fffffe" height="30px" Text="Рабочая информация" 
                    style="font-size:12px; margin-left:14px; margin-top:17px;"></asp:Label>
                <br />                
                <asp:Label ID="login" runat="server" ForeColor="#cacbcd" height="26px" Text="Личный iD (Логин):" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="#fffffe" Text="login12" 
                    style="font-size:15px; margin-left:4px; float:right; margin-right:10px;"></asp:Label>
                <br />
                <%-- <asp:Label ID="Label1" runat="server" ForeColor="#d3d3cc" Text="( Является логином в системе )" 
                    style="font-size:12px; margin-left:14px;"></asp:Label>
                <br />--%>
                <asp:Label ID="password" runat="server" ForeColor="#cacbcd" height="26px" Text="Личный пароль:" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="#fffffe" Text="password" 
                    style="font-size:15px; margin-left:4px; float:right; margin-right:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" ForeColor="#cacbcd" height="30px" Text="Номер рабочей книжки:" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="#fffffe" Text="12OH2" 
                    style="font-size:15px; margin-left:4px; float:right; margin-right:10px;"></asp:Label>
                <br />                
                <hr>                
                <asp:Label ID="Label5" runat="server" ForeColor="#cacbcd" height="18px" Text="Дата принятия на предприятие:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label9" runat="server" ForeColor="#fffffe" height="24px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" ForeColor="#cacbcd" height="18px" Text="Стаж на должности:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label10" runat="server" ForeColor="#fffffe" height="24px" Text="3 лет (год/а)" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" ForeColor="#cacbcd" height="18px" Text="Специальность:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label11" runat="server" ForeColor="#fffffe" height="24px" Text="Инженерно технический персонал" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" ForeColor="#cacbcd" height="18px" Text="Разряд:"
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                 <asp:Label ID="Label12" runat="server" ForeColor="#f38366" height="30px" Text="( отсутствует )"
                    style="font-size:14px; margin-left:14px;"></asp:Label>                
                <br />
            </div>
            <div class="rightprofile">
                <br />
                <asp:Label ID="Label13" runat="server" ForeColor="#44556c" Text="Кушнир Дмитрий Вячеславович" 
                    style="font-size:24px; margin-left:20px; font-family:'Segoe UI';"></asp:Label>
                <br />
                <asp:Label ID="Label14" runat="server" ForeColor="#5a5a5b" height="30px" Text="Личная информация" 
                    style="font-size:12px; margin-left:20px; margin-top:17px;"></asp:Label>
                <br />
                <asp:Label ID="Label15" runat="server" ForeColor="#44556c" height="26px" Text="Дата рождения:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <asp:Label ID="Label16" runat="server" ForeColor="#44556c" height="26px" Text="28 июня 1987" 
                    style="font-size:15px; margin-left:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label17" runat="server" ForeColor="#44556c" height="26px" Text="Полных лет:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <asp:Label ID="Label18" runat="server" ForeColor="#44556c" height="26px" Text="20" 
                    style="font-size:15px; margin-left:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label19" runat="server" ForeColor="#44556c" height="26px" Text="Адресс:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <asp:Label ID="Label20" runat="server" ForeColor="#44556c" height="26px" Text="г. Тирасполь ул. Краснодонская д.84 кв.25" 
                    style="font-size:15px; margin-left:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label21" runat="server" ForeColor="#44556c" height="26px" Text="Номер телефона:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <asp:Label ID="Label22" runat="server" ForeColor="#44556c" height="26px" Text="0 (533) 22522" 
                    style="font-size:15px; margin-left:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label23" runat="server" ForeColor="#44556c" height="18px" Text="Почтовый адрес:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <asp:Label ID="Label24" runat="server" ForeColor="#44556c" height="18px" Text="dmitriy.kushnir@inbox.ru" 
                    style="font-size:15px; margin-left:10px;"></asp:Label>
                <br />
                <asp:Label ID="Label25" runat="server" ForeColor="#5a5a5b" height="20px" Text="( Для связи с производством)" 
                    style="font-size:12px; margin-left:20px;"></asp:Label>
                <br />
                <asp:Label ID="Label26" runat="server" ForeColor="#44556c" height="18px" Text="Выговоры:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <br />
                <asp:Label ID="Label27" runat="server" ForeColor="#44556c" height="26px" 
                    Text="Систематичсеское опоздание на рабочее место" 
                    style="font-size:13.5px; margin-left:20px;"></asp:Label>
                <br />                
                <asp:Label ID="Label28" runat="server" ForeColor="#44556c" height="18px" Text="Награды:" 
                    style="font-size:15px; margin-left:20px;"></asp:Label>
                <br />
                <asp:Label ID="Label29" runat="server" ForeColor="#44556c" height="26px" 
                    Text="26 июня 2013 отличился при возникновении опасной ситуации с электрощитком. 19 февряля 2015 проявил мастерство 
                    при возникновении чп." 
                    style="font-size:13.5px; margin-left:20px;"></asp:Label>
                <br />
                <br />                
            </div>
        </div>
        <div class="validationprofile">
            <asp:Label ID="Label31" runat="server" ForeColor="#fffffe" height="30px" Text="Аттестационные данные" 
                    style="font-size:12px; margin-left:14px; margin-top:17px;"></asp:Label>             
        <div class="attestation">
            <div class="plan" style="float:left; width:33%;">
                <asp:Label ID="Label43" runat="server" ForeColor="#eec645" height="24px" Text="Плановая аттестация" 
                    style="font-size:12px; margin-left:14px;"></asp:Label>
                <br />  
                <asp:Label ID="Label32" runat="server" ForeColor="#cacbcd" height="20px" 
                    Text="Техника безопасности:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label34" runat="server" ForeColor="#fffffe" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:8px;"></asp:Label>  
                <br />           
                <asp:Label ID="Label33" runat="server" ForeColor="#cacbcd" height="20px" 
                    Text="Электробезопасность:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label35" runat="server" ForeColor="#fffffe" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:12px;"></asp:Label>
                <br /> 
            </div>   
            <div class="replan" style="float:left; width:33%;">
                <asp:Label ID="Label48" runat="server" ForeColor="#eec645" height="24px" Text="Повторная аттестация" 
                    style="font-size:12px; margin-left:14px;"></asp:Label>
                <br />  
                <asp:Label ID="Label49" runat="server" ForeColor="#cacbcd" height="20px" 
                    Text="Техника безопасности:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label50" runat="server" ForeColor="#fffffe" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:8px;"></asp:Label>  
                <br />           
                <asp:Label ID="Label51" runat="server" ForeColor="#cacbcd" height="20px" 
                    Text="Электробезопасность:" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label52" runat="server" ForeColor="#fffffe" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:12px;"></asp:Label>
                <br /> 
            </div>
            <div class="surprise" style="float:left; width:34%;">
                <asp:Label ID="Label53" runat="server" ForeColor="#eec645" height="24px" Text="Внеплановая аттестация" 
                    style="font-size:12px; margin-left:14px;"></asp:Label>
                <br />  
                <asp:Label ID="Label44" runat="server" ForeColor="#f38366" height="20px" 
                    Text="Техника безопасности:" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label45" runat="server" ForeColor="#f38366" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:8px;"></asp:Label>     
                <br />       
                <asp:Label ID="Label46" runat="server" ForeColor="#f38366" height="20px" 
                    Text="Электробезопасность:" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <asp:Label ID="Label47" runat="server" ForeColor="#f38366" height="20px" Text="24 июня 2016" 
                    style="font-size:14px; margin-left:12px;"></asp:Label>
                <br /> 
            </div>  
        </div>
            
        <div class="rank" style="margin-top:60px;">
            <br /> 
            <hr />
            <asp:Label ID="Label36" runat="server" ForeColor="#fffffe" height="30px" Text="Повышение разряда" 
                    style="font-size:12px; margin-left:14px; margin-top:17px;"></asp:Label>
            <br /> 
            <asp:Label ID="Label37" runat="server" ForeColor="#f38366" height="26px" 
                Text="ничего" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
            <asp:Label ID="Label38" runat="server" ForeColor="#f38366" height="26px" 
                Text="не произошло" 
                    style="font-size:15px; margin-left:24px;"></asp:Label>
             <asp:Button ID="Button1" runat="server" Text="Подать заявление" style="width:180px; height:35px; 
                    vertical-align:text-top; float:right; 
                    color:black; border-radius:5px; background-color:#4abfb4; color:white; font-size:16px;
                    font-family:'Segoe UI'; cursor:pointer; border:none; margin-top:-4px; margin-right:10px;" OnClick="Statement_Click"/>
            <br />             
            <%--<br /> 
            <asp:Label ID="Label39" runat="server" ForeColor="#cacbcd" height="26px" 
                Text="Вы подали заявление:" 
                    style="font-size:16px; margin-left:14px;"></asp:Label>
            <asp:Label ID="Label40" runat="server" ForeColor="#fffffe" height="26px" 
                Text="18 мая 2016" 
                    style="font-size:16px; "></asp:Label>
            <asp:Label ID="Label41" runat="server" ForeColor="#cacbcd" height="26px" 
                Text="Назначенное время проведения аттестации:" 
                    style="font-size:16px; margin-left:40px;"></asp:Label>
            <asp:Label ID="Label42" runat="server" ForeColor="#fffffe" height="26px" 
                Text="29 мая 2016" 
                    style="font-size:16px; "></asp:Label>
            <br /> --%>
            <br /> 
            <br /> 
        </div>
            
        </div>        
    </div>
</asp:Content>
