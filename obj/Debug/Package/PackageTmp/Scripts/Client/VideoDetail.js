$(document).ready(function () {
    $("#videoDescriptionHandler").bind("click", function () {
        if ($("#videoDescriptionContent").css("visibility") == "visible")
            $("#videoDescriptionContent").css("visibility", "hidden").fadeOut("slow").slideUp("slow");
        else
            $("#videoDescriptionContent").css("visibility", "visible").fadeIn("slow").slideDown("slow");
    });

    $("#videoLyricsHandler").bind("click", function () {
        if($("#videoLyrics").css("visibilty") == "visible")
            $("#videoLyrics").css("visibilty","hidden").fadeOut("slow").slideUp("slow");
        else
            $("#videoLyrics").css("visibilty","visible").fadeIn("slow").slideDown("slow");
    })
})

