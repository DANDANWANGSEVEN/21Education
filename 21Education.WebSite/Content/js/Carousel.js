; (function ($) {
    $.fn.extend({
        Carousel: function (options) {
            var defaults = {
                carouselIndex: 1,
                imgWidth: 900,
                spaceInterval: 3,
                plugClassName: "",
                showCount: 1,
                imgHeight: 300
            }
            if (options.showCount > 1) options.carouselIndex = options.showCount;
            var options = $.extend(defaults, options);
            //var defalutIndex = (function () { return $container.children().length - options.showCount; })();
            var $this = $(this);
            var autoPlayInterval = null;
            var $container = $this.find(".slider-container");
            var imgCount = (function () { return $container.children().length - 2 * options.showCount; })();
            var $preview = $(".preview" + options.plugClassName);
            $this.find(".carousel-prev").click(function () {
                options.carouselIndex--;
                play();
            });
            $this.find(".carousel-next").click(function () {
                options.carouselIndex++;
                play();
            });
            $preview.children().click(function () {
                var eq = $(this).index();
                options.carouselIndex = eq + 1;
                play();
            });
            const isSupported =
                window.CSS &&
                window.CSS.supports &&
                window.CSS.supports('--a', 0);
            function play() {
                clearInterval(autoPlayInterval);
                var animateLength = options.carouselIndex * (-options.imgWidth) + "px";
                if (options.carouselIndex == options.showCount + imgCount) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -options.imgWidth * options.showCount + "px")
                    });
                    options.carouselIndex = options.showCount;
                }
                else if (options.carouselIndex == 0) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -options.imgWidth * imgCount + "px")
                    });//??Èç¹ûÓÐshowcount 4
                    options.carouselIndex = imgCount;
                }
                else {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow");
                }
                $preview.each(function () {
                    $(this).children().eq(options.carouselIndex - 1).addClass("active").siblings().removeClass("active");
                });
                SetAutoPlayInterval();
            }
            void function Init() {
                if (!isSupported) {
                    /* Not supported */
                    $this.find(".container").css({ "width": options.imgWidth * options.showCount, "height": options.imgHeight });
                    $this.find(".container .slider-container").css({ "left": -options.imgWidth * options.showCount, "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item").css({ "width": options.imgWidth , "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item img").css({ "width": options.imgWidth, "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item span").css({ "width": options.imgWidth });
                }
                SetAutoPlayInterval();
                $preview.each(function () {
                    $(this).children().eq(0).addClass("active");
                });
            }();
            function SetAutoPlayInterval() {
                autoPlayInterval = setInterval(function () {
                    $this.find(".carousel-next").click();
                }, options.spaceInterval * 1000);
            }
            return $this;
        }
    });
})(jQuery);