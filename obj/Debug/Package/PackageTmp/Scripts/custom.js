/* Navigation
 ========================================= */

/* Flex Slider
 ========================================= */
$(window).load(function () {
    $('.flexslider').flexslider({
        animation: "slide",
        start: function (slider) {
            $('body').removeClass('loading');
        }
    });
});

/* ScrollTop Button
 ================================================== */
$(window).scroll(function () {
    if ($(this).scrollTop() > 800) {
        $('.scroll-top a').fadeIn(200);
    } else {
        $('.scroll-top a').fadeOut(200);
    }
});
$('.scroll-top a').click(function (event) {
    event.preventDefault();

    $('html, body').animate({
        scrollTop: 0
    }, 1000);
});


$('#description-btn').click(function () {
  $(".video-detail .description-text").slideToggle('fast');

});

$('#lyrics-btn').click(function () {
    $(".video-detail .lyrics-text").slideToggle('fast');

});

/* Url Button
 ================================================== */
$('#url-btn').click(function () {
    /*$(".load-url-wrap").slideToggle('fast');*/
    $(".load-url-wrap").slideToggle('fast', function() {
        var flipout = this;

        if (flipout.style.display == "block") {
            windowHeight = $('.owl-item.active').innerHeight()-20;
            $('.owl-wrapper-outer').css('height', windowHeight);
        }
        else {
            windowHeight = $('.owl-item.active').innerHeight()-10;
            $('.owl-wrapper-outer').css('height', windowHeight);
        }
    });
});

$(window).resize(function(){
    windowHeight = $('.owl-item.active').innerHeight();
    $('.owl-wrapper-outer').css('height', windowHeight);
});

/* Ranger JS
 ================================================== */
