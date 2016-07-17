var app = angular.module('app', ['ngRoute', 'ngLocationUpdate']);

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
            .when("/Accounting", {
                templateUrl: "App/Views/Accounting/Accounting.html",
                controller: "AccountingController"
            })
            .when("/Events", {
                templateUrl: "App/Views/Events/Events.html",
                controller: "EventsController"
            })
            .when("/DiagnosisExpertSystem", {
                templateUrl: "App/Views/DiagnosisExpertSystem/DiagnosisExpertSystem.html",
                controller: "DiagnosisExpertSystemController"
            })
            .when("/Reports", {
                templateUrl: "App/Views/Reports/Reports.html",
                controller: "ReportsController"
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
