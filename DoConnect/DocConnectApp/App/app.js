var app = angular.module('app', ['ngRoute', 'ngLocationUpdate', 'angularUtils.directives.dirPagination', 'ngBootbox']);

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
            .when("/ConsultationNotes", {
                templateUrl: "App/Views/Patients/PatientRecord/ConsultationNotes.html",
                controller: "PatientsController"
            })
            .when("/NewConsultationNotes", {
                templateUrl: "App/Views/Patients/PatientRecord/NewConsultationNotes.html",
                controller: "PatientsController"
            })
            .when("/MedicalHistory", {
                templateUrl: "App/Views/Patients/PatientRecord/MedicalHistory.html",
                controller: "PatientsController",
                reloadOnSearch: false
            })
            .when("/PrescriptionDetails", {
                templateUrl: "App/Views/Patients/PatientRecord/PrescriptionDetails.html",
                controller: "PatientsController"
            })            
            .when("/Appointments", {
                templateUrl: "App/Views/Appointments/Appointments.html",
                controller: "AppointmentsController"
            })
            .when("/NewAppointment", {
                templateUrl: "App/Views/Appointments/NewAppointment.html",
                controller: "AppointmentsController"
            })            
            .when("/MedicalAid", {
                templateUrl: "App/Views/MedicalAid/MedicalAid.html",
                controller: "MedicalAidController"
            })            
            .when("/Practices", {
                templateUrl: "App/Views/Practices/Practices.html",
                controller: "PracticesController"
            })
            
            .when("/Accounting", {
                templateUrl: "App/Views/Accounting/Accounting.html",
                controller: "AccountingController"
            })            
            .when("/NewPatientInvoice", {
                templateUrl: "App/Views/Accounting/NewPatientInvoice.html",
                controller: "AccountingController"
            })
            .when("/Events", {
                templateUrl: "App/Views/Events/Events.html",
                controller: "EventsController"
            })            
            .when("/Messages", {
                templateUrl: "App/Views/Messages/Messages.html",
                controller: "MessagesController"
            })            
            .when("/UserProfile", {
                templateUrl: "App/Views/UserProfile/UserProfile.html",
                controller: "UserProfileController"
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
            requireBase: true
        });

        $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
    }
]);

app.run(
    [
    '$route', '$rootScope', '$location', function ($route, $rootScope, $location) {
        var original = $location.path;
        $location.path = function (path, reload) {
            if (reload === false) {
                var lastRoute = $route.current;
                var un = $rootScope.$on('$locationChangeSuccess', function () {
                    $route.current = lastRoute;
                    un();
                });
            }
            return original.apply($location, [path]);
        };
    }
    ]);