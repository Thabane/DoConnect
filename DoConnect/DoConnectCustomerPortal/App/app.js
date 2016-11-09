var app = angular.module('app', ['ngRoute', 'ngLocationUpdate', 'ui.calendar', 'ui.bootstrap', 'ngBootbox']);

app.config(
[
    '$routeProvider', '$httpProvider', '$locationProvider',
    function ($routeProvider, $httpProvider, $locationProvider) {

        $routeProvider
            .when("/Dashboard", {
                templateUrl: "App/Views/Dashboard/dashboard.html",
                controller: "DashboardController"
            })
            .when("/Patients", {
                templateUrl: "App/Views/Patients/patients.html",
                controller: "PatientsController"
            })
            .when("/ConsultationNotes/:PatientID", {
                templateUrl: "App/Views/Patients/PatientRecord/ConsultationNotes.html",
                controller: "PatientsController"
            })
            .when("/test/:PatientID", {
                templateUrl: "App/Views/Patients/test.html",
                controller: "testController"
            })
            .when("/NewConsultationNotes/:PatientID", {
                templateUrl: "App/Views/Patients/PatientRecord/NewConsultationNotes.html",
                controller: "PatientsController"
            })
            .when("/MedicalHistory/:PatientID", {
                templateUrl: "App/Views/Patients/PatientRecord/MedicalHistory.html",
                controller: "PatientsController",
                reloadOnSearch: false
            })
            .when("/PrescriptionDetails/:PatientID", {
                templateUrl: "App/Views/Patients/PatientRecord/PrescriptionDetails.html",
                controller: "PatientsController"
            })
            .when("/NewPrescription/:PatientID/:ConsultationID", {
                templateUrl: "App/Views/Patients/PatientRecord/NewPrescription.html",
                controller: "PatientsController"
            })
            .when("/NewPatient", {
                templateUrl: "App/Views/Patients/NewPatient.html",
                controller: "PatientsController"
            })
            .when("/Appointments", {
                templateUrl: "App/Views/Appointments/Appointments.html",
                controller: "AppointmentsController"
            })
            .when("/AppointmentsCalendar", {
                templateUrl: "App/Views/Calendar/calendar.html",
                controller: "CalendarCtrl"
            })
            .when("/NewAppointment", {
                templateUrl: "App/Views/Appointments/NewAppointment.html",
                controller: "AppointmentsController"
            })
            .when("/Account", {
                templateUrl: "App/Views/Account/Account.html",
                controller: "AccountController"
            })
            .when("/PatientMedicalHistory", {
                templateUrl: "App/Views/MedicalHistory/MedicalHistory.html",
                controller: "MedicalHistoryController"
            })
            .when("/Practices", {
                templateUrl: "App/Views/Practices/Practices.html",
                controller: "PracticesController"
            })
            .when("/NewPractice", {
                templateUrl: "App/Views/Practices/NewPractice.html",
                controller: "PracticesController"
            })
            .when("/Accounting", {
                templateUrl: "App/Views/Accounting/Accounting.html",
                controller: "AccountingController"
            })
            .when("/Events", {
                templateUrl: "App/Views/Events/Events.html",
                controller: "EventsController"
            })
            .when("/NewEvent", {
                templateUrl: "App/Views/Events/NewEvent.html",
                controller: "EventsController"
            })
            .when("/Messages", {
                templateUrl: "App/Views/Messages/Messages.html",
                controller: "MessagesController"
            })
            .when("/DiagnosisExpertSystem", {
                templateUrl: "App/Views/DiagnosisExpertSystem/DiagnosisExpertSystem.html",
                controller: "DiagnosisExpertSystemController"
            })
            .when("/Reports", {
                templateUrl: "App/Views/Reports/Reports.html",
                controller: "ReportsController"
            })
            .when("/UserProfile", {
                templateUrl: "App/Views/UserProfile/UserProfile.html",
                controller: "UserProfileController"
            })
            .when("/Doctors", {
                templateUrl: "App/Views/Doctors/doctors.html",
                controller: "DoctorsController"
            })
            .when("/Billing", {
                templateUrl: "App/Views/Billing/billing.html",
                controller: "BillingController"
            })
            .when("/Login", {
                templateUrl: "App/Views/Login/Login.html",
                controller: "LoginController"
            })
            .otherwise({
                redirectTo: "/Dashboard"
            });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    }
]);

app.run(
    [
    '$route', '$rootScope', '$location', function ($route, $rootScope, $location) {
        $rootScope.loggedOnUser = 0;
    }
    ]);
