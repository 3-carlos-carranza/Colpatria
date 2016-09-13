(function (triggerClientValidator, $, undefined) {

    triggerClientValidator.GetElement = function (objtwo) {
        var element = null;
        switch (objtwo.Type) {

            case '1':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            case '2':
                element = $('#' + objtwo.Id).data("kendoDropDownList");
                break;
            case '3':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            case '4':
                element = $('[data-innerid="' + objtwo.Id + '"]');
                break;
            case '5':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            default:
                element = $('[name="' + objtwo.Id + '"]');
                break;
        }
        return element;
    };
    triggerClientValidator.ValidateRule = function (obj, value, e) {
        //Init
        if (value != undefined && obj.Value == value.toString()) {
            return true;
        }
        return false;
        //END 
    };
   
    triggerClientValidator.GetValueFromListRadio = function (elementname) {
        var radioButtons = document.getElementsByName(elementname);
        for (var x = 0; x < radioButtons.length; x++) {
            if (radioButtons[x].checked) {
                return radioButtons[x].value;
            }
        }
    };
    triggerClientValidator.GetElement = function (objtwo) {
        var element = null;
        switch (objtwo.Type) {

            case '1':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            case '2':
                element = $('#' + objtwo.Id).data("kendoDropDownList");
                break;
            case '3':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            case '4':
                element = $('[data-innerid="' + objtwo.Id + '"]');
                break;
            case '5':
                element = $('[name="' + objtwo.Id + '"]');
                break;
            default:
                element = $('[name="' + objtwo.Id + '"]');
                break;
        }
        return element;
    };
    triggerClientValidator.GetValueElement = function (obj) {

        var parentElement = triggerClientValidator.GetElement(obj);
        var value = '';
        switch (obj.Type) {
            case "2":
                
                var context = $(parentElement._arrow.context);
               // console.log(context);
                value = context.attr("data-value");
                break;
            default:
                 value = $(e.target).val();
                if (value == "") {
                    value = $(e.target).attr("value");
                }
                var typeElement = $(e.target).attr("type");
                if (typeElement == "checkbox") {
                    value = $(e.target).is(':checked');
                }
                if (typeElement == "radio") {
                    value = triggerClient.GetValueFromListRadio(obj.FieldId);
                    if (value == undefined) {
                        value = 'false';
                    }
                }
                if ("x-kdropdown" == $(e.target).attr("data-x")) {
                    var kendodrop = $(e.target).data("kendoDropDownList");

                    if (kendodrop != undefined && kendodrop.select() != undefined) {
                        var indexdrop = kendodrop.select();

                        if (indexdrop == -1) {
                            if (value == undefined | value == null) {
                                value = $(e.target).attr("data-value");
                            }
                        } else {
                            value = $(e.target).data("kendoDropDownList").value();
                        }
                    }

                }

        }
        //console.log(value);
        return value;
    };
    triggerClientValidator.ValidateAllRule = function (validations) {
        
        if (validations != undefined ) {
            var arrayresult = [];

            arrayresult.push({ value: true, operator: 'AND' });
            //console.log(validations);
            $(validations).each(function (index, itemValidation) {
                var value = triggerClientValidator.GetValueElement(itemValidation);
                if (value == undefined) {
                    value = "";
                }
                //have next rule?
                var retornedPrev = null;
                retornedPrev = triggerClientValidator.ValidateRule(itemValidation, value);
                arrayresult.push({ value: retornedPrev, operator: itemValidation.OperatorLogic });

                //function
            });
           // console.log(arrayresult);
            return triggerClientValidator.EvaluateResult(arrayresult);
        } else {
            return true;
        }
    };

    triggerClientValidator.EvaluateResult = function (array) {

        var counter = 0;
        var previResult = true;
        $(array).each(function (index, itemValidation) {
          
                switch (itemValidation.operator) {
                case "AND":
                    previResult = triggerClientValidator.and(previResult, itemValidation.value);//AND
                    break;
                case "OR":
                        previResult = triggerClientValidator.or(previResult, itemValidation.value);//OR
                     break;
                default:
                        previResult = triggerClientValidator.and(previResult, itemValidation.value);//AND
                     break;
                }
            
            counter++;
        });
        return previResult;
    };
    triggerClientValidator.or = function(a, b) {
        return a || b;
    };

    triggerClientValidator.and = function(a, b) {
        return a && b;
    };

}(window.triggerClientValidator = window.triggerClientValidator || {}, jQuery));