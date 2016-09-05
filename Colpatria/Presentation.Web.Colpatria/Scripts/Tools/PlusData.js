(function (plusData, $, undefined) {

    plusData.domHtml = '';


    plusData.SetUrls = function (data) {
        plusData.domHtml = data.domHtml;
    };
    plusData.Init = function (e) {
        var values = [];
        $("[data-x-plus]").each(function (i, obj) {
            values.push($(obj).attr("data-x-plus").toLowerCase());
            //set value 
        });

        $.unique(values);
        $(values).each(function (iv, objv) {
            $("[data-x-plus='" + objv + "']").focusout(function () {
                var total = 0;
                $("[data-x-plus='" + objv + "']").each(function (i, obj) {
                    var value = parseFloat($(obj).val().toString().split('.').join(''));
                    value = (value == undefined ? 0 : (value !== '' ? parseFloat(value) : 0));
                    //console.log(value);
                    total = total + value;
                });

                $('[name="' + objv + '"]').val(total);

            });
        });

    };
}(window.plusData = window.plusData || {}, jQuery));