function ExecuteService(params1, params2, url, callbackSuccess) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8", //вот это меня смущает, что то нужно поменять?
        dataType: "json",
        data: params1, params2,
        success: callbackSuccess
    });
}

function CheckLogin(inputlogin, inputpassword, callbackResult)
{    
    var login = $(inputlogin)[0].value;
    var password = $(inputpassword)[0].value;
    if (login.length > 0 && password.length > 0)
    {            
        var params1 = JSON.stringify({ login: login });
        var params2 = JSON.stringify({ password: password });
        ExecuteService(
          params1, params2, 
          //"http://localhost:51955/Validation.svc/Authentification", //мой вебсервис с именем localhost (вроде как) и его метод
              "http://localhost:51955/Page/ValidationPage.aspx/Authentification",
          callbackResult          
        );    
    }
}

function onCheckLogin(msg)
{
    if (msg.d)
    {
        $("#authorizationbutton").text("#input_login").css("color", "green");
        
        //типа меняю в назавнии кнопки "вход" имя на введенное, просот так
    }
    else 
    {
        $("#authorizationbutton").text("#input_login").css("color", "red");
    }
} 
//function onError(XMLHttpRequest, textStatus, errorThrown)
//{
//    $("#loginMessage").text("Ошибка при выполнении AJAX-запроса. Попробуйте перезагрузить страницу.");
//}

//$("#input_login").blur(function () { CheckLogin("#input_login", "#input_password", onCheckLogin); })
//какой то обработчик события потери фокуса
//$("#input_password").blur(function () { CheckLogin("#input_password", "#input_password", onCheckLogin); })
// не знаю нужно ли это

//обработчик события по кнопке вход
//$(function () {    
//    $('.entry').click(function () {
//        CheckLogin("#input_login", "#input_password", onCheckLogin);;
//    });   
//})