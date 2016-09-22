//(function (XTModal, $, undefined) {
//    "use strict";
//    $.fn.xtmodal = function (option) {
//        return this.each(function () {
//            var $this = $(this);
//            var data = $this.data('xtmodal');
//            var options = $.extend({}, $.fn.xtmodal.defaults, typeof option == 'object' && option);
//            if (!data) {
//                $this.data('xtmodal', (data = new XTModal(this, options)));
//            }
//            if (typeof option == 'string') {
//                data[option]();
//            }
//        });
//    };
//    function XTModal(element, options) {
//        this.$element = $(element);
//        this.$opt = $.extend({}, $.fn.xtmodal.defaults, options);
//        this.init();
//    }

//    XTModal.prototype = {
//        init: function () {
//            this.url = XGeneral.path;
//            //
//            var $self = this;
//            var $opt = this.$opt;
//            this.$element.on("click", function (e) {
//                var target = $(e.target);
//                return false;
//                var data = this.dataItem($(e.currentTarget).closest("tr"));
//                $self.construct($opt);
//            });
//        },
//        construct: function (data) {
//            var $self = this;
//            var url = this.url;
//            switch (data.type) {
//                case 1:
//                    url += '/modal/bootstrap';
//                    break;
//            }
//            $.ajax({
//                url: url,
//                data: {},
//                type: "post"
//            }).done(function (html, textStatus, xhr) {
//                console.log(html);
//                $("body").append(html);
//            }).fail(function () {
//            }).always(function () {
//            });
//        },
//        show: function (data) {

//        }
//    };

//    var oldxtmodal = $.fn.xtmodal;
//    $.fn.xtmodal.defaults = {};
//    $.fn.xtmodal.Constructor = XTModal;
//    $.fn.xtmodal.noConflict = function () {
//        $.fn.xtmodal = oldxtmodal;
//        return this;
//    };
//    $('[data-x="x-tmodal"]').livequery(function () {
//        var $this = $(this), data = $(this).data();
//        $this.xtmodal(data);
//    });



//}(window.XTModal = window.XTModal || {}, jQuery));

(function (XModal, $, undefined) {
    XModal.initModal = function (data) {
         //data.path = XGeneral.path +data.path;
         var selector = data.selector;
        var functionToCall = "XModal.kendo";
        switch (data.type) {
            case 1:
                functionToCall = "XModal.bootstrap";
                break;
            case 2:
                functionToCall = "XModal.kendo";
                break;
        }
        var xmodal = $(selector);
        XGeneral.execute(functionToCall, window, xmodal, data);
    };

    XModal.bootstrap = function (xmodal, data) {

        var urlbody = XGeneral.serverpath + data.path;
        $.ajax({
            url: urlbody,
            data: {},
            type: "post"
        }).done(function (htmlbody, textStatus, xhr) {
            console.log(htmlbody);
            xmodal.find(".blBodyModal").html(htmlbody);
            xmodal.modal('show');
            xmodal.on('hidden.bs.modal', function (e) {
                xmodal.remove();
                xmodal.data('modal', null);
                $(".modal-backdrop").remove();
            });
        });
    };


    XModal.kendo = function (xmodal, data) {
        //to implement   
        var urlbody = XGeneral.serverpath + data.path;
        $.ajax({
            url: urlbody,
            data: {},
            type: "post"
        }).done(function (htmlbody, textStatus, xhr) {
            console.log(xmodal);
            xmodal.find(".blBodyModal").html(htmlbody);
            BLExt.InitModal(xmodal.attr("id"), function() {}, "50%");
        });
        

    };

}(window.XModal = window.XModal || {}, jQuery));


//var initModal = function (e) {
//    var options = $(e.target).data();
//    var data = this.dataItem($(e.currentTarget).closest("tr"));
//    if (options.title) {
//        var namespaces = options.title.split(".");
//        var title = data;
//        if (namespaces.length > 1) {
//            for (var i = 0; i < namespaces.length; i++) {
//                title = title[namespaces[i]];
//            }
//        } else {
//            title = data[options.title];
//        }
//        options.title = title;
//    }
//    options.isbuttons = (options.isbuttons) ? options.isbuttons : false;
//    var extend = jQuery.extend(data, options);
//    XModal.init(e, extend);
//};

//Modales Terminos y condiciones
$(document).ready(function () {
    $("#terms-cuenta").click(function () {
        $("#terms").modal();
    });
});

$(document).ready(function () {
    $("#response-summary").click(function () {
        $("#response_request").modal();
    });
});

$(document).ready(function () {
    $("#terms-tarjeta").click(function () {
        $("#terms2").modal();
    });
});
//Modales de aprobacion
$(document).ready(function () {
    $("#myBtn").click(function () {
        $("#myModal").modal();
    });
});

$(document).ready(function () {
    $("#BtnTarjeta").click(function () {
        $("#tarjeta").modal();
    });
});