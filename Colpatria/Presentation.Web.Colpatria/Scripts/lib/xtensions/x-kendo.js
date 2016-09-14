!function ($) {
    "use strict";
    $.fn.dropdownlistvalidate = function (field, rules, i, options) {
        if (field.context != undefined && field.context.children != undefined && field.context.children[1] != undefined) {
            var inputvalue = field.context.children[1];
            if ($(inputvalue).val() === "") {
                rules.push("required");
                return options.allrules.validatedropdownlist.alertText;
            }
        }
    };

    function kComboBox(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.kcombobox.defaults, options);
        this.initComboBox();
    }

    $.fn.kcombobox = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data("kcombobox");
            var options = $.extend({}, $.fn.kcombobox.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("kcombobox", (data = new kComboBox(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };

    kComboBox.prototype = {
        initComboBox: function () {
            if ($.isFunction($.fn.kendoComboBox)) {
                var $element = this.$element;
                if (this.$element.data("source")) {
                    this.$element.kendoComboBox({
                        dataTextField: this.$element.data("textfield"),
                        dataValueField: this.$element.data("valuefield"),
                        value: this.$element.data("value"),
                        autoBind: this.$element.data("autobind"),
                        cascadeFrom: this.$element.data("cascadefrom"),
                        suggest: true,
                        dataSource: {
                            type: "json",
                            serverFiltering: (this.$element.data("cascadefrom") == undefined) ? false : true,
                            transport: {
                                read: {
                                    url: this.$element.data("source"),
                                    type: "POST",
                                    data: function (e) {
                                        if ($element.data("cascadefrom") != undefined) {
                                            return { value: $("#" + $element.data("cascadefrom")).val() };
                                        } else {
                                            return {};
                                        }
                                    }
                                }
                            }
                        }

                    });
                } else {
                    this.$element.kendoComboBox({
                        dataTextField: this.$element.data("textfield"),
                        dataValueField: this.$element.data("valuefield"),
                        value: this.$element.data("value"),
                        autoBind: this.$element.data("autobind"),
                        cascadeFrom: this.$element.data("cascadefrom"),
                        suggest: true
                    });
                }
            }
        }
    };

    function kDropdown(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.kdropdown.defaults, options);
        this.initDropDown();
    }

    $.fn.kdropdown = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data("kdropdown");

            var options = $.extend({}, $.fn.kdropdown.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("kdropdown", (data = new kDropdown(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };

    function kDropdownauto(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.kdropdownauto.defaults, options);
        this.initDropDownAuto();
    }

    $.fn.kdropdownauto = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data("kdropdownauto");

            var options = $.extend({}, $.fn.kdropdown.defaults, typeof option == "object" && option);
            if (!data) {
                $this.data("kdropdownauto", (data = new kDropdownauto(this, options)));
            }
            if (typeof option == "string") {
                data[option]();
            }
        });
    };

    kDropdown.prototype = {
        initDropDown: function () {
            if ($.isFunction($.fn.kendoDropDownList)) {
                var $element = this.$element;
                if (this.$element.data("url")) {
                    //console.log(this.$element.data("textfield"));

                    this.$element.kendoDropDownList({
                        optionLabel: { text: this.$element.data("optionlabel") == undefined ? "Seleccione..." : this.$element.data("optionlabel"), value: "0" },
                        dataTextField: this.$element.data("textfield") == undefined ? "text" : this.$element.data("textfield"),
                        dataValueField: this.$element.data("valuefield") == undefined ? "value" : this.$element.data("valuefield"),
                        //filter: "contains",
                        value: this.$element.data("value"),
                        autoBind: this.$element.data("autobind"),
                        cascadeFrom: this.$element.data("cascadefrom"),
                        dataSource: {
                            type: "json",
                            serverFiltering: this.$element.data("cascadefrom") == undefined ? false : true,
                            transport: {
                                read: {
                                    url: XGeneral.path + this.$element.data("url"),
                                    type: "POST",
                                    data: function (e) {
                                        var vars = { self: ($element.attr("data-id") == undefined ? $element.attr("name") : $element.attr("data-id")) };
                                        if ($element.data("cascadefrom") != undefined) {
                                            vars = jQuery.extend(vars, { value: $("#" + $element.data("cascadefrom")).val() });
                                        } else {
                                            if ($element.data("vars")) {
                                                vars = jQuery.extend(vars, XGeneral.Object2Array($element.data("vars")));
                                            }
                                        }
                                        return vars;
                                    }
                                }
                            }, requestEnd: function (e) {
                                if (typeof triggerClient !== "undefined") {
                                    triggerClient.InitEvents();
                                }

                            }
                        }
                    });
                } else {
                    if (this.$element.data("source")) {
                        var datasource = window[this.$element.data("source")];
                        var $el = this.$element;
                        this.$element.kendoDropDownList({
                            dataSource: datasource,
                            height: this.$element.data("height") == undefined ? "300" : this.$element.data("height"),
                            template: this.$element.data("template") == undefined ? "" : $("#" + this.$element.data("template")).html(),
                            valueTemplate: this.$element.data("valuetemplate") == undefined ? "" : $("#" + this.$element.data("valuetemplate")).html(),
                            cascadeFrom: this.$element.data("cascadefrom"),
                            //filter: "contains",
                            value: this.$element.data("value"),
                            dataTextField: this.$element.data("textfield") == undefined ? "text" : this.$element.data("textfield"),
                            dataValueField: this.$element.data("valuefield") == undefined ? "value" : this.$element.data("valuefield"),
                            select: function (e) {
                                $el.data("select") !== undefined ? XGeneral.execute($el.data("select"), window, e) : "";
                            },
                            change: function (e) {
                                $el.data("change") !== undefined ? XGeneral.execute($el.data("change"), window, e) : "";
                            }
                        });
                    } else {
                        var $el = this.$element;
                        this.$element.kendoDropDownList({
                            optionLabel: {
                                text: this.$element.data("optionlabel") == undefined ? "Seleccione..." : this.$element.data("optionlabel")
                                , value: '0'
                            },
                            template: this.$element.data("template") == undefined ? "" : $("#" + this.$element.data("template")).html(),
                            dataTextField: (this.$element.data("textfield") == undefined) ? "text" : this.$element.data("textfield"),
                            dataValueField: (this.$element.data("valuefield") == undefined) ? "value" : this.$element.data("valuefield"),
                            //filter: "contains",
                            value: this.$element.data("value"),
                            autoBind: this.$element.data("autobind"),
                            cascadeFrom: this.$element.data("cascadefrom"),
                            select: function (e) {
                                $el.data("select") !== undefined ? XGeneral.execute($el.data("select"), window, e) : "";
                            },
                            change: function (e) {
                                $el.data("change") !== undefined ? XGeneral.execute($el.data("change"), window, e) : "";
                            }
                        });
                    }

                }
                if (this.$element.hasClass("k-hack")) {
                    //console.log(this.$element);
                    var el = this.$element.data("kendoDropDownList");
                }
            }
        }
    };

    kDropdownauto.prototype = {
        initDropDownAuto: function () {
            if ($.isFunction($.fn.kendoAutoComplete)) {
                var $element = this.$element;
                if (this.$element.data("url")) {
                    this.$element.kendoAutoComplete({
                        dataTextField: this.$element.data("textfield") == undefined ? "text" : this.$element.data("textfield"),
                        filter: "startswith",
                        dataSource: {
                            type: "json",
                            serverFiltering: this.$element.data("cascadefrom") == undefined ? false : true,
                            transport: {
                                read: {
                                    url: XGeneral.path + this.$element.data("url"),
                                    serverPaging: true,
                                    type: "POST",
                                    data: function(e) {
                                        var vars = { self: ($element.attr("data-id") == undefined ? $element.attr("name") : $element.attr("data-id")) };
                                        if ($element.data("cascadefrom") != undefined) {
                                            vars = jQuery.extend(vars, { value: $("#" + $element.data("cascadefrom")).val() });
                                        } else {
                                            if ($element.data("vars")) {
                                                vars = jQuery.extend(vars, XGeneral.Object2Array($element.data("vars")));
                                            }
                                        }
                                        return vars;
                                    }
                                }
                            }
                        }
                    });
                }
            }
        }
    };
    var oldDropDown = $.fn.kdropdown;
    $.fn.kdropdown.defaults = {};
    $.fn.kdropdown.Constructor = kDropdown;
    $.fn.kdropdown.noConflict = function () {
        $.fn.kdropdown = oldDropDown;
        return this;
    };
    var oldCombo = $.fn.kcombobox;
    $.fn.kcombobox.defaults = {};
    $.fn.kcombobox.Constructor = kDropdown;
    $.fn.kcombobox.noConflict = function () {
        $.fn.kdropdown = oldCombo;
        return this;
    };
    //tooltip
    $.fn.ktooltip = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data("xktooltip");
            var options = $.extend({}, $.fn.ktooltip.defaults, typeof option == "object" && option);
            $this.data("xktooltip", (data = new kTooltip(this, options)));

        });
    };
    function kTooltip(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, $.fn.ktooltip.defaults, options);
        this.initToolTip();
    }
    kTooltip.prototype = {
        initToolTip: function () {
            if ($.isFunction($.fn.kendoTooltip)) {
                var $element = this.$element;
                if (this.$element.data("template") == undefined || !(this.$element.data("xktooltip") instanceof Object)) {
                    this.$element.attr("data-template", "template-tooltip");
                    this.$element.attr("data-tittle", this.$element.data("xktooltip"));
                }

                this.$element.kendoTooltip({
                    content: this.$element.data("template") == undefined ? "" : kendo.template($("#" + this.$element.data("template")).html())
                    , position: "right"
                });
            }
        }
    };

    var oldTooltip = $.fn.ktooltip;
    $.fn.ktooltip.defaults = {};
    $.fn.ktooltip.Constructor = kTooltip;
    $.fn.ktooltip.noConflict = function () {
        $.fn.ktooltip = oldTooltip;
        return this;
    };

}(window.jQuery);