; (function ($) {
    $.fn.extend({
        Shade: function (
            css = {
                position: "absolute",
                width: $this.offsetWidth,
                height: $this.offsetHeight,
                background: "#ccc",
                left: "0",
                top: "0",
                zIndex: 999,
                opacity: 0.4
            }
        ) {

            //var defaults = {
            //    carouselIndex: 1,
            //    imgWidth: 900,
            //    spaceInterval: 3,
            //    plugClassName: "",
            //    showCount: 1,
            //    imgHeight: 300,
            //    imgMargin:0,
            //    containerWidth: 900
            //}
            //var css = $.extend(defaults);
            $this = $(this);
            $this.each()
            void function Init() {
                $this.each(function () {
                    var $this = $(this);
                    $this.
                        css({ "position": "relative", "overflow": "hidden" }).
                        append($("<div>").
                            css(css).hover(
                            function () {
                                $(this).stop(true, true).animate({ top: 0 }, "fast", function () {

                                });
                            },
                            function () {
                                $(this).stop(true, true).animate({ top: 0 });
                            }
                            ));
                });
            }();
            return $this;
        }
    });
})(jQuery);