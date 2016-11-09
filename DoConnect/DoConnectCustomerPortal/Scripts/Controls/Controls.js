//
$(document).ready(function(){
alert("Hello! I am an alert box!!");
//Acconting Page
	$(".readonly").css("border", "none");
	$(".readonly").css("background-color", "transparent");
	$(".readonly").css("font-size", "13px");
	$(".readonly").css("padding-right", "0px");
	$("#myFunctionAccounting_Edit").show(); $("#myFunctionAccounting_Save").hide();

	$("#myFunctionAccounting_Edit").click(function () {
		$("#myFunctionAccounting_Edit").hide(); $("#myFunctionAccounting_Save").show();
		$(".readonly").attr("readonly", false);
		$(".readonly").css("border", "1px solid #ccc");
	});

	$("#myFunctionAccounting_Save").click(function () {
		$("#myFunctionAccounting_Edit").show(); $("#myFunctionAccounting_Save").hide();
		$(".readonly").attr("readonly", true);
		$(".readonly").css("border", "none");
		$(".readonly").css("background-color", "transparent");
	});

	$(".tr_dblclick").dblclick(function () {
		$("#View_Invoice_Modal").modal("show");
	});

    $(function () {
		$(".datetimepicker").datetimepicker({ format: "L" });
	});
	
//Accounting - Expenses Page
	$(".readonly").css("border", "none");
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $("#myFunctionExpenses_Edit").show(); $("#myFunctionExpenses_Save").hide();
    $("#myFunctionExpenses_Edit").click(function () {

        $("#myFunctionExpenses_Edit").hide(); $("#myFunctionExpenses_Save").show();
        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionExpenses_Save").click(function () {

        $("#myFunctionExpenses_Edit").show(); $("#myFunctionExpenses_Save").hide();

        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    $(".tr_dblclick").dblclick(function () {
        $("#View_Invoice_Modal").modal("show");
    });

    $(function () {
        $(".datetimepicker").datetimepicker({ format: "L" });
    });
	
//Accounting - NewExpenseInvoice Page
	$(function () {
			$(".datetimepicker").datetimepicker({ format: "L" });
		});
	
//Appoitments Page
	$(".readonly").css("border", "none");
    $(".readonly").attr("readonly", true);
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $("#myFunctionAppointments_Edit").show();
    $("#myFunctionAppointments_Save").hide();

    $("#myFunctionAppointments_Edit").click(function () {

        $("#myFunctionAppointments_Edit").hide(); $("#myFunctionAppointments_Save").show();

        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionAppointments_Save").click(function () {
        $("#myFunctionAppointments_Edit").show(); $("#myFunctionAppointments_Save").hide();
        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    function myFunctionAddAppointment() {
        $("#New_Appointment_Modal").modal("show");
    };

    $(".tr_dblclick").dblclick(function () {
        $("#View_Appointment_Modal").modal("show");
        $(".readonly_ViewAppointment").css("border", "none");
        $(".readonly_ViewAppointment").attr("readonly", true);
        $(".readonly_ViewAppointment").css("background-color", "transparent");
    });

    $("#function_btnUpdateAppointment").click(function () {
		var btnText = $(this).html();
        if (btnText == "Update") {
            $(".readonly_ViewAppointment").attr("readonly", false);
            $(".readonly_ViewAppointment").css("border", "1px solid #ccc");
            $("#function_btnUpdateAppointment").html("Save");
        }
        else {
            $(".readonly_ViewAppointment").attr("readonly", true);
            $(".readonly_ViewAppointment").css("border", "none");
            $(".readonly_ViewAppointment").css("background-color", "transparent");
            $("#function_btnUpdateAppointment").html("Update");
        }
    });

    $(function () {
        $(".datetimepicker").datetimepicker();
    });

//Dashboard Page
	/*google.charts.load("current", {"packages":["corechart"]});
    google.charts.setOnLoadCallback(drawVisualization);

    function drawVisualization() {
        // Some raw data (not necessarily accurate)
        var data = google.visualization.arrayToDataTable([
         ["Month", "Bolivia", "Ecuador", "Madagascar", "Papua New Guinea", "Rwanda", "Average"],
         ["2004/05",  165,      938,         522,             998,           450,      614.6],
         ["2005/06",  135,      1120,        599,             1268,          288,      682],
         ["2006/07",  157,      1167,        587,             807,           397,      623],
         ["2007/08",  139,      1110,        615,             968,           215,      609.4],
         ["2008/09",  136,      691,         629,             1026,          366,      569.6]
    ]);

    var options = {
		title : "Monthly Coffee Production by Country",
		vAxis: {title: "Cups"},
		hAxis: {title: "Month"},
		seriesType: "bars",
		series: {5: {type: "line"}}
    };

    var chart = new google.visualization.ComboChart(document.getElementById("chart_div"));
    chart.draw(data, options);
      }*/

	$(".nav li").on("click", function () {
	  $(".nav li").removeClass("active");
	  $(this).addClass("active");
	});
	
//Employees Page
	$(".readonly").css("border", "none");
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $("#myFunctionEmployees_Edit").show(); $("#myFunctionEmployees_Save").hide();

    $("#myFunctionEmployees_Edit").click(function () {

        $("#myFunctionEmployees_Edit").hide(); $("#myFunctionEmployees_Save").show();

        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionEmployees_Save").click(function () {

        $("#myFunctionEmployees_Edit").show(); $("#myFunctionEmployees_Save").hide();

        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    function myFunctionAddEmployee() {
        $("#New_Employee_Modal").modal("show");
    };

    $(".tr_dblclick").dblclick(function () {
        $("#View_Employee_Modal").modal("show");
        $(".readonly_ViewEmployee").attr("readonly", true);
        $(".readonly_ViewEmployee").css("background-color", "transparent");
    });

    $("#function_btnUpdateEmployee").click(function () {
		var btnText = $(this).html();
        if (btnText == "Update") {
            $(".readonly_ViewEmployee").attr("readonly", false);
            $(".readonly_ViewEmployee").css("border", "1px solid #ccc");
            $("#function_btnUpdateEmployee").html("Save");
        }
        else {
            $(".readonly_ViewEmployee").attr("readonly", true);
            $(".readonly_ViewEmployee").css("border", "none");
            $(".readonly_ViewEmployee").css("background-color", "transparent");
            $("#function_btnUpdateEmployee").html("Update");
        }
    });

    $(function () {
        $(".datetimepicker").datetimepicker({ format: "L" });
    });
	
//Events Page
	$(".readonly").css("border", "none");
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $("#myFunctionEvents_Edit").show(); $("#myFunctionEvents_Save").hide();

    $("#myFunctionEvents_Edit").click(function () {

        $("#myFunctionEvents_Edit").hide(); $("#myFunctionEvents_Save").show();

        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionEvents_Save").click(function () {

        $("#myFunctionEvents_Edit").show(); $("#myFunctionEvents_Save").hide();

        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    function myFunctionAddEvent() {
        $("#New_Event_Modal").modal("show");
    };

    $(".tr_dblclick").dblclick(function () {
        $("#View_Event_Modal").modal("show");
        $(".readonly_ViewEvent").css("border", "none");
        $(".readonly_ViewEvent").attr("readonly", true);
        $(".readonly_ViewEvent").css("background-color", "transparent");
    });

    $("#function_btnUpdateEvent").click(function () {
        var btnText = $(this).html();
        if (btnText == "Update") {
            $(".readonly_ViewEvent").attr("readonly", false);
            $(".readonly_ViewEvent").css("border", "1px solid #ccc");
            $("#function_btnUpdateEvent").html("Save");
        }
        else {
            $(".readonly_ViewEvent").attr("readonly", true);
            $(".readonly_ViewEvent").css("border", "none");
            $(".readonly_ViewEvent").css("background-color", "transparent");
            $("#function_btnUpdateEvent").html("Update");
        }
    });

    $(function () {
        $("#datetimepicker1").datetimepicker();
        $("#datetimepicker2").datetimepicker({
            useCurrent: false
        });
        $("#datetimepicker1").on("dp.change", function (e) {
            $("#datetimepicker2").data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker2").on("dp.change", function (e) {
            $("#datetimepicker1").data("DateTimePicker").maxDate(e.date);
        });
    });

    $(function () {
        $("#datetimepicker3").datetimepicker();
        $("#datetimepicker4").datetimepicker({
            useCurrent: false
        });
        $("#datetimepicker3").on("dp.change", function (e) {
            $("#datetimepicker4").data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker4").on("dp.change", function (e) {
            $("#datetimepicker3").data("DateTimePicker").maxDate(e.date);
        });
    });

    $(function () {
        $("#datetimepicker5").datetimepicker();
        $("#datetimepicker6").datetimepicker({
            useCurrent: false
        });
        $("#datetimepicker5").on("dp.change", function (e) {
            $("#datetimepicker6").data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker6").on("dp.change", function (e) {
            $("#datetimepicker5").data("DateTimePicker").maxDate(e.date);
        });
    });
	
//Medical Aid Page
	$(".readonly").css("border", "none");
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $(".readonly_View").css("background-color", "transparent");
    $(".readonly_View").attr("readonly", true);
    $("#myFunctionMedicalAid_Edit").show(); $("#myFunctionMedicalAid_Save").hide();

    $("#myFunctionMedicalAid_Edit").click(function () {

        $("#myFunctionMedicalAid_Edit").hide(); $("#myFunctionMedicalAid_Save").show();

        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionMedicalAid_Save").click(function () {

        $("#myFunctionMedicalAid_Edit").show(); $("#myFunctionMedicalAid_Save").hide();

        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    $(".tr_dblclick").dblclick(function () {
		$("#View_MedicalAid_Modal").modal("show");
    });

    $("#function_btnUpdateMedicalAid").click(function () {
		var btnText = $(this).html();
		
        if (btnText == "Update") {
            $(".readonly_View").attr("readonly", false);
            $(".readonly_View").css("border", "1px solid #ccc");
            $("#function_btnUpdateMedicalAid").html("Save");
        }
        else {
            $(".readonly_View").attr("readonly", true);
            $(".readonly_View").css("border", "none");
            $(".readonly_View").css("background-color", "transparent");
            $("#function_btnUpdateMedicalAid").html("Update");
        }
    });

    $(function () {
        $(".datetimepicker").datetimepicker({ format: "L" });
    });
	
//Meddicine Inventory Page
	$(".readonly").css("border", "none");
    $(".readonly").css("background-color", "transparent");
    $(".readonly").css("font-size", "13px");
    $(".readonly").css("padding-right", "0px");
    $(".readonly_ViewMedicine").attr("readonly", true);
    $("#myFunctionMedicineInventory_Edit").show(); $("#myFunctionMedicineInventory_Save").hide();

    $("#myFunctionMedicineInventory_Edit").click(function () {

        $("#myFunctionMedicineInventory_Edit").hide(); $("#myFunctionMedicineInventory_Save").show();

        $(".readonly").attr("readonly", false);
        $(".readonly").css("border", "1px solid #ccc");
    });

    $("#myFunctionMedicineInventory_Save").click(function () {

        $("#myFunctionMedicineInventory_Edit").show(); $("#myFunctionMedicineInventory_Save").hide();

        $(".readonly").attr("readonly", true);
        $(".readonly").css("border", "none");
        $(".readonly").css("background-color", "transparent");
    });

    $(".tr_dblclick").dblclick(function () {
        $("#View_Medicine_Modal").modal("show");
        $(".readonly_ViewMedicine").attr("readonly", true);
        $(".readonly_ViewMedicine").css("background-color", "transparent");
    });

    $("#function_btnUpdateMedicine").click(function () {
        var btnText = $(this).html();
        if (btnText == "Update") {
            $(".readonly_ViewMedicine").attr("readonly", false);
            $(".readonly_ViewMedicine").css("border", "1px solid #ccc");
            $("#function_btnUpdateMedicine").html("Save");
        }
        else {
            $(".readonly_ViewMedicine").attr("readonly", true);
            $(".readonly_ViewMedicine").css("border", "none");
            $(".readonly_ViewMedicine").css("background-color", "transparent");
            $("#function_btnUpdateMedicine").html("Update");
        }
    });

    $(function () {
        $(".datetimepicker").datetimepicker({ format: "L" });
    });

//New Medicine Page
	$(function () {
        $(".datetimepicker").datetimepicker({ format: "L" });
    });

//Message Page
	$("#div_Compose_Message").hide();
    $("#div_Sent_list").hide();

    function FunctionInbox() {
        $("#div_Message_list").show();
        $("#h2_ContentHeading").html("Inbox");
        $("#div_Compose_Message").hide();
        $("#div_Sent_list").hide();
    };

    function FunctionComposeMessage() {
        $("#div_Compose_Message").show();
        $("#h2_ContentHeading").html("Compose Message");
        $("#div_Message_list").hide();
        $("#div_Sent_list").hide();
    };

    function FunctionSent() {
        $("#div_Sent_list").show();
        $("#div_Message_list").hide();
        $("#h2_ContentHeading").html("Sent Messages");
        $("#div_Compose_Message").hide();
    };

    $(".tr_dblclick").dblclick(function () {
        $("#View_SelectedInboxMail").modal("show");
        $(".readonly_ViewEvent").css("border", "none");
        $(".readonly_ViewEvent").attr("readonly", true);
        $(".readonly_ViewEvent").css("background-color", "transparent");
    });   

//Patients Page
	$(".readonly").css("border", "none");
	$(".readonly").css("background-color", "transparent");
	$(".readonly").css("font-size", "13px");
	$(".readonly").css("padding-right", "0px");
	$("#myFunctionPatients_Edit").show(); $("#myFunctionPatients_Save").hide();

	$("#myFunctionPatients_Edit").click(function () {

		$("#myFunctionPatients_Edit").hide(); $("#myFunctionPatients_Save").show();

		$(".readonly").attr("readonly", false);
		$(".readonly").css("border", "1px solid #ccc");
	});

	$("#myFunctionPatients_Save").click(function () {

		$("#myFunctionPatients_Edit").show(); $("#myFunctionPatients_Save").hide();

		$(".readonly").attr("readonly", true);
		$(".readonly").css("border", "none");
		$(".readonly").css("background-color", "transparent");
	});

	function myFunctionAddPatient() {
		$("#Add_Patient_Modal").modal("show");
	};
	
	function myFunctionViewPatient() {
		$("#div_Medical_History").modal("show");
	};
	
	$(".View_readonly").attr("readonly", true);
	$(".View_readonly").css("border", "1px solid #ccc");
	$(".View_readonly").css("background-color", "transparent");

	$(".View_readonly").attr("readonly", true);
	$("#btnUpdateMedicalRecord").click(function () {
		var btnText = $(this).html();
		if (btnText == "Update") {
			$(".View_readonly").attr("readonly", false);
			$("#btnUpdateMedicalRecord").html("Save");
			$(".View_readonly").css("border", "1px solid #ccc");
		}
		else {
			$(".View_readonly").attr("readonly", true);
			$("#btnUpdateMedicalRecord").html("Update");
			$(".View_readonly").css("border", "1px solid #ccc");
		}
	});

	$("#btnUpdateConsultation").click(function () {
		var btnText = $(this).html();
		if (btnText == "Update") {
			$(".View_readonly").attr("readonly", false);
			$("#btnUpdateConsultation").html("Save");
			$(".View_readonly").css("border", "1px solid #ccc");
		}
		else {
			$(".View_readonly").attr("readonly", true);
			$("#btnUpdateConsultation").html("Update");
			$(".View_readonly").css("border", "1px solid #ccc");
		}
	});

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

	$(function () {
		$(".datetimepicker").datetimepicker({ format: "L" });
	});

//Index Page - User Profile Model
});//Script end

