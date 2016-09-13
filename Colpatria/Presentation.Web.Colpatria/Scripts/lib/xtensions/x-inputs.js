(function(XMasked, $, undefined) {
    "use strict";
    $.fn.xmasked = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data("xmasked");
            var options = $.extend({}, $.fn.xmasked.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("xmasked", (data = new XMasked(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };
    function XMasked(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.xmasked.defaults, options);
        this.init();
    }
    XMasked.prototype = {
        init: function() {
            if ($.mask) {


                this.$element.mask(this.options.mask);
            }
        }
    };
    var old = $.fn.xmasked;
    $.fn.xmasked.defaults = {};
    $.fn.xmasked.Constructor = XMasked;
    $.fn.xmasked.noConflict = function() {
        $.fn.xmasked = old;
        return this;
    };
    $('[data-x="x-masked"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.xmasked(data);
    });

    /*
     * 
     */
}(window.XMasked = window.XMasked || {}, jQuery));

(function(XAutonumeric, $, undefined) {
    $.fn.xautonumeric = function(option) {
        return this.each(function() {
            var $this = $(this);
            var options = $.extend({}, $.fn.xautonumeric.defaults, typeof option == "object" && option);
            $this.data("xautonumeric", (new XAutonumeric(this, options)));
        });
    };
    function XAutonumeric(element, options) {
        this.$element = $(element);
        var eloptions = {};
        options.asep != undefined ? eloptions.aSep = options.asep : '';
        options.dgroup != undefined ? eloptions.dGroup = options.dgroup : '';
        options.adec != undefined ? eloptions.aDec = options.adec : '';
        options.altdec != undefined ? eloptions.altDec = options.altdec : '';
        options.asign != undefined ? eloptions.aSign = options.asign : '';
        options.psign != undefined ? eloptions.pSign = options.psign : '';
        options.vmin != undefined ? eloptions.vMin = options.vmin : '';
        options.vmax != undefined ? eloptions.vMax = options.vmax : '';
        options.mdec != undefined ? eloptions.mDec = options.mdec : '';
        options.mround != undefined ? eloptions.mRound = options.mround : '';
        options.apad != undefined ? eloptions.aPad = options.apad : '';
        options.nbracket != undefined ? eloptions.nBracket = options.nbracket : '';
        options.wempty != undefined ? eloptions.wEmpty = options.wempty : '';
        options.lzero != undefined ? eloptions.lZero = options.lzero : '';
        options.aform != undefined ? eloptions.aForm = options.aform : '';
        this.$options = $.extend({}, $.fn.xautonumeric.defaults, eloptions);
        this.init();
    }
    XAutonumeric.prototype = {
        init: function() {
            this.$element.autoNumeric(this.$options);
        }
    };
    var oldautonumeric = $.fn.xautonumeric;
    $.fn.xautonumeric.defaults = {
        aSep: ".",
        dGroup: "3",
        aDec: ",",
        aSign: "",
        pSign: "p",
        vMin: 0.00,
        vMax: 999999999.99,
        mDec: null,
        mRound: "S",
        aPad: true,
        nBracket: null,
        wEmpty: "empty",
        lZero: "allow",
        aForm: true
    };
    $.fn.xautonumeric.Constructor = XAutonumeric;
    $.fn.xautonumeric.noConflict = function() {
        $.fn.xautonumeric = oldautonumeric;
        return this;
    };
    $('[data-x="x-autonum"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.xautonumeric(data);
    });


    /*
     * 
     */
}(window.XAutonumeric = window.XAutonumeric || {}, jQuery));

