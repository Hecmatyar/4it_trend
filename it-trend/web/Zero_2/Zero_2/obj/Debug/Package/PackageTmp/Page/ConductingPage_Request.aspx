<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConductingPage_Request.aspx.cs" 
      MasterPageFile="Conducting.master" Inherits="Zero_2.Page.ConductingPage_Request" %>

<asp:Content ID="content1" ContentPlaceHolderID="SecondLevel" runat="server">
     <link href="/style/StyleCond.css" rel="stylesheet" type="text/css" />     
     <div class="requestpage">
         <div class="request" style="float:right;">               
             <div class="lab" style="float:left; margin-left:180px; margin-top:18px;">
                 <asp:Label ID="Label4" runat="server"
                 Text="Список сорудников, изъявивших желание повысить разряд" Height="30px"
                 Font-Names="Segoe UI" Font-Size="15px"> </asp:Label> 
             </div>      
             <div class="bt" style="float:right; width:380px;">                                          
             <asp:Button ID="Button1" CssClass="button button1" runat="server" Text="Сформировать комиссию"  
                 Width="200px" Height="40px" OnClick="Button3_Click"
                style="border-radius:4px;
                margin-top:10px; cursor:pointer;"/>
             </div> 
        </div>
        <div class="gridcond">
            <br />            
            <asp:GridView ID="GridView2" runat="server" Width="960px" Font-Names="Segoe UI" Font-Size="15px" AutoGenerateColumns="false">
                    <Columns>      
                        <asp:BoundField DataField="Id_employees" HeaderText="Личный номер" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px"/>
                        <asp:BoundField DataField="Name" HeaderText="Имя" />
                        <asp:BoundField DataField="Surname" HeaderText="Фамилия" />
                        <asp:BoundField DataField="Patronymic" HeaderText="Отчество" />
                        <asp:BoundField DataField="Number_workbook" HeaderText="Код должности" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px"/>
                        <asp:BoundField DataField="Rank" HeaderText="Разряд" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px"/>
                        <asp:BoundField DataField="Want_date" HeaderText="Дата зарпоса" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="160px"/>
                    </Columns>
                </asp:GridView>
        </div>    
    </div>
</asp:Content>