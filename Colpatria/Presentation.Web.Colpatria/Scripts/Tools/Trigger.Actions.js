(function(triggerActions, $, undefined) {
    triggerActions.RemoveRequired = function(obj) {
     
        var element = triggerClient.GetElement(obj);
        var typeControl = obj.Type;
        switch (typeControl) {
            case "2":
                ($("span[aria-owns *='" + obj.name + "']")).removeClass("validate[funcCall[XGeneral.dropdownlistvalidate]]");
            break;
        case "1":
            ($("input[name *='" + obj.name + "']")).removeClass("validate[required]");
            default :
                element.removeClass("validate[required]");
            break;
        }
    };

    triggerActions.AddRequired = function (obj) {
        
        var element = triggerClient.GetElement(obj);
        var typeControl = obj.Type;
        switch (typeControl) {
            case "2":
                ($("span[aria-owns *='" + obj.name + "']")).addClass("validate[funcCall[XGeneral.dropdownlistvalidate]]");
                break;
            case "1":
                ($("input[name *='" + obj.name + "']")).addClass("validate[required]");
            default:
                element.addClass("validate[required]");
                break;
        }
    };

    triggerActions.Hide = function (obj) {
        
        var element = triggerClient.GetElement(obj);
        var elementlabel = triggerClient.GetLabelElement(obj);

        var typeControl = obj.Type;
        
        triggerActions.RemoveRequired(obj);
        triggerClient.RemoveValueElement(obj);
        triggerActions.SetVisibleContainer(elementlabel, false);

        if (element == null) {

        } else {
            switch (typeControl) {
                case "2":
                    element.wrapper.hide();
                    break;
                default:
                    element.hide();
                    break;
            }
        }
    };

    triggerActions.Show = function (obj) {
        
        var element = triggerClient.GetElement(obj);
        var elementlabel = triggerClient.GetLabelElement(obj);
        triggerActions.AddRequired(obj);
        triggerClient.RemoveValueElement(obj);
        triggerActions.SetVisibleContainer(elementlabel, true);

        var typeControl = obj.Type;

        if (element == null) {

        } else {
            switch (typeControl) {
                case "2":
                    element.wrapper.show();
                    break;
                default:
                    element.show();
                    break;
            }
        }
     
    };

    triggerActions.ReadOnly = function (obj) {

        var element = triggerClient.GetElement(obj);
        var typeControl = obj.Type;

        switch (typeControl) {
            case '2':
                element.readonly();
                break;
            default:
                element.readonly();
                break;
        }
    };

    triggerActions.SetDisabled = function (obj) {

        var element = triggerClient.GetElement(obj);
        var typeControl = obj.Type;

        switch (typeControl) {
            case '2':
                element.enable(false);

                ($("span[aria-owns *='" + obj.name + "']")).removeClass("validate[funcCall[XGeneral.dropdownlistvalidate]]");
                
                break;
            default:
                element.attr('disabled', 'disabled');
                element.attr('readonly', 'true');
                break;
        }
    };

    triggerActions.SetVisibleContainer = function (element, visible) {

        var tags = $(element).parents('.row').first();

        if (visible === true) {
            tags.show();
        } else {
            tags.hide();
        }
    };

}(window.triggerActions = window.triggerActions || {}, jQuery));