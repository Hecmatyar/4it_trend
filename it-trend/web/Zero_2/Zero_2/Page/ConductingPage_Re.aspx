<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConductingPage_Re.aspx.cs" 
    Inherits="Zero_2.Page.ConductingPage_Re"   MasterPageFile="Conducting.master"%>

<asp:Content ID="content1" ContentPlaceHolderID="SecondLevel" runat="server">
   <link href="/style/StyleCond.css" rel="stylesheet" type="text/css" />
   <div class ="condinfo" runat="server">
        <div class="lr">            
            <div class="leftcond" style="float:left;">
                <asp:Button ID="Button1" CssClass="button button1" runat="server" Text="Техника безопасности" 
                    Width="200px" Height="40px" OnClick="Button1_Click"
                    style="border-top-right-radius:4px; border-bottom-right-radius:4px; 
                    margin-top:14px; cursor:pointer;"/>
                <br />            
                <asp:Button ID="Button2" CssClass="button button1" runat="server" Text="Электробезопасность"  
                    Width="200px" Height="40px" OnClick="Button2_Click"
                    style="border-top-right-radius:4px; border-bottom-right-radius:4px; 
                    margin-top:10px; cursor:pointer;"/>
            </div>             
            <div class="rightcond" style="float:right;">
                <div class="left" style="float:left;">
                    <br />
                    <asp:Label ID="Label2" runat="server"
                        Text="Список сотрудников" Height="16px"
                        Font-Names="Segoe UI" Font-Size="15px"> </asp:Label>     
                    <br />     
                    <asp:Label ID="Label3" runat="server"
                        Text="проходящих повторную аттестацию по дисциплине:" Height="31px"
                        Font-Names="Segoe UI" Font-Size="15px"> </asp:Label>     
                    <br />     
                    <asp:Label ID="Label1" runat="server" 
                        Text="" Font-Names="Segoe UI" Font-Size="15px" ForeColor="White"> </asp:Label>    
                </div>
                <div class="right" style="float:right;">
                    <br />  
                    <asp:Label ID="Label4" runat="server"
                        Text="Аттестационная комиссия не назначена" Height="30px"
                        Font-Names="Segoe UI" Font-Size="15px"> </asp:Label>
                    <br />            
                    <asp:Button ID="Button3" CssClass="button button1" runat="server" Text="Определить"  
                        Width="200px" Height="40px" OnClick="Button3_Click"
                        style="border-radius:4px; 
                        margin-top:10px; cursor:pointer; margin-left:40px;"/>
                    </div>
            </div>
        </div>
        <div class="gridcond">
            <br />            
            <asp:GridView ID="GridView1" runat="server" Width="960px" Font-Names="Segoe UI" Font-Size="15px" AutoGenerateColumns="false">
                    <Columns>      
                        <asp:BoundField DataField="Id_employees" HeaderText="Личный номер" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px"/>
                        <asp:BoundField DataField="Surname" HeaderText="Фамилия"/>
                        <asp:BoundField DataField="Name" HeaderText="Имя"/>
                        <asp:BoundField DataField="Patronymic" HeaderText="Отчество"/>
                        <asp:BoundField DataField="Name_speciality" HeaderText="iD Спец" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px"/>
                        <asp:BoundField DataField="Rank" HeaderText="Разряд" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="65px"/>
                        <asp:BoundField DataField="Number_workbook" HeaderText="Код должности" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="125px"/>
                    </Columns>
                </asp:GridView>
        </div>  
    </div> 
</asp:Content>