﻿var app = angular.module('app', ['ngRoute', 'ngLocationUpdate']);

app.config(
[
    '$routeProvider', '$httpProvider', '$locationProvider',
    function ($routeProvider, $httpProvider, $locationProvider) {

        $routeProvider
            .when("/Dashboard", {
                templateUrl: "App/Views/Dashboard/dashboard.html",
                controller: "DashboardController"
            })
            .when("/DashboardSecretary", {
                templateUrl: "App/Views/Dashboard/DashboardSecretary.html",
                controller: "DashboardController"
            })
            .when("/Patients", {
                templateUrl: "App/Views/Patients/patients.html",
                controller: "PatientsController"
            })
            .when("/Employees", {
                templateUrl: "App/Views/Employees/Employees.html",
                controller: "EmployeesController"
            })
            .when("/Appointments", {
                templateUrl: "App/Views/Appointments/Appointments.html",
                controller: "AppointmentsController"
            })
            .when("/MedicineInventory", {
                templateUrl: "App/Views/MedicineInventory/MedicineInventory.html",
                controller: "MedicineInventoryController"
            })
            .when("/NewMedicine", {
                templateUrl: "App/Views/MedicineInventory/NewMedicine.html",
                controller: "MedicineInventoryController"
            })
            .when("/MedicalAid", {
                templateUrl: "App/Views/MedicalAid/MedicalAid.html",
                controller: "MedicalAidController"
            })
            .when("/NewMedicalAidProvider", {
                templateUrl: "App/Views/MedicalAid/NewMedicalAidProvider.html",
                controller: "MedicalAidController"
            })
            .when("/Accounting", {
                templateUrl: "App/Views/Accounting/Accounting.html",
                controller: "AccountingController"
            })
            .when("/Expenses", {
                templateUrl: "App/Views/Accounting/Expenses.html",
                controller: "AccountingController"
            })
            .when("/NewExpenceInvoice", {
                templateUrl: "App/Views/Accounting/NewExpenceInvoice.html",
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
