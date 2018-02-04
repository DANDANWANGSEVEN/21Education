; (function ($) {
    $.fn.extend({
        Carousel: function (options) {
            var defaults = {
                carouselIndex: 1,
                imgWidth: 900,
                spaceInterval: 3,
                plugClassName: "",
                showCount: 1,
                imgHeight: 300,
                imgMargin: 0,
                containerWidth: 900
            }
            if (options.showCount > 1) options.carouselIndex = options.showCount;
            var options = $.extend(defaults, options);
            var $this = $(this);
            var autoPlayInterval = null;
            var $container = $this.find(".slider-container");
            var imgCount = (function () { return $container.children().length - 2 * options.showCount; })();
            var $preview = $(".preview" + options.plugClassName);
            var realWidth = options.imgWidth + options.imgMargin;
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
            var isSupported = window.CSS && window.CSS.supports && window.CSS.supports('--a', 0);
            function SetAutoPlayInterval() {
                autoPlayInterval = setInterval(function () {
                    $this.find(".carousel-next").click();
                }, options.spaceInterval * 1000);
            }
            function play() {
                clearInterval(autoPlayInterval);
                var animateLength = options.carouselIndex * -realWidth + "px";
                if (options.carouselIndex == options.showCount + imgCount) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -realWidth * options.showCount + "px")
                    });
                    options.carouselIndex = options.showCount;
                }
                else if (options.carouselIndex == 0) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -realWidth * imgCount + "px")
                    });
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
            this.__proto__.Carousel.stop = function () {
                alert(1);
            }
            void function Init() {
                if (!isSupported) {
                    /* Not supported */
                    $this.find(".container").css({ "width": options.containerWidth, "height": options.imgHeight });
                    $this.find(".container .slider-container").css({ "left": -realWidth * options.showCount, "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item").css({ "width": options.imgWidth, "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item img").css({ "width": options.imgWidth, "height": options.imgHeight });
                    $this.find(".container .slider-container .slider-item span").css({ "width": options.imgWidth });
                }
                SetAutoPlayInterval();
                $preview.each(function () {
                    $(this).children().eq(0).addClass("active");
                });
            }();
            return $this;
        }
    });
})(jQuery);