(function(XDatePicker, $, undefined) {
    $.fn.datepickers = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data("xdatepicker");
            var options = $.extend({}, $.fn.datepickers.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("xdatepicker", (data = new XDatePicker(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };
    function XDatePicker(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.datepickers.defaults, options);
        this.init();
    }
    XDatePicker.prototype = {
        init: function() {
            var options = this.options;
            if ($.fn.datepickers) {
                this.$element.datepicker({
                    showAnim: options.showanim ? options.showanim : $.fn.datepickers.defaults.showAnim,
                    changeMonth: options.changemonth ? options.changemonth : $.fn.datepickers.defaults.changeMonth,
                    changeYear: options.changeyear ? options.changeyear : $.fn.datepickers.defaults.changeYear,
                    dateFormat: options.dateformat ? options.dateformat : $.fn.datepickers.defaults.dateFormat,
                    regional: options.regional ? options.regional : $.fn.datepickers.defaults.regional,
                    minDate: options.mindate != null ? options.mindate : $.fn.datepickers.defaults.minDate,
                    yearRange: options.yearrange != null ? options.yearrange : $.fn.datepickers.defaults.yearRange
                });
            }
        }
    };

    var olddatepicker = $.fn.datepickers;
    $.fn.datepickers.defaults = {
        showAnim: "slideDown",
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        regional: "es",
        yearRange: "c-100:c+100"
    };
    $.fn.datepickers.Constructor = XDatePicker;
    $.fn.datepickers.noConflict = function() {
        $.fn.datepickers = olddatepicker;
        return this;
    };
    $('[data-x="x-datepicker"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.datepickers(data);
    });
}(window.XDatePicker = window.XDatePicker || {}, jQuery));
/*
 * 
 */
(function(XChosen, $, undefined) {
    $.fn.combobox = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data("xchosen");
            var options = $.extend({}, $.fn.combobox.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("xchosen", (data = new XChosen(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };

    function XChosen(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.combobox.defaults, options);
        this.init();
    }

    XChosen.prototype = {
        init: function() {
            if ($.fn.chosen) {
                this.$element.chosen(this.options);
            }
        }
    };

    var oldchosen = $.fn.chosen;
    $.fn.combobox.defaults = {};
    $.fn.combobox.Constructor = XChosen;
    $.fn.combobox.noConflict = function() {
        $.fn.combobox = oldchosen;
        return this;
    };
    $('[data-x="x-chosen"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.combobox(data);
    });
}(window.XChosen = window.XChosen || {}, jQuery));

/*
 * MULTISELECT
 */
(function(XMultiselect, $, undefined) {
    $.fn.xmultiselect = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data("xmultiselect");
            var options = $.extend({}, $.fn.xmultiselect.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("xmultiselect", (data = new XMultiselect(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };

    function XMultiselect(element, options) {
        this.$el = $(element);
        this.$opt = $.extend({}, $.fn.xmultiselect.defaults, options);
        this.init();
    }

    XMultiselect.prototype = {
        init: function() {
            var $el = this.$el;
            var $opt = this.$opt;
            $el.multiselect($opt);
            if ($opt.url) {
                $.when(XGeneral.Ajax({
                    url: $opt.url,
                    vars: $opt
                })).then(function(data, textStatus, jqXHR) {
                    var mselect = $.map(data, function(object) {
                        return {
                            label: object.text, value: object.value
                        };
                    });
                    $el.multiselect("dataprovider", mselect);
                });
            }
        }
    };

    var oldxmultiselect = $.fn.xmultiselect;

    $.fn.xmultiselect.defaults = {
        numberDisplayed: 1,
        selectAllText: "Todos",
        includeSelectAllOption: true,
        enableFiltering: true,
        maxHeight: 150,
//    selectAllValue: 'multiselect-all',
        filterBehavior: "both",
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: "Buscar...",
        buttonWidth: "100%",
        nonSelectedText: "Selecciona",
        nSelectedText: "seleccionados"
        //includeSelectAllDivider: true,
//    dropRight: true
    };
    $.fn.xmultiselect.Constructor = XMultiselect;
    $.fn.xmultiselect.noConflict = function() {
        $.fn.xmultiselect = oldxmultiselect;
        return this;
    };


    $('[data-x="x-multiselect"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.xmultiselect(data);
    });

}(window.XMultiselect = window.XMultiselect || {}, jQuery));

(function(XSelect2, $, undefined) {
    $.fn.xselect2 = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data('xselect2');
            var options = $.extend({}, $.fn.xselect2.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xselect2', (data = new XSelect2(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };

    function XSelect2(element, options) {
        this.$el = $(element);
        this.$opt = $.extend({}, options, $.fn.xselect2.defaults);
        this.init();
    }

    XSelect2.prototype = {
        init: function() {
            var self = this;
            var $el = this.$el;
            var $opt = this.$opt;
            this.$el = $el;
            this.$opt = $opt;
            if ($opt.url && $opt.dropdownfor == undefined) {
                $.when(XGeneral.Ajax({
                    url: $opt.url,
                    vars: $opt
                })).then(function(data, textStatus, jqXHR) {
                    $opt.data = $.map(data, function(object) {
                        var text = "text";
                        var id = "value";
                        if ($opt.text) {
                            text = $opt.text;
                        }
                        if ($opt.value) {
                            id = $opt.value;
                        }
                        return {
                            text: object[text], id: object[id]
                        };
                    });
                    $el.select2($opt);
                    self.dropdown($el, $opt);
                });
            } else {
                $el.select2($opt);
                self.dropdown($el, $opt);
            }
        },
        dropdown: function($el, $opt) {
            var self = this;
            if ($opt.enable != undefined && !$opt.enable) {
                $el.select2("enable", false);
            }
            if ($opt.dropdownfor) {
  
                var form = $el.parents("form:first");
                var parent = form.find("#" + $opt.dropdownfor);
                parent.on("change", function(e) {
                    $el.select2("destroy");
                    $opt['data'] = [];
                    $el.select2($opt);
                    $el.select2('enable', false);
                    if (parent.val()) {
                        var vars = $opt.vars;
                        ($opt.parentname != undefined) ? vars[$opt.parentname] = parent.val() : vars['value'] = parent.val();
                        $.when(XGeneral.Ajax({
                            url: $opt.url,
                            vars: vars
                        })).then(function(data, textStatus, jqXHR) {
                            var data = $.map(data, function(object) {
                                var text = "text";
                                var id = "value";
                                if ($opt.text) {
                                    text = $opt.text;
                                }
                                if ($opt.value) {
                                    id = $opt.value;
                                }
                                return {
                                    text: object[text], id: object[id]
                                };
                            });
                            $el.select2("destroy");
                            $opt["data"] = data;
                            $el.select2($opt);
                            $el.select2("enable", true);
                            self.dropdown($el, $opt);
                        });
                    }
                });
            }
        }
    };

    var oldxselect2 = $.fn.xselect2;

    $.fn.xselect2.defaults = {
        data: [],
        placeholder: "Selecciona...",
        allowClear: true,
        enable: true

    };
    $.fn.xselect2.Constructor = XSelect2;
    $.fn.xselect2.noConflict = function() {
        $.fn.xselect2 = oldxselect2;
        return this;
    };


    $('[data-x="x-select2"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.xselect2(data);
    });

    /*
     * 
     */

}(window.XSelect2 = window.XSelect2 || {}, jQuery));

(function(XIcheck, $, undefined) {
    "use strict";
    $.fn.xicheck = function(option) {
        return this.each(function() {
            var $this = $(this);
            var data = $this.data('xicheck');
            var options = $.extend({}, $.fn.xicheck.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xicheck', (data = new XIcheck(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };
    function XIcheck(element, options) {
        this.$el = $(element).iCheck({
            checkboxClass: "icheckbox_minimal-grey",
            radioClass: "iradio_minimal-grey",
            increaseArea: "10%"
        });
    }
    var oldxicheck = $.fn.xicheck;
    $.fn.xicheck.defaults = {};
    $.fn.xicheck.Constructor = XIcheck;
    $.fn.xicheck.noConflict = function() {
        $.fn.xicheck = oldxicheck;
        return this;
    };
    $('[data-x="x-icheck"]').livequery(function() {
        var $this = $(this), data = $(this).data();
        $this.xicheck(data);
    });

}(window.XIcheck = window.XIcheck || {}, jQuery));


(function(BCheckList, $, undefined) {
    "use strict";

    BCheckList.initElement = function (e) {
        var dom = $(e).context;
        var url = $(e).data("url");
        
        var vars = {};
        vars.self = $(e).data("id");
        vars.value = $(e).data("value");
        
        //vars['value'] = this.val();
        if (url) {
            $.when(XGeneral.Ajax({
                url: url,
                vars: vars
            })).then(function (data, textStatus, jqXHR) {
                var stringhtml = "";
                
                var datal = $.map(data, function (object) {
                    var text = "text";
                    var id = "value";
                 
                    if (dom.text) {
                        text = dom.text;
                    }
                    if (dom.value) {
                        id = dom.value;
                    }
                    if (dom.value) {
                        id = dom.value;
                    }
                    return {
                        text: object[text], id: object[id], 'dataid': vars.self
                    };
                });
                dom['data'] = datal;

                $(datal).each(function (i, obj) {
                    stringhtml = stringhtml + " <label> " + obj.text + " <input type='radio' name='" + $(e).attr("name") + "' value='" + obj.id + "' data-id='" + obj.dataid + "' " +
                        (vars.value && (vars.value.toString() === obj.id.toString()) ? "checked='true'" :  (obj.id.toString() === "2808" && vars.value.toString() === "") ? "checked='true'" : "")  +
                        "/>  </label>";
                });

                $(e).html(stringhtml);
            });
        }
    };

    $('[data-x="x-checkList"]').livequery(function () {

        BCheckList.initElement(this);
    });
}(window.BCheckList = window.BCheckList || {}, jQuery));

(function (BUpload, $, undefined) {
    "use strict";

    BUpload.GetFileInfo = function (e) {
        return $.map(e.files, function (file) {
            var info = file.name;
            // File size is not available in all browsers
            if (file.size > 0) {
                info += " (" + Math.ceil(file.size / 1024) + " KB)";
            }
            return info;
        }).join(", ");
    };


    function getDomain() {
        console.log(window.location.hostname.replace(/([a-zA-Z0-9]+.)/, ""));
    }
    
    BUpload.initElement = function (e) {

        var vars = {};
        vars.url = $(e).data("url");
        vars.extensions = $(e).data("accept");
        vars.maxsize = $(e).data("maxsizefile");
        vars.self = $(e).data("id");
        vars.action = $(e).data("action");
        kendo.ui.Upload.fn._supportsDrop = function () { return false; }
        if (vars.url) {
            $(e).kendoUpload({
                
                async: {
                    saveUrl: vars.url,
                    removeUrl: "remove",
                    autoUpload: true
                },
                complete: function (ev) {
                    console.log(BUpload.GetFileInfo(ev));
                    
                },
                upload: function (ev) {
                    ev.data = { fieldId: vars.self, applicant: ($(e).attr("name")) };
                },
                remove: function (ev) {
                    console.log(BUpload.GetFileInfo(ev));
                },
                success: function (ev) {
                     if (vars.action) {
                        switch (vars.action) {
                            case "reload":
                                var arr = (window.location.href).split("/");
                                window.location = arr[0] + "//" + arr[2];
                                break;
                            default:
                            }
                       }
                },
                select: function (ev) {
                    var ok = true;
                    var message = "";
                    $.each(ev.files, function (index, value) {
                        //extentions
                        if (vars.extensions != undefined) {
                            var arrayextension = vars.extensions.split(",");
                            message = "Solo se admiten documentos con formato " + vars.extensions;

                            if (jQuery.inArray(value.extension, arrayextension) != -1) {
                                ok = true;
                            } else {
                                ok = false;
                            }
                        }
                        //Max Size
                        if (vars.maxsize != undefined) {

                            if (Math.ceil(value.size / 1024) > vars.maxsize) {
                                if (!ok) {
                                    message = message + " con un tamaño máximo de " + maxsize + "KB.";
                                } else {
                                    message = "Solo se admiten documentos " + " con un tamaño máximo de " + maxsize + "KB.";
                                }
                                ok = false;
                            }
                        }
                    });

                    if (!ok) {
                        ev.preventDefault();
                        BLExt.notifyMessage("Error",message,1);
                    }

                },
                localization: {
                    select: "Examinar.",
                    remove: "",
                    cancel: ""
                }
            });
        }
    };

    $("input[data-x='x-kupload']").livequery(function () {
        BUpload.initElement(this);
    });

}(window.BUpload = window.BUpload || {}, jQuery));


$('[data-parentof]').livequery(function() {
    var parentof = $(this).data("parentof");
    $(this).change(function() {
        var from = $(this).val().split("/");
        var actualDate = new Date(from[2], from[1] - 1, from[0]);
        var newDate = new Date(actualDate.getFullYear() + 1, actualDate.getMonth(), actualDate.getDate() - 1);
        $('#' + parentof).val(kendo.toString(newDate, "dd/MM/yyyy"));
    });
});


$.dropdownlistvalidate = function(field, rules, i, options) {
    if (field.context != undefined && field.context.children != undefined && field.context.children[1] != undefined) {
        var inputvalue = field.context.children[1];
        if ($(inputvalue).val() === "") {
            rules.push('required');
            return options.allrules.validatedropdownlist.alertText;
        }
    }
};

