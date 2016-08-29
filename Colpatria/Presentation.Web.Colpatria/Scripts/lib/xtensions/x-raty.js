!function ($) {
    "use strict";

    $.fn.xrating = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data('xrating');
            var options = $.extend({}, $.fn.xrating.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xrating', (data = new XRating(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };

    function XRating(element, options) {
        this.$el = $(element);
        this.options = $.extend({}, $.fn.xrating.defaults, options);
        this.init(element);
    }


    XRating.prototype = {
        init: function (element) {
            var $options = this.options;
            this.$el.raty($options);
            if ($("#clasification-template").length) {
                var id = $options.id;
                var data = {
                    id:$options.id,
                    clasification: $options.score,
                    cost: $options.cost,
                    benefits: $options.benefits,
                    assistance: $options.assistance,
                    insurance: $options.insurance,
                    flexibility: $options.flexibility
                };
                var template = kendo.template($("#clasification-template").html());
                var result = template(data);
                var popover = this.$el.popover({
                    html: true,
                    placement: 'top',
                    trigger: 'click',
                    title: 'Clasificación',
                    content: result,
                    selector: true
                });

                
                $(element).on('click', function (e,a) {

                  
                    var id = $(this).data('id');
                    
                    $("#clasification-" + id + " .elementodeayuda").popover({
                        placement: 'right',
                        title: 'Text',
                        trigger: 'click'
                    });

                });

               
               
            }
            //$(".tip").tooltip();
        }
    };

    var oldxrating = $.fn.xrating;
    $.fn.xrating.defaults = {
        number: 5,
        readOnly: true,
        starHalf: '/Images/lib/raty/star-half.png',
        starOff: '/Images/lib/raty/star-off.png',
        starOn: '/Images/lib/raty/star-on.png'
    };
    $.fn.xrating.Constructor = XRating;
    $.fn.xrating.noConflict = function () {
        $.fn.xrating = oldxrating;
        return this;
    };


    $('[data-x="x-rating"]').livequery(function () {
        var $this = $(this), data = $(this).data();
        $this.xrating(data);
    });

}(window.jQuery);