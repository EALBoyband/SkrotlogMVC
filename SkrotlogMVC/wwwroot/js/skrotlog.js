$(function () {
    let contractLine = 0;
    $(".plus").click(function () {
        contractLine++;
        $(".contractLine:first").clone().appendTo(".contractLines");
        $(".contractLine:last .form-group select").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group select option:first").attr("selected", "");
        $(".contractLine:last .form-group input").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group input").val("");
        $(".contractLine:last .form-group textarea").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group textarea").val("");
        $(".contractLine:last").hide();
        $(".contractLine:last").slideToggle();
    });

    //$(".contract").click(function () {
    //    $("tbody tr:nth-child(2)").slideToggle();
    //});
});