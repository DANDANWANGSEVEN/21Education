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