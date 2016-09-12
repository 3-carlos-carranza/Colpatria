if (!window.location.origin) {
    window.location.origin = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '');
}

(function (XGeneral, $, undefined) {
    "use strict";

    XGeneral.path = "";
    XGeneral.serverpath = window.location.origin;
    XGeneral.url = "";


    XGeneral.init = function (data) {
        XGeneral.path = data.path;
    };

    XGeneral.loading = function (text) {
        if ($.blockUI) {
            if (text == undefined || text == "") {
                text = 'Procesando su solicitud';
            }
            $.blockUI({
                message: text,
                baseZ: 100000,
                css: {
                    //'font-family': 'Titillium Web',
                    //'font-size': '16px',
                    width: '50%',
                    left: '25%',
                    border: 'none',
                    padding: '10px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });
        }
    };

    XGeneral.loadingFull = function (text) {
        if ($.blockUI) {
            if (text == undefined || text == "") {
                text = 'Procesando su solicitud';
            }

            $.blockUI({
                message: text,
                overlayCSS: {
                    backgroundColor: '#fbfbfb',
                    opacity: 1,
                    cursor: 'wait',
                },
                baseZ: 100000,
                css: {
                    //'font-family': 'Titillium Web',
                    //'font-size': '16px',
                    width: '60%',
                    left: '22%',
                    border: 'none',
                    padding: '10px',
                    fontWeight: 'light',
                    fontSize: '1.5em',
                    backgroundColor: 'transparent',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: 1,
                    color: '#B8D900'
                }
            });
        }
    };

    XGeneral.toastrInfo = function (data) {
        toastr.options = $.extend({}, {
            closeButton: true,
            debug: false,
            positionClass: data.positionClass || "toast-top-full-width",
            showDuration: data.showDuration || 300,
            hideDuration: data.hideDuration || 1000,
            timeOut: data.timeOut || 5000,
            extendedTimeOut: data.extendedTimeOut || 1000,
            showEasing: data.showEasing || "swing",
            hideEasing: data.hideEasing || "linear",
            showMethod: data.showMethod || "fadeIn",
            hideMethod: data.hideMethod || "fadeOut"
        }, data.options || {});
        toastr.info(data.text || "Informaci�n");
    };

    XGeneral.toastrSuccess = function (data) {
        toastr.options = $.extend({}, {
            closeButton: true,
            debug: false,
            positionClass: data.positionClass || "toast-top-full-width",
            showDuration: data.showDuration || 300,
            hideDuration: data.hideDuration || 1000,
            timeOut: data.timeOut || 5000,
            extendedTimeOut: data.extendedTimeOut || 1000,
            showEasing: data.showEasing || "swing",
            hideEasing: data.hideEasing || "linear",
            showMethod: data.showMethod || "fadeIn",
            hideMethod: data.hideMethod || "fadeOut"
        }, data.options || {});
        toastr.success(data.text || "Solicitud procesada con exito");
    };

    XGeneral.toastrWarning = function (data) {
        toastr.options = $.extend({}, {
            closeButton: true,
            debug: false,
            positionClass: data.positionClass || "toast-top-full-width",
            showDuration: data.showDuration || 300,
            hideDuration: data.hideDuration || 1000,
            timeOut: data.timeOut || 5000,
            extendedTimeOut: data.extendedTimeOut || 1000,
            showEasing: data.showEasing || "swing",
            hideEasing: data.hideEasing || "linear",
            showMethod: data.showMethod || "fadeIn",
            hideMethod: data.hideMethod || "fadeOut"
        }, data.options || {});
        toastr.warning(data.text || "Advertencia");
    };

    XGeneral.toastrError = function (data) {
        toastr.options = $.extend({}, {
            closeButton: true,
            debug: false,
            positionClass: data.positionClass || "toast-top-full-width",
            showDuration: data.showDuration || 300,
            hideDuration: data.hideDuration || 1000,
            timeOut: data.timeOut || 5000,
            extendedTimeOut: data.extendedTimeOut || 1000,
            showEasing: data.showEasing || "swing",
            hideEasing: data.hideEasing || "linear",
            showMethod: data.showMethod || "fadeIn",
            hideMethod: data.hideMethod || "fadeOut"
        }, data.options || {});
        toastr.error(data.text || "Ooppss! Ha ocurrido un error!");
    };

    XGeneral.loadingclose = function (text, callback) {
        if ($.blockUI) {
            $.unblockUI();
        }
    };

    XGeneral.redirect = function (data) {
        console.log(data);
        if (data != undefined) {
            window.location = data.url;
        } else {
            console.log('LA URL Esta Mal Urgente !!!');
            window.location = window.location.pathname;
        }
    };

    XGeneral.execute = function (fname, context /*, args */) {
        var slice = Array.prototype.slice.call(arguments);
        var splice = slice.splice(2);
        var namespaces = fname.split(".");
        var func = namespaces.pop();
        for (var i = 0; i < namespaces.length; i++) {
            context = context[namespaces[i]];
        }
        return context[func].apply(this, splice);
    };

    XGeneral.Html = function (data) {
        $(".form-error").html("");
        $("#" + data.target).html(data.message);
    };

    XGeneral.Validate = function (data) {
    };

    XGeneral.gritter = function (data) {
        $.gritter.add(data);
    };

    XGeneral.callback = function (data, args) {
        var namespaces = data.functionName.split(".");
        window[namespaces[0]][namespaces[1]]();
    };

    XGeneral.executeCallbacks = function (responseText) {
        cache = {};
        var isJson = false;
        isJson = typeof responseText === 'object';
        if (isJson) {
            if (responseText.Callbacks == undefined) {
                return responseText;
            } else {
                var callbacks = responseText.Callbacks;
                console.log(callbacks);
                $.each(callbacks, function (funtion, vars) {
                    XGeneral.execute(funtion, window, vars);
                });
                return true;
            }
        } else {
            if (data.target != '') {
                $("#" + data.target).html(responseText);
                return true;
            } else {
                return responseText;
            }
        }
        return true;
    };

    var cache = {};
    XGeneral.Ajax = function (data) {
        return cache['Ajax'] || $.ajax({
            type: "POST",
            url: XGeneral.path + data.url,
            data: $.isFunction(data.vars) ? data.vars() : data.vars,
            success: XGeneral.executeCallbacks,
            error: function () {
            }
        });
    };

    XGeneral.Object2Array = function (obj) {
        var result = [];
        for (var i in obj)
            result[i] = obj[i];
        return result;
    };

    XGeneral.select2validate = function (context, args, field, rules, index, options) {
        var sel2 = context.context;
        if (sel2.id.indexOf('s2id_') > -1) {
            var value = $("#" + sel2.id).select2("val");
            if (value == "") {
                args.push('required');
                return rules.allrules.select2validate.alertText;
            }
        }
    };

    XGeneral.dropdownlistvalidate = function (context, args, field, rules, index, options) {
        var ddwn = $(context.context);
        if (ddwn.is("span")) {
            $(ddwn).data("prompt-position", "topLeft");
            var ele = ddwn.context.lastChild;
            var kdw = $(ele).data("kendoDropDownList");
            var dataItem = kdw.dataItem();
            if (kdw.value() === "" || dataItem == undefined) {
                args.push('required');
                return rules.allrules.validatedropdownlist.alertText;
            }
        }
    };



    // Add ECMA262-5 method binding if not supported natively
    //
    if (!('bind' in Function.prototype)) {
        Function.prototype.bind = function (owner) {
            var that = this;
            if (arguments.length <= 1) {
                return function () {
                    return that.apply(owner, arguments);
                };
            } else {
                var args = Array.prototype.slice.call(arguments, 1);
                return function () {
                    return that.apply(owner, arguments.length === 0 ? args : args.concat(Array.prototype.slice.call(arguments)));
                };
            }
        };
    }

    // Add ECMA262-5 string trim if not supported natively
    //
    if (!('trim' in String.prototype)) {
        String.prototype.trim = function () {
            return this.replace(/^\s+/, '').replace(/\s+$/, '');
        };
    }

    // Add ECMA262-5 Array methods if not supported natively
    //
    if (!('indexOf' in Array.prototype)) {
        Array.prototype.indexOf = function (find, i /*opt*/) {
            if (i === undefined)
                i = 0;
            if (i < 0)
                i += this.length;
            if (i < 0)
                i = 0;
            for (var n = this.length; i < n; i++)
                if (i in this && this[i] === find)
                    return i;
            return -1;
        };
    }
    if (!('lastIndexOf' in Array.prototype)) {
        Array.prototype.lastIndexOf = function (find, i /*opt*/) {
            if (i === undefined)
                i = this.length - 1;
            if (i < 0)
                i += this.length;
            if (i > this.length - 1)
                i = this.length - 1;
            for (i++; i-- > 0;) /* i++ because from-argument is sadly inclusive */
                if (i in this && this[i] === find)
                    return i;
            return -1;
        };
    }
    if (!('forEach' in Array.prototype)) {
        Array.prototype.forEach = function (action, that /*opt*/) {
            for (var i = 0, n = this.length; i < n; i++)
                if (i in this)
                    action.call(that, this[i], i, this);
        };
    }
    if (!('map' in Array.prototype)) {
        Array.prototype.map = function (mapper, that /*opt*/) {
            var other = new Array(this.length);
            for (var i = 0, n = this.length; i < n; i++)
                if (i in this)
                    other[i] = mapper.call(that, this[i], i, this);
            return other;
        };
    }
    if (!('filter' in Array.prototype)) {
        Array.prototype.filter = function (filter, that /*opt*/) {
            var other = [], v;
            for (var i = 0, n = this.length; i < n; i++)
                if (i in this && filter.call(that, v = this[i], i, this))
                    other.push(v);
            return other;
        };
    }
    if (!('every' in Array.prototype)) {
        Array.prototype.every = function (tester, that /*opt*/) {
            for (var i = 0, n = this.length; i < n; i++)
                if (i in this && !tester.call(that, this[i], i, this))
                    return false;
            return true;
        };
    }
    if (!('some' in Array.prototype)) {
        Array.prototype.some = function (tester, that /*opt*/) {
            for (var i = 0, n = this.length; i < n; i++)
                if (i in this && tester.call(that, this[i], i, this))
                    return true;
            return false;
        };
    }


}(window.XGeneral = window.XGeneral || {}, jQuery));


(function (BLExt, $, undefined) {

    //Notifications
    BLExt.notifyMessage = function (tittle, text, type) {

        // 1 error
        // 2 error info
        // 0 default
        var classinfo = '';
        switch (type) {
            case 1:
                classinfo = "gritter-error";
            case 2:
                classinfo = "gritter-info";
            default:
                classinfo = "gritter-light";
        }

        XGeneral.gritter({
            title: tittle,
            text: text,
            time: 3,
            class_name: classinfo
        });

    };


    //Modal Kendo
    BLExt.kIHeight = 0;
    BLExt.kIWidth = 0;
    BLExt.isResize = false;

    BLExt.InitModal = function (idelement, isvisible, width, tittle, onClose) {
        var kwindow = $('#' + idelement).kendoWindow({
            actions: ["Close"], /*from Vlad's answer*/
            draggable: false,
            height: "auto",
            modal: true,
            resizable: false,
            title: tittle || " Alerta ",
            width: width,
            animation: false,
            pinned: true,
            visible: isvisible(),
            close: onClose != undefined ? onClose : function () { }
        }).data("kendoWindow");

        BLExt.kIHeight = kwindow.wrapper.height();
        BLExt.kIWidth = kwindow.wrapper.width();
        BLExt.CenterModal(kwindow);
        $(window).resize(function () {
            BLExt.CenterModal(kwindow);
        });
        kwindow.open().center();
        BLExt.CenterModal(kwindow);
    };

    BLExt.CenterModal = function (kwindow) {
        var width = $(window).width(), height = $(window).height(), kwwidth = kwindow.wrapper.width(), kwheight = kwindow.wrapper.height();
        if (height > (kwheight + 30)) {
            kwindow.wrapper.css({
                top: (height - kwindow.wrapper.height()) / 2
            });
            if (BLExt.isResize) {
                if (BLExt.kIHeight > height) {
                    kwindow.wrapper.css({ height: height });
                } else {
                    BLExt.isResize = false;
                    kwindow.wrapper.css({
                        top: (height - BLExt.kIHeight) / 2,
                        height: BLExt.kIHeight
                    });
                    $(kwindow.wrapper.context).css({
                        overflow: 'hidden',
                        height: '100%'
                    });
                }

            }
        } else {
            BLExt.isResize = true;
            kwindow.wrapper.css({
                top: 0,
                height: height - 30
            });
            $(kwindow.wrapper.context).css({
                overflow: 'auto'
            });
        }
        if (width > kwwidth) {
            kwindow.wrapper.css({
                left: (width - kwindow.wrapper.width()) / 2
            });
        } else {
            kwindow.wrapper.css({
                left: 0
            });
        }
    };

    BLExt.Init = function (culture) {
        $(document).ready(function () {

            // Set culture
            var thisCulture = culture || "es-CO";
            kendo.culture(thisCulture);
            $('.onlyletter').livequery(function () {
                $(this).validateLetters();
            });
            $('.onlynumber').livequery(function () {
                $(this).validateNumbers();

            });

            $('.validateBirthDay').livequery(function () {
                $(this).datepicker({
                    maxDate: '-18Y',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-100:+0"
                });
            });

            $('.validateMaxToday').livequery(function () {
                $(this).datepicker({
                    maxDate: '-1D',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-100:+0"
                });
            });

            $('[data-json="modal"]').livequery(function () {
                var c = $(this).text();
                if (c)
                {
                    var j = JSON.parse(c);
                    XGeneral.executeCallbacks(j)
                }
            });

            $('[data-x="x-kdropdown"]').livequery(function () {
                var $this = $(this), data = $(this).data();
                $this.kdropdown(data);
            });

            $('[data-xktooltip]').livequery(function () {
                var $this = $(this), data = $(this).data();
                $this.ktooltip(data);
            });

            $('[data-x="x-kcombobox"]').livequery(function () {
                var $this = $(this), data = $(this).data();
                $this.kcombobox(data);
            });
        });


    };

    // CallServer
    BLExt.GetDataServer = function (url, parametros, callback, withprogress) {

        try {

            var datosparametros = JSON.stringify(parametros, "").replace("\n", "");
            $.ajax({
                url: url,
                data: datosparametros,
                dataType: "json",
                traditional: true,
                async: true,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    callback(data);
                },
                error: function (request, status, error) {
                    console.log(error);
                }, beforeSend: function () {
                    if (withprogress == false) {
                    } else {
                        XGeneral.loading("Cargando");
                    }

                }, complete: function () {
                    XGeneral.loadingclose("");
                }
            });
        }
        catch (err) {
            var txt = "There was an error on this page.\n\n";
            txt += "Error description: " + err.message + "\n\n";
            console.error(txt);
        }

    };


}(window.BLExt = window.BLExt || {}, jQuery));



//Customm Validations

function validateKendoDrop(field, rules, i, options) {
    if (field.context != undefined && field.context.children != undefined && field.context.children[1] != undefined) {
        var inputvalue = field.context.children[1];
        if ($(inputvalue).val() === "") {
            rules.push('required');
            return options.allrules.validatedropdownlist.alertText;
        }
    }
}

function validateRadioYes(field, rules, i, options) {
    var valuetovalidate = $(field.context).attr("data-defaultvalue");
    //console.log($(field.context).attr("name"));
    var inputvalue = '';
    // console.log(valuetovalidate);
    var radioseleted = $("input[name='" + $(field.context).attr("name") + "']:checked");
    if (radioseleted != undefined) {
        inputvalue = radioseleted.val();
        console.log(inputvalue);
        if (valuetovalidate != inputvalue) {
            rules.push('required');
            return options.allrules.validateTerm.alertText;
        }

    } else {
        rules.push('required');
        //return options.allrules.validatedropdownlist.alertText;
    }
    // rules.push('required');
    //return options.allrules.validateTerm.alertText;
}

$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '<Ant',
    nextText: 'Sig>',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};
$.datepicker.setDefaults($.datepicker.regional['es']);

jQuery.fn.validateLetters = function () {
    $(this).keypress(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
            // Permitir: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
            // Permitir: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            // let it happen, don't do anything
            return true;
        } else {
            var inputValue = event.charCode;
            if ((inputValue > 47 && inputValue < 58) && (inputValue != 32)) {
                event.preventDefault();
            }
        }


    });
};
jQuery.fn.validateNumbers = function () {
    $(this).keydown(function (event) {
        // Permite: backspace, delete, tab, escape, and enter
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
            // Permitir: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
            // Permitir: home, end, left, right
                (event.keyCode >= 35 && event.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        else {
            // Ensure that it is a number and stop the keypress

            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
    $(this).blur(function () {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            var con = this.value.indexOf(",");
            if (con == -1) {
                /*  this.value = this.value.replace(',', '');
                  this.value = this.value.replace(/\D/g, '');*/

            } else {
                /* $(this).parseNumber({ format: "#,###", locale: "us" });
                 $(this).formatNumber({ format: "#,###", locale: "us" });
                 */

                if (this.value == '') {
                    this.value = '';
                    //this.value = '0';
                }
            }
        } else {
            var co = this.value.indexOf(",");
            if (co == -1) {
                //$(this).parseNumber({ format: "#,###", locale: "us" });
                //$(this).formatNumber({ format: "#,###", locale: "us" });
                if (this.value == '') {
                    this.value = '';
                    //this.value = '0';
                }
            }
        }
    });


};
