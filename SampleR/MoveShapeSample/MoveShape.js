/// <reference path="../Scripts/jquery-1.7.1.js" />
/// <reference path="../Scripts/jquery-ui-1.8.20.js" />
/// <reference path="../Scripts/jquery.signalR-1.0.0-rc2.js" />

$(function () {
    /* Note: we are not specifying a path here, where are instead referencing a property.
       This one of the difference between Hubs and PersistentConnections. 
    */
    var hub = $.connection.moveShape,
        $shape = $("#shape");

    $.extend(hub.client, {
        shapeMoved: function (cid, x, y) {
            $shape.css({ left: x, top: y });
        }
    });

    $.connection.hub.start().done(function () {
        $shape.draggable({
            drag: function () {
                hub.server.moveShape(this.offsetLeft || 0, this.offsetTop || 0);
            }
        });
    });
});