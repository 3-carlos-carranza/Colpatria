$(document).ready(function () {
    isMobile();
    gralMobile();
});

$(window).resize(function () {
    window.windowWdth = $(window).width();
    MoveDetailsDiv();

});

windowWdth = $(window).width();
windowHgt = $(window).height();
gralInfo = $('#gralInfo');

function gralMobile() {
    if (isMobile(990, 640)) {
        var navForm = $('.navigation-form');
        $(navForm).css("display", "none");
    }

} gralMobile();

function MoveDetailsDiv() {
    var detCredit = $('.det-cred');
    var gralCont = $('.cnt-grl');
    var titButton = $('.ttSect').html();
    var btnDespleg = $('.btn-despleg');
    var liBtncontent = $('.li-cnt-btns');
    var navMobile = $('#mobileNav');
    var btnsPreappr = $('#btnsPreappr');
    var firstContent = $('.content');
    var cntBtns = $('#btnReqs');
    var nanoScroll = $('.nano');

    if (windowWdth <= 974) {
        /*show navmobile*/
        $(navMobile).css("display", "block");
        $(gralInfo).addClass('collapse pstFxPan');

        window.findBut = $(detCredit).hasClass('myClass');
        if (!window.findBut) {
            $(detCredit).addClass('myClass');
            $(detCredit).prepend($("<a class='btn btn-desplg pull-right' id='detButton' role='button' onclick='expPanel()'>" + titButton + "</a>")); /*add button blue into the header*/
        }

        window.findButGbar = $(liBtncontent).hasClass('myClass');
        if (!window.findButGbar) {
            $(liBtncontent).addClass('myClass');
            $(liBtncontent).prepend($("<a class='btn btn-desplg pull-right' role='button' onclick='expPanel()'>" + titButton + "</a>")); /*add button blue into the green bar*/
        }

        window.findButClose = $(gralInfo).hasClass('myClass');
        if (!window.findButClose) {
            $(gralInfo).addClass('myClass');
            $(gralInfo).prepend($("<a class='btn x-cls' id='xCls' role='button' onclick='hidePanel()'>" + "x" + "</a>")); /*add close button*/
        }
        /*add scroll to content*/

        if (windowWdth <= 599) {
            var wndHeight = $(window).height();
            $('#info').css("height", wndHeight - 20 + "px");
        }
        window.addStyles = $(nanoScroll).removeAttr("style");
        $(cntBtns).prepend($(btnsPreappr));
    }
    else {
        $(detCredit).removeClass('myClass');
        $(detCredit).empty();

        $(liBtncontent).removeClass('myClass');
        $('.btn-desplg').remove('');

        $(navMobile).removeAttr("style");

        $(gralInfo).removeClass('myClass');
        $('#xCls').remove();

        $(gralInfo).removeAttr("style");
        $(gralInfo).removeClass('collapse pstFxPan');

        $(firstContent).append($(btnsPreappr));

    }
} MoveDetailsDiv();
function isMobile(t, h) {
    var device = navigator.userAgent.toLowerCase(),
        windowWdth = $(window).width(),
        wndHeight = $(window).height(),
        result = false;

    if ((device.search(/iphone|ipod|ipad|android/) > -1) && (windowWdth <= t) && wndHeight <= h) {
        result = true;
    }
    return result;
}

function expPanel() {
    $('#gralInfo').show("slide", { direction: "left" }, 1000, function () {
    });

    if ($(gralInfo).is(":visible")) {
        $('body').css("overflow", "hidden");
    }
}

function hidePanel() {
    $('#gralInfo').hide("slide", { direction: "left" }, 1000, function () {
    }),
    $('body').removeAttr("style");
}

function showPanelNav() {
    window.btnCloseNav = $('#navbar').prepend($("<a class='btn x-cls bn-nn' role='button' onclick='hidePanelNav()'>" + "x" + "</a>")),
    $('#navbar').show("slide", { direction: "right" }, 1000, function () {
    });

    if ($('#navbar').is(":visible")) {
        $('body').css("overflow", "hidden");
    }

}

function hidePanelNav() {
    $('#navGralx').removeClass("in");
}




