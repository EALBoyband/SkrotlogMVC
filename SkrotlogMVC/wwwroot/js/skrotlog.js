$(function () {
    let contractLine = 0;
    $(".plus").click(function () {
        contractLine++;
        $(".contractLine:first").clone().appendTo(".contractLines");
        $(".contractLine:last .form-group select").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group select").attr("value", "");
        $(".contractLine:last .form-group input").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group input").attr("value", "");
        $(".contractLine:last .form-group textarea").attr("name", "contractLineArray[][" + contractLine + "]");
        $(".contractLine:last .form-group textarea").html("");
        $(".contractLine:last").hide();
        $(".contractLine:last").slideToggle();
    });
});