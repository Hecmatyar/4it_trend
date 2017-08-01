<%@ Page Title="" Language="C#" MasterPageFile="~/Page/MasterPageAdmin.Master" 
    AutoEventWireup="true" CodeBehind="Approve.aspx.cs" 
    Inherits="Zero_2.Page.Approve"%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <link href="/style/Approve.css" rel="stylesheet" type="text/css" /> 
    <link href="/style/downlist.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/Fill_list.js" ></script>
    <script src="/scripts/dropdown.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>           
    <script>
    $(document).mouseup(function (e) {
       var container1 = $("#approve");
       if (container1.has(e.target).length === 0) {
          container1.hide();
       }
       });
       $(document).ready(function(){
          //Скрыть PopUp при загрузке страницы    
           approveHide();
       });
       //Функция отображения PopUp
       function approveShow() {
           $("#approve").show();
       }
       //Функция скрытия PopUp
       function approveHide() {
              $("#approve").hide();
          $(document).hide();
        }
    </script>
    <div class="a-approveclass" id="approve" style="display: none;">
         <div class="a-content">
                <div class="up" style="width:480px; height:180px; background:white;">
                    <br />
                    <asp:Label ID="Acept" runat="server" ForeColor="Black"
                        Text="Список аттестационной комиссии" 
                    style="font-size:24px; margin-left:50px;"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Acept3" runat="server" ForeColor="Black" Height="16px" Width="440px" 
                        Text="Сохранить выбранные парметры проведения аттестации" 
                        style="font-size:16px; margin-left:25px; margin-right:30px;"></asp:Label>
                    <br />
                     <br />
                    <asp:Label ID="Acept1" runat="server" ForeColor="Black" Height="16px" Width="440px" 
                        Text="Назначить выбранных сотрудников с предприятия" 
                        style="font-size:16px; margin-left:50px; margin-right:30px;"></asp:Label>
                    <br />
                    <asp:Label ID="Acept2" runat="server" ForeColor="Black" Height="16px" Width="440px" 
                        Text="членами аттестационной комисии" 
                        style="font-size:16px; margin-left:100px; margin-right:30px;"></asp:Label>
                </div>
              <div class="down" style="width:480px; height:61px; background:white;">
                  <asp:Button ID="Button6" CssClass="down downbut1" runat="server" OnClick="Button2_Click"
                      Text="Принять"/>
                  <a class="down downbut2" href="javascript:approveHide()">Отменить</a> 
                </div>
         </div>
    </div>
    <div class="approvecommission">              
        <div class="left" style="float:left;">
            <br />
            <asp:Label ID="Label30" runat="server" ForeColor="#fffffe" Height="16px" Text="Список" 
                 style="font-size:28px; margin-left:14px;"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" ForeColor="#fffffe" Height="26px" Text="Плановая аттестация" 
                 style="font-size:16px; margin-left:14px;"></asp:Label>
            <br />
            <br />
            <%--<asp:Button ID="Button1" CssClass="but2" runat="server" Text="Утвердить" Width="170px" Height="40px"
                    style="border-radius:4px; border:none;
                    color:white; margin-left:14px; cursor:pointer;"/>--%>    
            <a class="button1 app" href="javascript:approveShow()" 
                style="font-size:15px; font-family:'Segoe UI';">Утвердить</a>    
                
            <%--<asp:Button ID="Button6" CssClass="button button1 approvebut" runat="server" Text="Утвердить"/>--%>
            <br />
            <br />
            <asp:Label ID="login" runat="server" ForeColor="#cacbcd" Text="Назначить выбранных" 
                 style="font-size:15px; margin-left:14px;"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="#cacbcd" Text="сотрудников членами" 
                 style="font-size:15px; margin-left:14px;"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" ForeColor="#cacbcd" Text="аттестационной комисии" 
                 style="font-size:15px; margin-left:14px;"></asp:Label>
            <br />
            <br />
            <hr />
            <asp:Label ID="Label14" runat="server" ForeColor="White" Text="Редактирование" 
                    style="font-size:13px; margin-left:14px;"></asp:Label>
                <br />                
            <asp:Label ID="Label11" runat="server" ForeColor="#eec645" Text="Список комисии" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
            <asp:Label ID="Label12" runat="server" ForeColor="#eec645" Text="можно изменить до" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
            <asp:Label ID="Label13" runat="server" ForeColor="#eec645" Text="проведения аттестации"
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
        </div>
        <div class="right" style="float:right;">
            <div class="listcommission" style="float:left;">
                <br />
                <asp:Label ID="Label15" runat="server" ForeColor="#26364b" Height="16px" Text="Сформировать комисиию" 
                 style="font-size:28px; margin-left:14px;"></asp:Label>
                <br />               
                <asp:Label  CssClass="gos" ID="Label16" runat="server" ForeColor="#44556c" Height="16px" 
                    Text="Сотрудник государственной службы по охране труда и производственной безопасности при аттестации" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <asp:Label CssClass="gos2" ID="Label17" runat="server" ForeColor="#631818"
                    Text="Михаил Федорович Мозайка"></asp:Label>
                <hr  class="hr"/>               
                <asp:Label ID="Label18" runat="server" ForeColor="#44556c" Height="16px" 
                    Text="Сотрудники с производства" 
                    style="font-size:16px; margin-left:14px;"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label19" runat="server" ForeColor="Black" Height="16px" 
                    Text="Член аттестационной комиссии 1" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br /> 
                <asp:DropDownList ID="DrList1" runat="server" CssClass="list1" OnSelectedIndexChanged="SelectChanged_Click1">
                    
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label20" runat="server" ForeColor="Black" Height="16px" 
                    Text="Член аттестационной комиссии 2" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:DropDownList ID="DrList2" runat="server" CssClass="list1" OnSelectedIndexChanged="SelectChanged_Click2">
                    
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label21" runat="server" ForeColor="Black" Height="16px" 
                    Text="Член аттестационной комиссии 3" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:DropDownList ID="DrList3" runat="server" CssClass="list1" OnSelectedIndexChanged="SelectChanged_Click3">
                    
                </asp:DropDownList>
                <br />               
                

                <br />
                <asp:Label ID="Label22" runat="server" ForeColor="Black" Height="16px" 
                    Text="Дата и время проведения аттестаций" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label23" runat="server" ForeColor="#465566" Height="16px" 
                    Text="Техника безопасности" 
                    style="font-size:16px; margin-left:14px; margin-right:30px;"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>                    
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>                                      
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>                                                        
                </asp:DropDownList>
                <br />                 
                <asp:Label ID="Label24" runat="server" ForeColor="#465566" Height="16px" 
                    Text="Электробезопасность" 
                    style="font-size:16px; margin-left:14px; margin-right:34px;"></asp:Label>
                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>                    
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>                                      
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="list2" OnSelectedIndexChanged="SelectChanged_Click3">
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>                                                        
                </asp:DropDownList>
                <br />
            </div>

            <div class="exit" style="float:left;">
                <br />
                <asp:Label ID="Label4" runat="server" ForeColor="#fffffe" Height="16px" Text="Отменить" 
                    style="font-size:28px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" ForeColor="#fffffe" Height="16px" Text="формирование комисии" 
                    style="font-size:16px; margin-left:14px;"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button2" CssClass="button button2 approvebut" runat="server" Text="Вернуться" OnClick="Button_Click"
                    style="margin-left:14px; cursor:pointer;"/>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" ForeColor="#cacbcd" Text="К покинутой странице" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" ForeColor="#cacbcd" Text="проведения аттестации" 
                    style="font-size:15px; margin-left:14px;"></asp:Label>
                <br />
                <br />
                <hr />
                <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Изменения" 
                    style="font-size:13px; margin-left:14px;"></asp:Label>
                <br />                
                <asp:Label ID="Label9" runat="server" ForeColor="#eec645" Text="Внесенные измененния" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" ForeColor="#eec645" Text="не будут сохранены" 
                    style="font-size:14px; margin-left:14px;"></asp:Label>
             </div>
        </div>
    </div>
</asp:Content>
