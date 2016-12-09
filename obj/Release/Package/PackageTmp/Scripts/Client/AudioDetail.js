$(document).ready(function () {
    $("#audioDescriptionHandler").bind("click", function () {
        if ($("#audioDescriptionContent").css("visibility") == "visible")
            $("#audioDescriptionContent").css("visibility", "hidden").fadeOut("slow").slideUp("slow");
        else
            $("#audioDescriptionContent").css("visibility", "visible").fadeIn("slow").slideDown("slow");
    });

    $("#audioLyricsHandler").bind("click", function () {
        if($("#audioLyrics").css("visibilty") == "visible")
            $("#audioLyrics").css("visibilty","hidden").fadeOut("slow").slideUp("slow");
        else
            $("#audioLyrics").css("visibilty","visible").fadeIn("slow").slideDown("slow");
    })
})