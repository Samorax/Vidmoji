document.addEventListener("DOMContentLoaded", mediaContentLoad, false);

function mediaContentLoad() {
    $(".VideoItems").each(function () {
        var currentTarget = $(this);
        currentTarget.onselect = function () {
            $.ajax({
                url: "GetVideos/" + currentTarget.value,
                type: "Get",
                dataTpye:"Json",
                error:function(){
                    console.log("Ajax method encountered an error. Response form server not sent.");
                    alert("Unable to retrieve response from server.Please check your network connection.");
                },
                success: function(data){
                    console.log("Ajax method successful");
                    $(".itemsSpace").each(function () {
                        if (currentTarget.first)
                            $(this).first.empty().html(data);
                        $(this).empty().html(data);
                    })
                }
                });
        }
    })
}