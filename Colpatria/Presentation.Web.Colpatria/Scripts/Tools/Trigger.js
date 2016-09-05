(function (triggerClient, $, undefined) {
    triggerClient.GetRulesFields = "";
    triggerClient.GetHtmlFields = "";

    triggerClient.domHtml = "";
    triggerClient.domSectionHtml = "";
    triggerClient.domPageHtml = "";
    triggerClient.domForm = "";
    triggerClient.domBtnForm = "";

    triggerClient.SectionId = "";
    triggerClient.PageId = "";

    triggerClient.RequestType = "";
    triggerClient.Order = "1";
    triggerClient.data = null;

    triggerClient.IstLoanding = false;
    triggerClient.SetUrls = function (data) {
        triggerClient.GetRulesFields = data.GetRulesFields;
        triggerClient.GetHtmlFields = data.GetHtmlFields;
        triggerClient.domHtml = data.domHtml;
        triggerClient.domSectionHtml = data.domSectionHtml;
        triggerClient.domPageHtml = data.domPageHtml;
        triggerClient.domForm = data.domForm;
        triggerClient.domBtnForm = data.domBtnForm;
    };
    triggerClient.AplicateDefaultRule = function (objtwo, e) {
        triggerActions.Show(objtwo);
    };

    triggerClient.GetLabelElement = function (objtwo) {

        return $('[data-label-id="' + objtwo.name + '"]');
    };

    triggerClient.GetElement = function (objtwo) {

        switch (objtwo.Type) {

            case "1":
                return $('[data-id="' + objtwo.name + '"]');
            case "2":
                return $('[id="' + objtwo.name + '"]').data("kendoDropDownList");
            case "3":
                return $('[data-id="' + objtwo.name + '"]');
            case "4":
                return $('[data-innerid="' + objtwo.name + '"]');
            case "5":
                return $('[data-id="' + objtwo.name + '"]');
            default:
                return $('[data-id="' + objtwo.name + '"]');
        }
    };


    triggerClient.AplicateRule = function (objtwo) {
        //Init
        var action = objtwo.Action;

        switch (action) {
            case "hide":
                triggerActions.Hide(objtwo);
                break;
            case "show":
                triggerActions.Show(objtwo);
                break;
            case "readonly":
                triggerActions.ReadOnly(objtwo);
                break;
            case "disabled":
                triggerActions.SetDisabled(objtwo);
                break;
            default:
                triggerActions.Show(objtwo);
                //elementlabel.show();
                //triggerClient.SetRowVisible(elementlabel, true);
                //if (type == "2") {
                //    // element.enable(true);
                //    element.wrapper.show();
                //    //element.trigger("change");
                //    $("[aria-owns='" + objtwo.FieldId + "_listbox']").addClass("validate[funcCall[XGeneral.dropdownlistvalidate]]");
                //} else {
                //    //element.removeAttr("readonly");
                //    //element.removeAttr("disabled");
                //    element.show();
                //    if (type != "5") {
                //        element.addClass("validate[required]");
                //    }
                //    // element.closest(".row").show();

                //}
                break;
        }
    };

    triggerClient.GetValueFromListRadio = function (elementname) {
        //Obtener el elmento bien
        var radioButtons = $('[name="' + elementname + '"]');
        for (var x = 0; x < radioButtons.length; x++) {
            if (radioButtons[x].checked) {
                return radioButtons[x].value;
            }
        }
    };

    triggerClient.RemoveValueElement = function (obj) {

        var target = $('[id="' + obj.name + '"]').data("kendoDropDownList");
        
        if (target == null) {

        } else {
            target.value("");
        }
    }


    triggerClient.GetValueElement = function (e, obj) {
        var value = $(e.target).val();
        if (value === "") {
            value = $(e.target).attr("value");
        }
        var typeElement = $(e.target).attr("type");
        if (typeElement === "checkbox") {
            value = $(e.target).is(":checked");
        }
        if (typeElement === "radio") {
            value = triggerClient.GetValueFromListRadio(obj.name);
            if (value == undefined) {
                value = "false";
            }
        }
        if ("x-kdropdown" === $(e.target).attr("data-x")) {
            var kendodrop = $(e.target).data("kendoDropDownList");

            if (kendodrop != undefined && kendodrop.select() != undefined) {
                var indexdrop = kendodrop.select();

                if (indexdrop === -1) {
                    if (value == undefined | value == null) {
                        value = $(e.target).attr("data-value");
                    }
                } else {
                    value = $(e.target).data("kendoDropDownList").value();
                }
            }

        }

        return value;
    };

    triggerClient.currentElement = function (obj, e) {

        if (typeof e.target.name !== "undefined") {

            var name = ((e.target.name).split("_")); delete name[2];
            name[0] = obj.FieldId;
            name = name.join("_");

            var dataLabelId = $(($("label[data-label-id *='" + name + "']"))[0]).attr("data-label-id");

            if (dataLabelId != null || typeof dataLabelId != "undefined") {
                return dataLabelId;
            }
            return name;
        }
        return null;
    }

    triggerClient.triggerAction = function (list) {

        $(list)
            .each(function (index, obj) {

                var parentElement = $('[data-id="' + obj.FieldId + '"]');
                parentElement.addClass("subscribers-CustomDocumentReady");
                parentElement.attr("data-order", obj.Order);
                // Create function
                var functionjs = function (e) {
                    var mytrigger = $(e.target);

                    obj.name = triggerClient.currentElement(obj, e);

                    var value = triggerClient.GetValueElement(e, obj);
                    var values = [];
                    $(obj.ReferenceField).each(function (indv, objv) {
                        if (value === objv.Value) {
                            values.push(objv.Value);
                            //console.log(objv.Value);
                        }
                    });

                    if (values.length === 0) {
                        values.push("0");
                    }

                    values = $.unique(values);
                    $(values)
                        .each(function (indv, objv) {
                            var isapplicate = false;
                            $(obj.ReferenceField)
                                .each(function (indtwo, objtwo) {

                                    objtwo.name = triggerClient.currentElement(objtwo, e);

                                    //Obtener el FieldId
                                    if (value == undefined) {
                                        value = "";
                                    }
                                    if (objv === objtwo.Value && value != undefined && objtwo.Value === value.toString()
                                    ) {
                                        //console.log("Orden " +
                                        //    obj.Order +
                                        //    "    aplicar regla :" +
                                        //    obj.Name +
                                        //    " " +
                                        //    objtwo.FieldId +
                                        //    " for " +
                                        //    value +
                                        //    " with : " +
                                        //    objtwo.Value +
                                        //    " Accion : " +
                                        //    objtwo.Action);
                                        triggerClient.AplicateRule(objtwo, mytrigger, value, e);
                                        isapplicate = true;
                                    } else {
                                        if (isapplicate === false && objtwo.Action !== "show") {
                                            //console.log("Orden " +
                                            //    obj.Order +
                                            //    "    aplicar Default regla :" +
                                            //    obj.Name +
                                            //    " " +
                                            //    objtwo.FieldId +
                                            //    " for " +
                                            //    value +
                                            //    " with : " +
                                            //    objtwo.Value +
                                            //    " Accion : " +
                                            //    objtwo.Action);
                                            triggerClient.AplicateDefaultRule(objtwo, e);

                                        }
                                    }


                                });
                        });
                };
                //Bind function
                parentElement.on(obj.Event, functionjs);
            });
    };

    triggerClient.InitEvents = function () {
        $("#" + triggerClient.domHtml).trigger("customevent", [1011]);
    };

    triggerClient.InitRules = function () {
        BLExt.GetDataServer(triggerClient.GetRulesFields,
            { sectionId: triggerClient.SectionId },
            function (dt) {
                triggerClient.data = dt;
                triggerClient.triggerAction(dt);
            },
            false);
    };

    triggerClient.LoadHtml = function (sectionId, pageId, requestType, order) {

        triggerClient.SectionId = sectionId;
        triggerClient.PageId = pageId;
        triggerClient.RequestType = requestType;
        triggerClient.Order = order;

        triggerClient.InitRules();
        plusData.Init();


        $("#" + triggerClient.domHtml).on("customevent", function(e, eventInfo) {
                var subscribers = $(".subscribers-CustomDocumentReady");
            subscribers = subscribers.sort(function(a, b) {
                return +a.getAttribute("data-order") - +b.getAttribute('data-order');
            });
            subscribers.each(function (i, obj) {
                //console.log(obj);
                $(obj).trigger("CustomDocumentReady", [eventInfo]);

            });
        });

        triggerClient.InitEvents();
    };

}(window.triggerClient = window.triggerClient || {}, jQuery));