$(function () {
    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
    var formatSecs = function (totalsecs) {
        var hour = parseInt(totalsecs / 3600, 10) % 24;
        var min = parseInt(totalsecs / 60, 10) % 60;
        var secs = totalsecs % 60;

        return pad(hour, 2) + ":" + pad(min, 2) + ":" + pad(secs, 2);
    };

    $("#slider-range-1").slider({
        range: true,
        min: 0,
        max: 81,
        values: [0, 81],
        step: 1,
        slide: function (event, ui) {
            var min = ui.values[0];
            var max = ui.values[1];
            $("#amount").val(formatSecs(min) + " - " + formatSecs(max));
            $("#start-1-amount").val(formatSecs(min));
            $("#end-1-amount").val(formatSecs(max));

            $('#slider-range-1 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min) + '</div></div>');
            $('#slider-range-1 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
        }
    });

    $("#amount").val(formatSecs($("#slider-range-1").slider("values", 0)) + " - " + formatSecs($("#slider-range-1").slider("values", 1)));


    $( ".ui-slider-handle" ).mouseleave(function() {
        $('.ui-slider-handle').html("");
    })
    $( ".ui-slider-handle" ).mouseenter(function() {
        var value = $( "#slider-range-2" ).slider( "option", "values" );

        $('#slider-range-1 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min)  + '</div></div>');
        $('#slider-range-1 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
    })
});

$(function () {
    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
    var formatSecs = function (totalsecs) {
        var hour = parseInt(totalsecs / 3600, 10) % 24;
        var min = parseInt(totalsecs / 60, 10) % 60;
        var secs = totalsecs % 60;

        return pad(hour, 2) + ":" + pad(min, 2) + ":" + pad(secs, 2);
    };

    $("#slider-range-2").slider({
        range: true,
        min: 0,
        max: 81,
        values: [0, 81],
        step: 1,
        slide: function (event, ui) {
            var min = ui.values[0];
            var max = ui.values[1];
            $("#amount").val(formatSecs(min) + " - " + formatSecs(max));
            $("#start-2-amount").val(formatSecs(min));
            $("#end-2-amount").val(formatSecs(max));

            $('#slider-range-2 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min) + '</div></div>');
            $('#slider-range-2 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
        }
    });

    $("#amount").val(formatSecs($("#slider-range-2").slider("values", 0)) + " - " + formatSecs($("#slider-range-2").slider("values", 1)));


    $( ".ui-slider-handle" ).mouseleave(function() {
        $('.ui-slider-handle').html("");
    })
    $( ".ui-slider-handle" ).mouseenter(function() {
        var value = $( "#slider-range-2" ).slider( "option", "values" );

        $('#slider-range-2 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min)  + '</div></div>');
        $('#slider-range-2 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
    })
});

$(function () {
    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
    var formatSecs = function (totalsecs) {
        var hour = parseInt(totalsecs / 3600, 10) % 24;
        var min = parseInt(totalsecs / 60, 10) % 60;
        var secs = totalsecs % 60;

        return pad(hour, 2) + ":" + pad(min, 2) + ":" + pad(secs, 2);
    };

    $("#slider-range-3").slider({
        range: true,
        min: 0,
        max: 81,
        values: [0, 81],
        step: 1,
        slide: function (event, ui) {
            var min = ui.values[0];
            var max = ui.values[1];
            $("#amount").val(formatSecs(min) + " - " + formatSecs(max));
            $("#start-3-amount").val(formatSecs(min));
            $("#end-3-amount").val(formatSecs(max));

            $('#slider-range-3 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min) + '</div></div>');
            $('#slider-range-3 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
        }
    });

    $("#amount").val(formatSecs($("#slider-range-3").slider("values", 0)) + " - " + formatSecs($("#slider-range-3").slider("values", 1)));


    $( ".ui-slider-handle" ).mouseleave(function() {
        $('.ui-slider-handle').html("");
    })
    $( ".ui-slider-handle" ).mouseenter(function() {
        var value = $( "#slider-range-3" ).slider( "option", "values" );

        $('#slider-range-3 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min)  + '</div></div>');
        $('#slider-range-3 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
    })
});

$(function () {
    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
    var formatSecs = function (totalsecs) {
        var hour = parseInt(totalsecs / 3600, 10) % 24;
        var min = parseInt(totalsecs / 60, 10) % 60;
        var secs = totalsecs % 60;

        return pad(hour, 2) + ":" + pad(min, 2) + ":" + pad(secs, 2);
    };

    $("#slider-range-4").slider({
        range: true,
        min: 0,
        max: 81,
        values: [0, 81],
        step: 1,
        slide: function (event, ui) {
            var min = ui.values[0];
            var max = ui.values[1];
            $("#amount").val(formatSecs(min) + " - " + formatSecs(max));
            $("#start-4-amount").val(formatSecs(min));
            $("#end-4-amount").val(formatSecs(max));

            $('#slider-range-4 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min) + '</div></div>');
            $('#slider-range-4 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
        }
    });

    $("#amount").val(formatSecs($("#slider-range-4").slider("values", 0)) + " - " + formatSecs($("#slider-range-4").slider("values", 1)));


    $( ".ui-slider-handle" ).mouseleave(function() {
        $('.ui-slider-handle').html("");
    })
    $( ".ui-slider-handle" ).mouseenter(function() {
        var value = $( "#slider-range-4" ).slider( "option", "values" );

        $('#slider-range-4 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min)  + '</div></div>');
        $('#slider-range-4 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
    })
});

$(function () {
    function pad(num, size) {
        var s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
    var formatSecs = function (totalsecs) {
        var hour = parseInt(totalsecs / 3600, 10) % 24;
        var min = parseInt(totalsecs / 60, 10) % 60;
        var secs = totalsecs % 60;

        return pad(hour, 2) + ":" + pad(min, 2) + ":" + pad(secs, 2);
    };

    $("#slider-range-5").slider({
        range: true,
        min: 0,
        max: 81,
        values: [0, 81],
        step: 1,
        slide: function (event, ui) {
            var min = ui.values[0];
            var max = ui.values[1];
            $("#amount").val(formatSecs(min) + " - " + formatSecs(max));
            $("#start-5-amount").val(formatSecs(min));
            $("#end-5-amount").val(formatSecs(max));

            $('#slider-range-5 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min) + '</div></div>');
            $('#slider-range-5 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
        }
    });

    $("#amount").val(formatSecs($("#slider-range-5").slider("values", 0)) + " - " + formatSecs($("#slider-range-5").slider("values", 1)));


    $( ".ui-slider-handle" ).mouseleave(function() {
        $('.ui-slider-handle').html("");
    })
    $( ".ui-slider-handle" ).mouseenter(function() {
        var value = $( "#slider-range-5" ).slider( "option", "values" );

        $('#slider-range-5 .ui-slider-handle:first').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(min)  + '</div></div>');
        $('#slider-range-5 .ui-slider-handle:last').html('<div class="tooltip top slider-tip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + formatSecs(max) + '</div></div>');
    })
});


/* File Upload Script
 ================================================== */

jQuery('.fileUpload .upload-file').change( function() {
    jQuery(this).next('.next-step').click();
    $('.step-header .step span').removeClass('current');
    $('.step-header .step span.step2').addClass('current');
});

/* Add Current Class in Step Script
 ================================================== */
$('#step1 .next').click(function(){
    $('.step-header .step span').removeClass('current');
    $('.step-header .step span.step2').addClass('current');
});

$('#step2 .next').click(function(){
    $('.step-header .step span').removeClass('current');
    $('.step-header .step span.step3').addClass('current');
});

$('#step3 .next').click(function(){
    $('.step-header .step span').removeClass('current');
    $('.step-header .step span.step1').addClass('current');
});


/* Add  Time Ranger
 ================================================== */

$('#add-new-time').click(function() {

    var n = $( ".video-control.non-active" ).length;

    $( ".video-control.non-active").first().addClass('block-active');
    $( ".video-control.non-active").first().removeClass('non-active');

    var show_n = $( ".video-control.block-active" ).length;

        windowHeight = $('.owl-item.active').innerHeight();
        /*alert(windowHeight);*/
        $('.owl-wrapper-outer').css('height', windowHeight);




        if(show_n==5){
            $('#add-new-time').css({display:'none'});
            windowHeight = $('.owl-item.active').innerHeight();
            /*alert(windowHeight);*/
            $('.owl-wrapper-outer').css('height', windowHeight);
        }





});


/* Remove Time Ranger
 ================================================== */
$('.optionBox').on('click','.delete-ranger-btn',function(e) {
    $(this).parent().parent().parent().removeClass('block-active');
    $(this).parent().parent().parent().addClass('non-active');

    var show_n = $( ".video-control.block-active" ).length;

    windowHeight = $('.owl-item.active').innerHeight();
    /*alert(windowHeight);*/
    $('.owl-wrapper-outer').css('height', windowHeight);

    /*if(show_n==4){
        windowHeight = $('.owl-item.active').innerHeight()+40;
        *//*alert(windowHeight);*//*
        $('.owl-wrapper-outer').css('height', windowHeight);
    }*/

    if(show_n<5){

        /*var w = window.innerWidth;*/

        $('#add-new-time').css({display:'inline-block'});


        windowHeight = $('.owl-item.active').innerHeight();
        /*alert(windowHeight);*/
        $('.owl-wrapper-outer').css('height', windowHeight);
    }
    e.preventDefault();
});


/* Instagram validtor
 ================================================== */
$('.instagram-username-input').keydown(function(){
    var val = $(this).val().replace(/\s+/g, '');
    var len = val.length;
    console.log(len);
    if(len > 1){
        $('.setting-inner-wrap .instagram-wrapper .i-checks i').removeClass('disable');
        $('.setting-inner-wrap .instagram-wrapper .i-checks input').removeAttr('disabled');

        $('.setting-inner-wrap .instagram-wrapper .radio-btn-wrapper b').css({'color':'black'});
        $('.setting-inner-wrap .instagram-wrapper .instagram-text').css({'color':'black'});

        $('.setting-inner-wrap .instagram-wrapper .instagram-username-input-wrap .validator').removeClass('none');
        $('.setting-inner-wrap .instagram-wrapper .instagram-username-input-wrap .validator').addClass('block');



    }
   else{
        $('.setting-inner-wrap .instagram-wrapper .radio-btn-wrapper b').css({'color':'#ddd'});
        $('.setting-inner-wrap .instagram-wrapper .instagram-text').css({'color':'#ddd'});
        $('.setting-inner-wrap .instagram-wrapper .i-checks i').addClass('disable');
        $('.setting-inner-wrap .instagram-wrapper .i-checks input').attr('disabled','disabled');
        $('.setting-inner-wrap .instagram-wrapper .instagram-username-input-wrap .validator').removeClass('block');
        $('.setting-inner-wrap .instagram-wrapper .instagram-username-input-wrap .validator').addClass('none');

    }
})