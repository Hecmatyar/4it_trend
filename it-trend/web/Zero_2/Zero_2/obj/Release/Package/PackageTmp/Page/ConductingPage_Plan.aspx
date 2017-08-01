<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ConductingPage_Plan.aspx.cs" 
    Inherits="Zero_2.Page.CondactingPage_Plan"
    MasterPageFile="Conducting.master"  %>

<asp:Content ID="content1" ContentPlaceHolderID="SecondLevel" runat="server">    
    <link href="/style/StyleCond.css" rel="stylesheet" type="text/css" />
    <link href="/style/downlist.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script src="/scripts/dropdown.js"></script>
    
    <div class ="condinfo" runat="server">
        <div class="lr">            
            <div class="leftcond" style="float:left;">
                <asp:Button  CssClass="button button1" ID="Button1" runat="server" Text="Техника безопасности" 
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
                        Text="проходящих плановую аттестацию по дисциплине:" Height="31px"
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
                    <asp:Button ID="Button3" CssClass="button button1" runat="server" Text="Определить"  Width="200px" Height="40px" OnClick="Button3_Click"
                        style="border-radius:4px;  border:none;
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
      
    <%--<div class="whennothing" runat="server">
        <html>
            <body>
                <select id = "sex">
                <option value="m" selectes>Мужчина</option>
                <option value="f" selectes>Женщина</option>
                </select>   
                <select id = "names">
                </select>
                <script type="text/javascript">
                        window.onload = function () {
                        document.getElementById("sex").onchange();          
                    }
                    document.getElementById("sex").onchange = function () {
                        var fnames = ["Мария", "Анастасия", "Юлия", "Антуанетта"];
                        var mnames = ["Петр", "Василий", "Юрий", "Октавиан"];
                    setOptions(document.getElementById("names"), this.value == "m" ? mnames : fnames);
                    }
                function setOptions (sel, arr) {
                    var x, option; 
                    sel.innerHTML = "";
                    for(x = 0; x < arr.length; x++) {
                        option = document.createElement("option");
                        option.value = arr[x];
                        option.innerHTML = arr[x];
                        sel.appendChild(option); 
                    }               
                }
                </script>    
            </body>
        </html>        
        
              
        <div class="delivery_block" >
            <div class="delivery_list">
            <div id="btn"></div>
            <span>Москва</span> 
            </div>
            <ul class="cities_list" style="display: none;">
                <li alt="Самовывоз из офиса или курьером, Дмитровское шоссе, 9-а, стр. 5, 12:00—20:00">Москва</li>
                <li alt="Лаврский проезд, 5, 11:00—18:00">Санкт-Петербург</li>
                <li alt="пр. Ленина 12-а, 9:00—18:00">Нижний Новгород</li>
                <li alt="ул. Карима Тинчурина, 9, 9:00—18:00">Казань</li>
                <li alt="ул. Варфоломеева, 87/89, оф. 41, 9:00—18:00">Ростов-на-Дону</li>
                <li alt="ул. Радомская, 27, 9:00—18:00">Волгоград</li>
                <li alt="ул. 9-ая Тихая, 11, 9:00—18:00">Краснодар</li>
                <li alt="ул. Ульяновская, 37/41, оф. 3, 9:00—18:00">Саратов</li>                
            </ul>
        </div>        
        <div class="delivery_text">Самовывоз из офиса или курьером, Дмитровское шоссе, 9-а, стр. 5, 12:00—20:00</div>
    </div>--%>
</asp:Content>
