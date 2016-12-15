$(document).ready(function () {
    $("#uploadVideos").bind("click", function (e) {
        e.preventDefault();
        SendFileToServer("VideoUploads","UploadVideo");
    });

    $("#uploadAudios").bind("click", function (e) {
        e.preventDefault();
        SendFileToServer("AudioUploads", "UploadAudio");
    });

    $("#uploadPhotos").bind("click", function (e) {
        e.preventDefault();
        SendFileToServer("PhotoUploads", "UploadPhoto");
    });

    function ShowLoader() {
    $("#Loader").show();
}

function HideLoader() {
    $("#Loader").hide();
}

function SendFileToServer(url,formid) {
    $.ajax({
        url:url,
        method:"Post",
        data:$('#'+formid).serialize(),
        beforeSend:ShowLoader(),
        complete: function (data) {
            HideLoader();
            $("#UploadMessage").empty().html(data);
        }
    })
}
})

