/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery.signalR-1.0.0-rc2.js" />

$(function () {
    var myConnection = $.connection("/chat");

    myConnection.received(function (data) {
        $("#messages").append("<li>" + data.Name + ': ' + data.Message + "</li>");
    });

    myConnection.error(function (error) {
        console.warn(error);
    });

    myConnection.start()
        .promise()
        .done(function () {
            $("#send").click(function () {
                debugger;
                var myName = $("#Name").val();
                var myMessage = $("#Message").val();
                myConnection.send(JSON.stringify({ name: myName, message: myMessage }));
            })
        });
});