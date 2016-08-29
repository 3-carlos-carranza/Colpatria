$(document).ready(function () {
    //bindActTab();
    bindTitPage();
});

$(window).resize(function () {
    windowWdth = $(window).width();
    MoveDetailsDiv();
    //padTab();
    hidePanelResize();
    //bindActTab();
    bindTitPage();
    setDinamycColumns();
});

windowWdth = $(window).width();
windowHgt = $(window).height();
gralInfo = $('#gralInfo');


function bindTitPage() {
    var fatCont = $('.nvs-fna'),
        liItem = $('li.active', fatCont),
        aContent = $('span', liItem).html();
        if (windowWdth <= 991) {
            var itemBindTit = $('.titmenSect').html(aContent);
        }


}
bindTitPage();

function bindActTab() {
    var navTbs = $('.cnt-tb').height();
    var padStyle = { "padding-top": navTbs + 10 + "px" };
    var formPd = $('.form-to-pad');

    if (windowWdth <= 991) {
        $(formPd).css(padStyle);
    } else {
        $(formPd).removeAttr("style");
    }
}
//bindActTab();


function padTab() {
    var navTbs = $('.cnt-tb').height(),
            padStyle = {
                paddingTop: navTbs + 10 + "px"
            },
            formPd = $('.form-to-pad');

    if (windowWdth <= 991) {
        $(formPd).css(padStyle);
    } else {
        $(formPd).removeAttr("style");
    }
}
//padTab();



function showPanelNav() {

    if (!$("#navGral > .btn.x-cls.bn-nn").length) {
        $('#navGral').prepend($("<a class='close' role='button' onclick='hidePanelNav()'>" + "<span class='fa fa-close'></span>" + "</a>"));
    }

    $('#navGral').show("slide", { direction: "right" }, 1000, function () { });

    //if ($('#navGral').is(":visible")) {
    //    $('body').css("overflow", "hidden");
    //}

}

function hidePanelNav() {
    $('#navGralx').removeClass("in");

    
}

function hidePanelResize() {

    if (windowWdth >= 754) {
        $('#navGral').hide("slide", { direction: "right" }, 100, function() {});
        
    }
}

hidePanelResize();



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

function MoveDetailsDiv() {
    if (windowWdth <= 991) {
        var closeBtn = $('#xCls').length;

        $(gralInfo).addClass('collapse pstFxPan');
        if (!closeBtn) {
            $(gralInfo).prepend($("<a class='close' style='display: block;' id='xCls' role='button' onclick='hidePanel()'>" + "<span class='fa fa-close'></span>" + "</a>"));
        }
    } else {
        $(gralInfo).removeClass('collapse pstFxPan'),
        $(gralInfo).removeAttr('style'),
        $('#xCls').remove();
    }

}
MoveDetailsDiv();

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


function preApprovedCard() {
    var princContainer = $('#btnsPreappr');
    var cntButtons = $('.cnt-btns-ppc');
    var RecButtons = $('.rcv-btns-ppc');


    if (windowWdth <= 1200) {

        var lnkInfo = $('.det-but').html("Agilizar su trámite");
        $(RecButtons).append($(cntButtons));
    } else {
        $(princContainer).append($(cntButtons));
    }
}


function setDinamycColumns() {
    if (!$("#gralInfo").length) {
        $(".det-but").hide();
    }

    if (windowWdth <= 767) {
        $(".labelfield").removeClass("col-md-3 col-sm-5");
        $(".controlfield").removeClass("col-md-9 col-sm-7");

        $(".labelfield, .controlfield").addClass("col-xs-12");
        $(".labelfield").css({ "text-align": "left" });

    } else {
        $(".labelfield").addClass("col-md-3 col-sm-5");
        $(".controlfield").addClass("col-md-9 col-sm-7");
        $(".labelfield").css({ "text-align": "right" });
    }
}

setDinamycColumns();


function logoff() {
    $("#formlogof").submit();
}



