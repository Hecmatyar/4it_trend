<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Commision.aspx.cs" 
    Inherits="Zero_2.Page.Commision"
    MasterPageFile="MasterPageAdmin.Master" %>

<asp:Content ID ="content2" ContentPlaceHolderID ="body" runat="server">
    <link href="/style/CommissionStyle.css" rel="stylesheet" type="text/css" />
    <div class="commissionpage">





        <%--Плановая аттестация--%>
        <div class="attestationplan">
        <div class="upplan">
            <div class="plan">                
                <asp:Label ID="Acept3" runat="server" Height="16px"
                        Text="Плановая аттестация" style="font-size:16px;"></asp:Label>
            </div>
            <div class="dateplan">
                <div class="leftdate">                    
                    <asp:Label ID="Label4" runat="server" Height="24px"
                        Text="Техника безопасности" style="font-size:16px;"></asp:Label>                    
                    <br />
                    <asp:Label ID="Label5" runat="server" Height="16px"
                        Text="12 июня" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
                <div class="rightdate">
                    <asp:Label ID="Label6" runat="server" Height="24px"
                        Text="Электробезопасность" style="font-size:16px;"></asp:Label>                   
                    <br />
                    <asp:Label ID="Label7" runat="server" Height="16px"
                        Text="16 июня" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
            </div>
            <div class="downplan">
                <div class="leftdown">
                    <asp:Label ID="Label8" runat="server" Height="16px"
                        Text="12 июня 2016г." style="font-size:16px;"></asp:Label>
                </div>
                <div class="rightdown">
                    <asp:Label ID="Label9" runat="server" Height="16px"
                        Text="16 июня 2016г." style="font-size:16px;"></asp:Label>
                </div>
            </div>
        </div>
            <div class="rightcommissiongover">
            <asp:ListView runat="server" ID="ListView1" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:140px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:410px; height:140px;" runat="server">
                    <div class="upcommgover">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                            
                        </div>
                        <div class="infocommgover">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_man")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label20" runat="server" ForeColor="#465566" Width="300px"
                                Text="Сотрудник государственной службы по охране труда и производственной безопасности при аттестации"
                                style="font-size:14px;"></asp:Label>
                            
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>            
        </div>
        </div>
        <div class="rightcommission">
            <asp:ListView runat="server" ID="ProductsListView1" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:100px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:310px; height:100px;" runat="server">
                    <div class="upcomm">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                            
                        </div>
                        <div class="infocomm">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_vp")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label20" runat="server" ForeColor="#465566" Height="16px"
                                Text="Должность"
                                style="font-size:14px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label21" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Position")%>' 
                                style="font-size:16px;"></asp:Label>
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>
            <hr />
        </div>










        <%--Повторная аттестация--%>
        <div class="attestationplan">
        <div class="upplan">
            <div class="plan">                
                <asp:Label ID="Label10" runat="server" Height="16px"
                        Text="Повторная аттестация" style="font-size:16px;"></asp:Label>
            </div>
            <div class="dateplan">
                <div class="leftdate">                    
                    <asp:Label ID="Label11" runat="server" Height="24px"
                        Text="Техника безопасности" style="font-size:16px;"></asp:Label>                    
                    <br />
                    <asp:Label ID="Label12" runat="server" Height="16px"
                        Text="19 августа" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
                <div class="rightdate">
                    <asp:Label ID="Label13" runat="server" Height="24px"
                        Text="Электробезопасность" style="font-size:16px;"></asp:Label>                   
                    <br />
                    <asp:Label ID="Label14" runat="server" Height="16px"
                        Text="17 сентября" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
            </div>
            <div class="downplan">
                <div class="leftdown">
                    <asp:Label ID="Label15" runat="server" Height="16px"
                        Text="19 августа 2016г." style="font-size:16px;"></asp:Label>
                </div>
                <div class="rightdown">
                    <asp:Label ID="Label16" runat="server" Height="16px"
                        Text="17 сентября 2016г." style="font-size:16px;"></asp:Label>
                </div>
            </div>
        </div>
            <div class="rightcommissiongover">
            <asp:ListView runat="server" ID="ListView2" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:140px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:410px; height:140px;" runat="server">
                    <div class="upcommgover">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                            
                        </div>
                        <div class="infocommgover">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_man")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label20" runat="server" ForeColor="#465566" Width="300px"
                                Text="Сотрудник государственной службы по охране труда и производственной безопасности при аттестации"
                                style="font-size:14px;"></asp:Label>
                            
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>            
        </div>
        </div>


        <div class="rightcommission">
            <asp:ListView runat="server" ID="ProductsListView2" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:100px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:310px; height:100px;" runat="server">
                    <div class="upcomm">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                           
                        </div>
                        <div class="infocomm">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_vp")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br /> 
                            <asp:Label ID="Label20" runat="server" ForeColor="#465566" Height="16px"
                                Text="Должность"
                                style="font-size:14px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label21" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Position")%>' 
                                style="font-size:16px;"></asp:Label>          
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>
            <hr />
        </div>









        <%--Заявки на повышение разряда--%>
        <div class="attestationplan">
        <div class="upplan2">
            <div class="plan2">                
                <asp:Label ID="Label17" runat="server" Height="16px"
                        Text="Аттестация на повышение разряда" style="font-size:16px;"></asp:Label>
            </div>
            <div class="dateplan2">
                <div class="leftdate2">                    
                    <asp:Label ID="Label18" runat="server" Height="24px"
                        Text="Аттестация" style="font-size:16px;"></asp:Label>
                    <br />
                    <asp:Label ID="Label19" runat="server" Height="16px"
                        Text="2 аперля" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>               
            </div>
            <div class="downplan2">
                <div class="leftdown2">
                    <asp:Label ID="Label22" runat="server" Height="16px"
                        Text="2 аперля 2016г." style="font-size:16px;"></asp:Label>
                </div>                
            </div>
        </div>
        </div>


        <div class="rightcommission">
            <asp:ListView runat="server" ID="ProductsListView3" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:100px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                   
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:310px; height:100px;" runat="server">
                    <div class="upcomm">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                           
                        </div>
                        <div class="infocomm">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_vp")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />                    
                             <asp:Label ID="Label20" runat="server" ForeColor="#465566" Height="16px"
                                Text="Должность"
                                style="font-size:14px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label21" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Position")%>' 
                                style="font-size:16px;"></asp:Label> 
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>
            <hr />
        </div>







         <%--Внеплановая аттестация--%>
        <div class="attestationplan">
        <div class="upplan">
            <div class="plan">                
                <asp:Label ID="Label24" runat="server" Height="16px"
                        Text="Внеплановая аттестация" style="font-size:16px;"></asp:Label>
            </div>
            <div class="dateplan">
                <div class="leftdate1">                    
                    <asp:Label ID="Label25" runat="server" Height="24px"
                        Text="Техника безопасности" style="font-size:16px;"></asp:Label>                    
                    <br />
                    <asp:Label ID="Label26" runat="server" Height="16px"
                        Text="2 аперля" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
                <div class="rightdate1">
                    <asp:Label ID="Label27" runat="server" Height="24px"
                        Text="Электробезопасность" style="font-size:16px;"></asp:Label>                   
                    <br />
                    <asp:Label ID="Label28" runat="server" Height="16px"
                        Text="7 апреля" style="font-size:40px; font-family:Calibri;"></asp:Label>
                </div>
            </div>
            <div class="downplan">
                <div class="leftdown">
                    <asp:Label ID="Label29" runat="server" Height="16px"
                        Text="2 аперля 2016г." style="font-size:16px;"></asp:Label>
                </div>
                <div class="rightdown">
                    <asp:Label ID="Label30" runat="server" Height="16px"
                        Text="7 апреля 2016г." style="font-size:16px;"></asp:Label>
                </div>
            </div>
        </div>
            <div class="rightcommissiongover">
            <asp:ListView runat="server" ID="ListView3" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:140px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:410px; height:140px;" runat="server">
                    <div class="upcommgover">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                            
                        </div>
                        <div class="infocommgover">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_man")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_man")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label20" runat="server" ForeColor="#465566" Width="300px"
                                Text="Сотрудник государственной службы по охране труда и производственной безопасности при аттестации"
                                style="font-size:14px;"></asp:Label>
                            
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>            
        </div>
        </div>


        <div class="rightcommission">
            <asp:ListView runat="server" ID="ProductsListView4" GroupItemCount="3">
                <LayoutTemplate>
                    <table cellpadding="2" runat="server"
                        id="tblProducts" style="height:100px">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>                  
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="productRow"
                        style="height:80px">
                    <td runat="server" id="itemPlaceholder">
                    </td>
                    </tr>
                </GroupTemplate>
                
                <ItemTemplate>
                    <td valign="top" align="center" style="width:310px; height:100px;" runat="server">
                    <div class="upcomm">
                        <div class="imagec">
                            <img src='<%#"~/Image/"+ Eval("Image_Photo") %>' alt="" runat="server" class="imagecom"/>                            
                        </div>
                        <div class="infocomm">
                            <asp:Label ID="Label1" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Patronymic_vp")%>' 
                                style="font-size:20px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Name_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#465566" Height="16px" 
                                Text='<%#Eval("Surname_vp")%>' 
                                style="font-size:16px;"></asp:Label>
                            <br />  
                             <asp:Label ID="Label20" runat="server" ForeColor="#465566" Height="16px"
                                Text="Должность"
                                style="font-size:14px;"></asp:Label>
                            <br />
                            <asp:Label ID="Label21" runat="server" ForeColor="#465566" Height="16px"
                                Text='<%#Eval("Position")%>' 
                                style="font-size:16px;"></asp:Label>                   
                        </div>
                    </div> 
                    <div class="downcomm">

                    </div>                       
                    </td>
                </ItemTemplate>
            </asp:ListView>
            <hr />
        </div>




    </div>
    &nbsp;
</asp:Content>