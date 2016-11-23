//$(document).ready(function () {
//    $('#determineUserPopup').dialog({
//        autoOpen: false,
//        closeOnEscape: false,
//        modal: true,
//        width: 400,
//        show: true,
//        position: { my: "center", at: "top+350", of: window },
//        open: function () {
//            $(this).load('/Home/DetermineUser');
//            $('.ui-dialog-titlebar-close').remove();
//            $('.ui-dialog').css('z-index', 1000003);
//            $('.ui-widget-overlay').css('z-index', 1000002);

//        },
//        buttons: [
//        {
//            text: "Ok",
//            icons: {
//                primary: "ui-icon-heart"
//            },
//            click: function () {
//                $(this).dialog("close");
//            }
//        }
//        ]
//    });
//    $(window).resize(function () {
//        $("#determineUserPopup").dialog("option", "position", { my: "center", at: "center", of: window });
//    });

//    if ($.cookie("User") == undefined) {
//        $('#determineUserPopup').dialog('open');
//    }

//});