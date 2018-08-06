$(function () {
    $('img.lazy').lazyload({
        effect: "fadeIn",
        failurelimit: 10,
        threshold: 10
    });
    $('.works-type p').on('touchstart', function () {
        $('.works-type .type').toggle();
    });
    //
    $('.filter .tab li').on('touchstart', function () {
        var index = $(this).index();
         var maskHeight = $('.container')[0].scrollHeight - 95;
        if ($('.filter .filter-select').eq(index).is(':visible')) {
            $('.filter .filter-select').eq(index).hide();
            $(this).removeClass('on');
            $('.filter .mask').hide();
        }
        else {
            $(this).addClass('on').siblings().removeClass('on');
            $('.filter .filter-select').eq(index).show().siblings('.filter-select').hide();
           $('.filter .mask').show().css('height', maskHeight);
        }
    });
    //
    var id = $("#updateCaseId").val();
    setTimeout(function () {
        $('.tumax-img-box span').show()
    }, 1000);
});