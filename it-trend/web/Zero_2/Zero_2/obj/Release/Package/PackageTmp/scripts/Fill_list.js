function SelectCommission() {
    $.ajax({
        type: "POST",
        url: this.location.href + "/Fill_Commission",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Commission,
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
function Commission(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var commission1 = xml.find("Name_vp");
    var commission2 = xml.find("Surname_vp");
    var commission3 = xml.find("Patronymic_vp");
    //var that = $("ul.cities_list");
    var that = $('.list1');
    var i = 0;
    $(commission1).each(function () {
        $('<option />', {
                    text: $(this).text() + " " + $(commission2[i]).text() + " " + $(commission3[i]).text(),
                    //value: $(this).attr('Material')
                }).appendTo(that);
                
        i++;
    });
    //$(commission1).each(function () {
    //    $('<option />', {
    //        text: $(this).text() + " " + commission2[i] + " " + commission3[i],
    //        //value: $(this).attr('Material')
    //    }).appendTo(that);
    //    i++;
    //});
    i = 0;
}
$(function () {
    //SelectCommission();
    $('.delivery_list').click(function () {
        $(".cities_list").slideToggle('fast');
    });
    $('ul.cities_list li').click(function () {
        var tx = $(this).text();
        //var tv = $(this).attr('alt');
        $(".cities_list").slideUp('fast');
        $(".delivery_list span").html(tx);
        //$(".delivery_text").html(tv);
    });
})