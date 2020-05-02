$(document).ready(function () {
    $('#btnSubmit').click(function () {
        SendMail();
    });
});

function ValidateForm() {
    if ($('#name').val().length == 0 || $('#name').val() == ""
        || $('#mobileNo').val() == "" || $('#mobileNo').val().length == 0) {
        ShowValidationMessage();
        return false;
    }
    return true;
}
function SendMail() {
    var data;
    if (!ValidateForm())
        return false;
    var mail = new Object();
    mail.Sender = $('#name').val();
    mail.MobileNumber = $('#mobileNo').val();
    mail.Package = $('#package').val();
    $.ajax({
        type: "POST",
        url: "/Home/Mail",
        data: JSON.stringify(mail),
        contentType: "application/json",
        dataType: "json",
        async: true,

        success: function (msg) {
            data = msg.d;
        },
        beforeSend: function () {
           //Show overlay div
            $('#btnSubmit').hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (XMLHttpRequest.responseText != 'Thread was being aborted.') {
                //Notify('Sessionsion has been expired,</br> Please login in again','');
            }
           
        },
        complete: function () {
            // Hide overlay div
            $('#btnSubmit').show();
            ShowMessage();
        }
    });
    return data;
}

function ShowMessage() {
    $("#dialog-message").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function ShowValidationMessage() {
    $("#dialog-alert").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}