<%@ Page Title="" 
    Language="C#"
     MasterPageFile="~/Page/MasterPageAdmin.Master" 
    AutoEventWireup="true" 
    CodeBehind="Employees.aspx.cs" 
    Inherits="Zero_2.Page.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="/style/EmployeesStyle.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div class="employees">
        <div class="leftemployees">
            <br />
            <asp:Label ID="Label4" runat="server"
                        Text="Сотрудники" style="font-size:24px;"></asp:Label>                    
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Height="24px"
                        Text="Личные параметры" style="font-size:12px;"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"
                        Text="Фамилия" style="font-size:14px;"></asp:Label>
            <br />
            <asp:TextBox CssClass="text" ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server"
                        Text="Имя" style="font-size:14px;"></asp:Label>
            <br />
            <asp:TextBox CssClass="text" ID="TextBox2" runat="server"></asp:TextBox>   
                        <br />
            <asp:Label ID="Label7" runat="server"
                        Text="Код должности" style="font-size:14px;"></asp:Label>
            <br />
            <asp:TextBox CssClass="text" ID="TextBox3" runat="server"></asp:TextBox>        
            <br />
            <br />
            <asp:Button CssClass="search styleleftbut" runat="server" ID="searchbutton" Text="Поиск" OnClick="Search_Click"/>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Height="24px"
                        Text="Служебные параметры" style="font-size:12px;"></asp:Label>
            <br /> 
            <asp:Label ID="Label6" runat="server" Height="24px"
                        Text="Включить в поиск" style="font-size:12px;"></asp:Label>
            <br />             
           <%-- <button  class="styleleftbut it" runat="server" id="itbutton"  onserverclick="It_Click">
                Инженерно технические <br /> сотрудники</button> --%>
            <asp:Button CssClass="reversestyleleftbut it" runat="server" ID="itbutton" Text="ИТ сотрудники" OnClick="It_Click"/>
            <asp:Button CssClass="reversestyleleftbut it" runat="server" ID="rbutton" Text="Рядовые сотрудники" OnClick="R_Click"/>
        </div>
        <div class="rightemployees" runat="server">
            <div class="up">                
                <asp:Button ID="AllButton" CssClass="upbut bt1reverse" runat="server" Text="Все аттестации" OnClick="All_Click"/>
                <asp:Button ID="PlanButton" CssClass="upbut bt2" runat="server" Text="Плановая" OnClick="Plan_Click"/>
                <asp:Button ID="ReButton" CssClass="upbut bt3" runat="server" Text="Повторная" OnClick="Re_Click"/>
                <asp:Button ID="RequestButton" CssClass="upbut bt4" runat="server" Text="Заявки на повышение" OnClick="Request_Click"/>
                <%--<asp:Button CssClass="upbut bt5" runat="server" Text="Внеплановая"/>--%>
            </div>
            <div class="down">

              <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>  --%>
            <asp:ListView runat="server" ID="ProductsListView1" GroupItemCount="3"
                 OnPagePropertiesChanging="ProductsListView1_PagePropertiesChanging">
                <LayoutTemplate>
                    <table cellpadding="3" runat="server"
                        id="tblProducts" style="height:140px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>
                   <div class ="pager">
                   <asp:DataPager runat="server" ID="DataPager"
                        PageSize="9">
                        <Fields>
                        <asp:NumericPagerField ButtonCount="4"
                            PreviousPageText="<<"
                            NextPageText=">>"
                            NextPreviousButtonCssClass="next" 
                            CurrentPageLabelCssClass ="curr"
                            NumericButtonCssClass="num"/>
                        </Fields>
                    </asp:DataPager>
                  </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:235px; height:190px;" runat="server">
                    <div class="upemp">                        
                        <div class="infocomm">
                            <asp:Label ID="Employee1" runat="server" Height="16px" 
                                Text='<%#Eval("Surname")%>' 
                                style="font-size:19px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee2" runat="server" Height="26px"
                                Text='<%#Eval("Name")%>' 
                                style="font-size:14px;"></asp:Label>
                            <asp:Label ID="Employee3" runat="server" Height="26px" 
                                Text='<%#Eval("Patronymic")%>' 
                                style="font-size:14px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee4" runat="server" 
                                Text="Личный номер:" style="font-size:12px;"></asp:Label>
                            <asp:Label ID="Employee5" runat="server" ForeColor="#5c5c5c" 
                                Text='<%#Eval("Id_employees")%>' 
                                style="font-size:12px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee6" runat="server" 
                                Text="Код должности:" style="font-size:12px;"></asp:Label>
                            <asp:Label ID="Employee7" runat="server" ForeColor="#5c5c5c" 
                                Text='<%#Eval("Number_workbook")%>' 
                                style="font-size:12px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee8" runat="server" 
                                Text="Специальность:" style="font-size:12px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee9" runat="server" ForeColor="#5c5c5c" 
                                Text='<%#Eval("Name_speciality")%>' 
                                style="font-size:12px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee10" runat="server"
                                Text="Mail:" style="font-size:12px;"></asp:Label>
                            <asp:Label ID="Employee11" runat="server" ForeColor="#5c5c5c" 
                                Text='<%#Eval("Mailing_address")%>' 
                                style="font-size:12px;"></asp:Label>
                            <br />
                            <asp:Label ID="Employee12" runat="server" 
                                Text="Номер телефона:" style="font-size:12px;"></asp:Label>
                            <asp:Label ID="Employee13" runat="server" ForeColor="#5c5c5c" 
                                Text='<%#Eval("Phone_number")%>' 
                                style="font-size:12px;"></asp:Label>
                        </div>
                    </div>                                         
                    </td>
                </ItemTemplate>
            </asp:ListView>
            <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    </ContentTemplate>
        </asp:UpdatePanel>
    
</asp:Content>
