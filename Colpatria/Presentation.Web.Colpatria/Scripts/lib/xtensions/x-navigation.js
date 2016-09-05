!function ($) {
    "use strict";

    $.fn.xnavigation = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data('xnavigation');
            var options = $.extend({}, $.fn.xnavigation.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xnavigation', (data = new XNavigation(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };

    function XNavigation(element, options) {
        this.$el = $(element);
        this.$form = $(element).closest("form");
        this.init();
    }


    XNavigation.prototype = {
        init: function () {
            var self = this;
            this.$el.on("click", function (e) {
                e.preventDefault();
                var data = self.$el.data();
                if (data.order < data.currentorder) {
                    $.each(data, function (i, value) {
                        $('<input>').attr({
                            type: 'hidden',
                            name: i,
                            value: value
                        }).appendTo(self.$form);
                    });
                    self.$form.submit();
                }
                return;

            });
        }
    };

    var oldxnavigation = $.fn.xnavigation;
    $.fn.xnavigation.defaults = {};
    $.fn.xnavigation.Constructor = XNavigation;
    $.fn.xnavigation.noConflict = function () {
        $.fn.xnavigation = oldxnavigation;
        return this;
    };
    $('[data-x="x-navigation"]').livequery(function () {
        var $this = $(this), data = $(this).data();
        $this.xnavigation(data);
    });

}(window.jQuery);
