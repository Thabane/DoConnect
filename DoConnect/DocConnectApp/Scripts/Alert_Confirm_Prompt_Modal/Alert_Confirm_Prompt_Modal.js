var calbackParam = false;
function ezBSAlert(options) {
    var deferredObject = $.Deferred();
    var defaults = {
        type: "alert", //alert, prompt,confirm 
        modalSize: 'modal-sm', //modal-sm, modal-lg
        okButtonText: 'Ok',
        cancelButtonText: 'Cancel',
        yesButtonText: 'Yes',
        noButtonText: 'No',
        headerText: 'Confirm Delete',
        messageText: 'Message',
        alertType: 'default', //default, primary, success, info, warning, danger
        inputFieldType: 'text', //could ask for number,email,etc
    }
    $.extend(defaults, options);

    var _show = function () {
        var headClass = "navbar-default";
        switch (defaults.alertType) {
            case "primary":
                headClass = "alert-primary";
                break;
            case "success":
                headClass = "alert-success";
                break;
            case "info":
                headClass = "alert-info";
                break;
            case "warning":
                headClass = "alert-warning";
                break;
            case "danger":
                headClass = "alert-danger";
                break;
        }
        $('BODY').append(
            '<div id="ezAlerts" class="modal fade">' +
            '<div class="modal-dialog" class="' + defaults.modalSize + '">' +
            '<div class="modal-content">' +
            '<div id="ezAlerts-header" class="modal-header ' + headClass + '">' +
            '<button id="close-button" type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>' +
            '<h4 id="ezAlerts-title" class="modal-title">Modal title</h4>' +
            '</div>' +
            '<div id="ezAlerts-body" class="modal-body">' +
            '<div id="ezAlerts-message" ></div>' +
            '</div>' +
            '<div id="ezAlerts-footer" class="modal-footer">' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>'
        );

        $('.modal-header').css({
            'padding': '15px 15px',
            '-webkit-border-top-left-radius': '5px',
            '-webkit-border-top-right-radius': '5px',
            '-moz-border-radius-topleft': '5px',
            '-moz-border-radius-topright': '5px',
            'border-top-left-radius': '5px',
            'border-top-right-radius': '5px'
        });

        $('#ezAlerts-title').text(defaults.headerText);
        $('#ezAlerts-message').html(defaults.messageText);

        var keyb = "false", backd = "static";
        
        switch (defaults.type) {
            case 'alert':
                keyb = "true";
                backd = "true";
                $('#ezAlerts-footer').html('<button class="btn btn-' + defaults.alertType + '">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                    calbackParam = true;
                    $('#ezAlerts').modal('hide');
                });
                break;
            case 'success':
                keyb = "true";
                backd = "true";
                $('#ezAlerts-footer').html('<button class="btn btn-' + defaults.alertType + '">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                    calbackParam = true;
                    $('#ezAlerts').modal('hide');
                });
                break;
            case 'confirm':
                var btnhtml = '<button id="ezok-btn" class="btn btn-primary">' + defaults.yesButtonText + '</button>';
                if (defaults.noButtonText && defaults.noButtonText.length > 0) {
                    btnhtml += '<button id="ezclose-btn" class="btn btn-default">' + defaults.noButtonText + '</button>';
                }
                $('#ezAlerts-footer').html(btnhtml).on('click', 'button', function (e) {
                    if (e.target.id === 'ezok-btn') {
                        calbackParam = true;
                        angular.element(document.getElementById('btnDeleteConfirmed')).scope().DeletePractice();
                        $('#ezAlerts').modal('hide');
                    } else if (e.target.id === 'ezclose-btn') {
                        calbackParam = false;
                        $('#ezAlerts').modal('hide');
                    }
                });
                break;
            case 'prompt':
                $('#ezAlerts-message').html(defaults.messageText + '<br /><br /><div class="form-group"><input type="' + defaults.inputFieldType + '" class="form-control" id="prompt" /></div>');
                $('#ezAlerts-footer').html('<button class="btn btn-primary">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                    calbackParam = $('#prompt').val();
                    $('#ezAlerts').modal('hide');
                });
                break;
        }

        $('#ezAlerts').modal({
            show: false,
            backdrop: backd,
            keyboard: keyb
        }).on('hidden.bs.modal', function (e) {
            $('#ezAlerts').remove();
           deferredObject.resolve(calbackParam);
        }).on('shown.bs.modal', function (e) {
            if ($('#prompt').length > 0) {
                $('#prompt').focus();
            }
        }).modal('show');
    }

    _show();
    return deferredObject.promise();
}

function btnAlert(header_Text, message) {
    var prom = ezBSAlert({
        headerText: header_Text,
        messageText: message,
        alertType: "danger"
    });
};

function btnSuccess(message) {
    $('#ezAlerts-title').text("mySuccess Message");
    var prom = ezBSAlert({
        headerText: "Success Message",
        messageText: message,
        alertType: "success"
    });
};

