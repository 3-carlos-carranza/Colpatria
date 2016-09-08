!function ($) {
    "use strict";

    $.fn.xformvalidate = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data('xformvalidate');
            var options = $.extend({}, $.fn.xformvalidate.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xformvalidate', (data = new XFormValidate(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };

    function XFormValidate(element, options) {
        this.$form = $(element);
        this.options = $.extend({}, $.fn.xformvalidate.defaults, options);
        this.init();
    }


    XFormValidate.prototype = {
        init: function () {
            var $self = this;
            var $options = this.options;
            this.$form.validationEngine({
                promptPosition: $options.valpromt,
                autoHidePrompt: true,
                showOneMessage: true,
                validateNonVisibleFields: true,
                binded: false,
                scroll: $options.scroll,
                isOverflown: false,
                autoHideDelay: $options.autohidedelay
            }).ajaxForm({
                beforeSerialize: function ($form, options) {
                    $options.beforeserialize !== 'this.beforeSerialize' && $options.beforeserialize !== '' ? XGeneral.execute($options.beforeserialize, window, $form, options) : $self.beforeSerialize($form, options);
                },
                beforeSubmit: function (arr, $form, options) {
                    $options.beforesubmit !== 'this.beforeSubmit' && $options.beforesubmit !== '' ? XGeneral.execute($options.beforesubmit, window, arr, $form, options) : $self.beforeSubmit(arr, $form, options);
                },
                success: function (responseText, statusText, xhr, $form) {
                    $options.success !== 'this.success' && $options.success !== '' ? XGeneral.execute($options.success, window, responseText, statusText, xhr, $form) : $self.success(responseText, statusText, xhr, $form);
                },
                dataType: this.options.datatype,
                target: this.options.target,
                options: this.options
            });
        },
        beforeSerialize: function ($form, options) {
            if ($.fn.autoNumeric && $form.find('[data-x="x-autonum"]').length) {
                $form.find('[data-x="x-autonum"]').each(function (index) {
                    var rawValue = $(this).autoNumeric('get');
                    $(this).autoNumeric('destroy');
                    $(this).val(rawValue);
                });
            }
            $form.find('[data-x="x-masked"]').each(function (index, e) {
                $(this).val($(this).val().replace(/\-/g, ''));
                $(this).unmask();
            });

        },
        beforeSubmit: function (arr, $form, options) {
            if ($form.validationEngine('validate')) {
                $form.find(':submit').attr("disabled", true);
                if (this.options.isloading) {
                    XGeneral.loading();
                }
                return true;
            } else {
                $form.find('[data-x="x-masked"]').each(function (index, e) {
                    $(this).mask($(this).data("mask"));
                });
                $form.find('[data-x="x-autonum"]').each(function (index) {
                    $(this).autoNumeric($(this).data("data-autonum"));
                });
                return false;
            }

        },
        error: function (e) {
            XGeneral.loadingclose();
        },
        success: function (responseText, statusText, xhr, $form) {
            $form.find(':submit').removeAttr("disabled");
            
            XFormValidate.prototype.enableinputs($form);
            var isJson = false;
            isJson = typeof responseText === 'object';
            if (isJson) {
                
                var Callbacks = responseText.Callbacks;
                console.log(Callbacks);
                $.each(Callbacks, function (funtion, vars) {
                    XGeneral.execute(funtion, window, vars, statusText, xhr, $form);
                });
                if (responseText.status) {
                    XFormValidate.prototype.resetform($form);
                }
            }
        },
        enableinputs: function ($form) {
            $form.find('[data-x="x-masked"]').each(function (index, e) {
                $(this).mask($(this).data("mask"));
            });
            $form.find('[data-x="x-autonum"]').each(function (index) {
                $(this).autoNumeric($(this).data("xautonumeric").$options);
            });
        },
        resetform: function ($form) {
            $.each($form.find('input'), function (index, callback) {
                $(this).val();
            });
        }
    };

    var old = $.fn.xformvalidate;

    $.fn.xformvalidate.defaults = {
        valpromt: 'topRight',
        beforeserialize: 'this.beforeSerialize',
        beforesubmit: 'this.beforeSubmit',
        success: 'this.success',
        clearform: false,
        datatype: 'json',
        error: 'error',
        resetform: false,
        target: null,
        isloading: false,
        autohidedelay: 10000,
        scroll: false
    };
    $.fn.xformvalidate.Constructor = XFormValidate;
    $.fn.xformvalidate.noConflict = function () {
        $.fn.xformvalidate = old;
        return this;
    };




    $(document).ready(function () {
        $('[data-x="x-form"]').livequery(function () {
            var $this = $(this), data = $(this).data();
            $this.xformvalidate(data);
        });
    });


}(window.jQuery);








!function ($) {
    "use strict";
    $.fn.xvalidate = function (option) {
        return this.each(function () {
            var $this = $(this);
            var data = $this.data('xvalidate');
            var options = $.extend({}, $.fn.xvalidate.defaults, typeof option == 'object' && option);
            if (!data) {
                $this.data('xvalidate', (data = new XValidate(this, options)));
            }
            if (typeof option == 'string') {
                data[option]();
            }
        });
    };

    function XValidate(element, options) {
        this.$form = $(element);
        this.options = $.extend({}, $.fn.xvalidate.defaults, options);
        this.init();
    }


    XValidate.prototype = {
        init: function () {
            var $self = this;
            var $options = this.options;
            var $form = this.$form;
            $form.validationEngine({
                promptPosition: $options.valpromt,
                autoHidePrompt: true,
                showOneMessage: true,
                validateNonVisibleFields: true,
                binded: false,
                scroll: $options.scroll,
                isOverflown: false,
                autoHideDelay: $options.autohidedelay
            }).on("submit", function (event) {
                event.preventDefault();
                if ($form.validationEngine('validate')) {
                    $form.find(':submit').attr("disabled", true);
                    if ($options.loading) {
                        XGeneral.loading();
                    }
                    if ($.fn.autoNumeric && $form.find('[data-x="x-autonum"]').length) {
                        $form.find('[data-x="x-autonum"]').each(function (index) {
                            var rawValue = $(this).autoNumeric('get');
                            $(this).autoNumeric('destroy');
                            $(this).val(rawValue);
                        });
                    }
                    if ($.fn.masked && $form.find('[data-x="x-masked"]').length) {
                        $(this).val($(this).val().replace(/\-/g, ''));
                        $(this).unmask();
                    }
                    if ($options.beforesubmit !== 'this.beforeSubmit' && $options.beforesubmit !== '' && $options.beforesubmit !== undefined) {
                        XGeneral.execute($options.beforesubmit, window, $form, $options);
                    } else {
                        $form.unbind('submit');
                        $form.submit();
                        return true;
                    }
                }
                return false;
            });
        }

    };

    var oldxvalidate = $.fn.xvalidate;

    $.fn.xvalidate.defaults = {
        valpromt: 'topRight',
        error: 'error',
        autohidedelay: 10000,
        scroll: false
    };
    $.fn.xvalidate.Constructor = XValidate;
    $.fn.xvalidate.noConflict = function () {
        $.fn.xvalidate = oldxvalidate;
        return this;
    };


    $('[data-x="x-validate"]').livequery(function () {
        var $this = $(this), data = $(this).data();
        $this.xvalidate(data);
    });

}(window.jQuery);
//Paginacion formulario de validacion de datos
jQuery.extend({
    stepForm: function (txtBack, txtNext, token) {
        var fieldsets = $((token || 'fieldset'), $("form.stepMe"));
        var total = $(fieldsets).length;
        $(fieldsets).each(function (x, el) {
            if (x > 0) {
                $(el).hide();
              //  $(el).append('<a class="backStep" href="#x_' + (x - 1) + '">' + (txtBack || 'Volver') + '</a>');
                $(".backStep", $(el)).on("click", function () {
                    $("#x_" + (x - 1)).show("slow");
                    $(el).hide("slow");
                });
            }

            if ((x + 1) < total) {
                $(el).append('<a class="nextStep btn btn-danger pull-right enviar valid" href="#_' + (x + 1) + '">' + (txtNext || 'Siguiente') + ' <span class="glyphicon glyphicon-share-alt" aria-hidden="true"></span></a>');
                $(".nextStep", $(el)).on("click", function () {
                    $("#x_" + (x + 1)).show("slow");
                    $(el).hide("slow");
                });
            }
            $(el).attr("id", "x_" + x);
        });
    }
});
$(document).ready(function () {
    $.stepForm();
});

//Fin Paginacion formulario de validacion de datos

//Borde dinamico
(function () {
    if (!String.prototype.trim) {
        (function () {
            var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
            String.prototype.trim = function () {
                return this.replace(rtrim, '');
            };
        })();
    }
    [].slice.call(document.querySelectorAll('input.input__field')).forEach(function (inputEl) {
        // in case the input is already filled..
        if (inputEl.value.trim() !== '') {
            classie.add(inputEl.parentNode, 'input--filled');
        }
        // events:
        inputEl.addEventListener('focus', onInputFocus);
        inputEl.addEventListener('blur', onInputBlur);
    });
    function onInputFocus(ev) {
        classie.add(ev.target.parentNode, 'input--filled');
    }
    function onInputBlur(ev) {
        if (ev.target.value.trim() === '') {
            classie.remove(ev.target.parentNode, 'input--filled');
        }
    }
})();

// Datapicker
$(document).ready(function () {
    $('#datepicker1').datetimepicker({
        format: 'DD/MM/YYYY'
    });
});