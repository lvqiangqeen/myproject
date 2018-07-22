$(function() {
    var $container = $('#masonry');
    $container.imagesLoaded(function() {
        $container.masonry({
                itemSelector: '.box',
                gutter: 12,
                isAnimated: true,
            });
     });
});





