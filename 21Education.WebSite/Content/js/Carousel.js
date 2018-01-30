; (function ($) {
    $.fn.extend({
        Carousel: function (options) {
            var defaults = {
                carouselIndex: 1,
                imgWidth: 900,
                spaceInterval: 3,
                plugClassName: "",
                showCount: 1
            }
            var options = $.extend(defaults, options);
            var defalutIndex = 1;
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
            function play() {
                clearInterval(autoPlayInterval);
                var animateLength = options.carouselIndex * (-options.imgWidth) + "px";
                if (options.carouselIndex > imgCount) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -options.imgWidth + "px")
                    });
                    options.carouselIndex = defalutIndex;
                }
                else if (options.carouselIndex < defalutIndex) {
                    $container.stop(true, true).animate({ "left": animateLength }, "slow", function () {
                        $(this).css("left", -imgCount * options.imgWidth + "px")
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
            void function Init() {
                $preview.each(function () {
                    $(this).children().eq(0).addClass("active");
                });
            }();
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