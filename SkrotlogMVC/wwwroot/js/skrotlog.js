$(function () {
    let materialNum = 0;
    $(".plus").click(function () {
        materialNum++;
        $(".material:first").clone().appendTo(".materials");
        $(".material:last input").attr("name", "materialArray[][" + materialNum + "]");
        $(".material:last").hide();
        $(".material:last").slideToggle();
    });
});