function btnConfirm(alert_Type, message) {
    ezBSAlert({
        type: "confirm",
        messageText: message,
        alertType: alert_Type
    }).done(function () {
        if (calbackParam == true) {
            alert("calbackParam =" + calbackParam);
            $("#View_Practice_Modal").modal("hide");
            ezBSAlert({
                headerText: "Success Message",
                    messageText: "Practice successfully deleted.",
                    alertType: "success"
            });
        }        
    });
};

function btnPrompt() {
    ezBSAlert({
        type: "prompt",
        messageText: "Enter Something",
        alertType: "primary"
    }).done(function (e) {
        ezBSAlert({
            messageText: "You entered: " + e,
            alertType: "success"
        });
    });
};

//-------------------------------------------------------------------------------//
//Accounting
function ViewInvoice() {
    $("#View_Invoice_Modal").modal("show");
};
//Appointments Page
function ViewExpense() {
    $("#View_Expense_Modal").modal("show");
    $(".readonly_ViewExpense").attr("readonly", true); $(".disable_ViewExpense").prop("disabled", true);
    $(".readonly_ViewExpense").css("background-color", "transparent");
};

//Appointments Page
function ViewAppointment() {
    $("#View_Appointment_Modal").modal("show");
    $(".readonly_ViewAppointment").attr("readonly", true); $(".disable_ViewAppointment").prop("disabled", true);
    $(".readonly_ViewAppointment").css("background-color", "transparent");
};

//Employee Page
function ViewEmployee() {
    $("#View_Employee_Modal").modal("show");
    $(".readonly_ViewEmployee").attr("readonly", true); $(".disable_ViewEmployee").prop("disabled", true);
    $(".readonly_ViewEmployee").css("background-color", "transparent");    
    $(".View").show(); $(".Update").hide();
};

//Events Page
function ViewEvent() {
    $("#View_Event_Modal").modal("show");
    $(".readonly_ViewEvent").attr("readonly", true);
    $(".readonly_ViewEvent").css("background-color", "transparent");
};

//Medical Aid Page
function ViewMedicalAid() {
    $("#View_MedicalAid_Modal").modal("show");
};

//Medicine Inventory Page
function ViewMedicine() {
    $("#View_Medicine_Modal").modal("show");
    $(".readonly_ViewMedicine").attr("readonly", true);
    $(".readonly_ViewMedicine").css("background-color", "transparent");
};

//Messages Page
function ViewInboxMessage() {
    $("#View_SelectedInboxMail").modal("show");
    $(".readonly_ViewEvent").attr("readonly", true);
    $(".readonly_ViewEvent").css("background-color", "transparent");
};

function ShowReplyMessageModel() {
    $("#ShowReplyMessageModel").modal("show");
};

function ViewSentMessage() {
    $("#ViewSentMessage").modal("show");
};

//Practices Page
function ViewPractice() {
    $("#View_Practice_Modal").modal("show");
    $(".readonly_ViewPractice").attr("readonly", true); 
    $(".readonly_ViewPractice").css("background-color", "transparent");
};

//Patients
function ViewPatient() {
    $("#div_Medical_History").modal("show");
};

function myFunctionShowMedical_History() {
    $("#div_Medical_History").modal("show");
    $("#div_Prescriptions").modal("hide");
    $("#div_Consultations").modal("hide");
};

function myFunctionShowPrescriptions() {
    $("#div_Prescriptions").modal("show");
    $("#div_Medical_History").modal("hide");
    $("#div_Consultations").modal("hide");
};

function myFunctionPrescriptions_Edit() {
    $("#div_Prescriptions_Update").modal("show");
};
function myFunctionShowConsultations() {
    $("#div_Consultations").modal("show");
    $("#div_Medical_History").modal("hide");
    $("#div_Prescriptions").modal("hide");
};

function btnRedirect(Page, PatientID) {
    window.location.href = "/#/" + Page + PatientID;
};

function btnRedirect(Page) {
    window.location.href = "/#/" + Page;
};

//Dashboard
function View_NotificationsPanel_Modal() {
    $("#View_NotificationsPanel_Modal").modal("show");
};
function AppointmentsModal() {
    $("#AppointmentsModal").modal("show");
};

//Reports
function View_Patients_Demographic_Graph_Modal() {
    $("#View_Patients_Demographic_Graph_Modal").modal("show");
};

function View_Financial_Modal() {
    $("#View_Financial_Modal").modal("show");
};

function ViewUninvoicedConsultations() {
    $("#ViewUninvoicedConsultations").modal("show");
};

function AddUninvoicedConsultations() {
    $("#CloseModel_ViewUninvoicedConsultations").trigger("click");
    $("#AddUninvoicedConsultations").modal("show");
};

function ChangeDocModal() {
    $("#ChangeDocModal").modal("show");
};