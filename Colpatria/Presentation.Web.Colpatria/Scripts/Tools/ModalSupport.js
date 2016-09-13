(function (modalSupport, $, undefined) {

    modalSupport.urlRequest = '';
    modalSupport.domHtml = '';
    modalSupport.domModalSupport = '';


    modalSupport.SetUrls = function (data) {
        modalSupport.urlRequest = data.urlRequest;
        modalSupport.domHtml = data.domHtml;
        modalSupport.domModalSupport = data.domModalSupport;
    };

    modalSupport.openModalSupport = function (e) {
        BLExt.InitModal(modalSupport.domModalSupport, function () { return true; }, "50%", " ");
    };
    modalSupport.CloseModalSupport = function (e) {
        var window = $("#" + modalSupport.domModalSupport).data("kendoWindow");
        window.close();
    };





}(window.modalSupport = window.modalSupport || {}, jQuery));