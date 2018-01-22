; (function ($) {
    $.fn.extend({
        Carousel: function (options) {
            var defaults = {
                carouselIndex: 1,
                imgWidth: 900,
                spaceInterval: 3
            }
            var options = $.extend(defaults, options);
            var defalutIndex = 1;
            var $this = $(this);
            var imgCount = (function () { return $(".slider-container").children().length - 2; })();
            var autoPlayInterval = null;
            $this.find(".carousel-prev").click(function () {
                options.carouselIndex--;
                play();
            });
            $this.find(".carousel-next").click(function () {
                options.carouselIndex++;
                play();
            });
            $this.find(".preview a").click(function () {
                var eq = $(this).index();
                options.carouselIndex = eq + 1;
                play();
            });
            function play() {
                clearInterval(autoPlayInterval);
                var animateLength = options.carouselIndex * (-options.imgWidth) + "px";
                if (options.carouselIndex > imgCount) {
                    $(".slider-container").stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -options.imgWidth + "px")
                    });
                    options.carouselIndex = defalutIndex;
                }
                else if (options.carouselIndex < defalutIndex) {
                    $(".slider-container").stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -3 * options.imgWidth + "px")
                    });
                    options.carouselIndex = imgCount;
                }
                else {
                    $(".slider-container").stop(true, true).animate({ "left": animateLength }, "slow");
                }
                $this.find(".preview a").eq(options.carouselIndex - 1).addClass("active").siblings().removeClass("active");
                SetAutoPlayInterval();
            }
            function SetAutoPlayInterval() {
                autoPlayInterval = setInterval(function () {
                    $this.find(".carousel-next").click();
                }, options.spaceInterval * 1000);
            }
            SetAutoPlayInterval();
            return $this;
        }
    });
})(jQuery);