$(document).ready(function () {
    $("#photoDescriptionHandler").bind("click", function () {
        if ($("#photoDescriptionContent").css("visibility") == "visible")
            $("#photoDescriptionContent").css("visibility", "hidden").fadeOut("slow").slideUp("slow");
        else
            $("#photoDescriptionContent").css("visibility", "visible").fadeIn("slow").slideDown("slow");
    });

    $("#photoLyricsHandler").bind("click", function () {
        if($("#photoLyrics").css("visibilty") == "visible")
            $("#photoLyrics").css("visibilty","hidden").fadeOut("slow").slideUp("slow");
        else
            $("#photoLyrics").css("visibilty","visible").fadeIn("slow").slideDown("slow");
    })
})