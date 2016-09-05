(function (modalVideo, $, undefined) {

    modalVideo.urlRequest = "";
    modalVideo.domHtml = "";
    modalVideo.domModalVideo = "";
    modalVideo.domiframe = "";


    modalVideo.SetUrls = function (data) {
        modalVideo.urlRequest = data.urlRequest;
        modalVideo.domHtml = data.domHtml;
        modalVideo.domModalVideo = data.domModalVideo;
        modalVideo.domiframe = data.domiframe;
    };

    modalVideo.openModalVideo = function (e) {
        modalVideo.play();
        BLExt.InitModal(modalVideo.domModalVideo, function () { return true; }, "50%", " ", function () {
            modalVideo.stop();
        });

    };
    modalVideo.play = function () {
        var url = $("#" + modalVideo.domiframe).attr('src');
        url = url.replace("&autoplay=0", "&autoplay=1");
        $("#" + modalVideo.domiframe).attr('src', url);
    };

    modalVideo.stop = function () {
        var url = $("#" + modalVideo.domiframe).attr('src');
        url = url.replace("&autoplay=1", "&autoplay=0");
        $("#" + modalVideo.domiframe).attr("src", url);
    };

    modalVideo.CloseModalVideo = function (e) {
        var window = $("#" + modalVideo.domModalVideo).data("kendoWindow");
        window.close();
        modalVideo.stop();
    };

}(window.modalVideo = window.modalVideo || {}, jQuery));