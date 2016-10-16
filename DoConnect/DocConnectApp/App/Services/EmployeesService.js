app.factory('EmployeesService',
    function ($http) {

        var GetAllEmployees = function () {
            return $http.get("api/Employees/GetAllEmployees");
        };

        var GetEmployeeByID = function (ID) {
            return $http.get("api/Employees/GetEmployee/" + ID);
        }

        var GetAllAccessLevel = function () {
            return $http.get("api/Employees/GetAllAccessLevel");
        };

        var GetAccessLevelByID = function (ID) {
            return $http.get("api/Employees/GetAccessLevel/" + ID);
        }

        var GetAllPractices = function () {
            return $http.get("api/Employees/GetAllPractices");
        };

        var InsertEmployee = function (FirstName, LastName, ID_Number, Gender, DOB, Phone, Street_Address, Suburb, City, Country, ACCESSLEVEL_ID, Employee_Type, Practice_ID, Email) {
            return $http.post("api/Employees/InsertEmployee",
            {
                'FirstName': FirstName,
                'LastName': LastName,
                'ID_Number': ID_Number,
                'Gender': Gender,
                'DOB': DOB,
                'Phone': Phone,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'ACCESSLEVEL_ID': ACCESSLEVEL_ID,
                'Employee_Type': Employee_Type,
                'Practice_ID': Practice_ID,
                'Email': Email
            });
        };

        var UpdateEmployee = function (ID, FirstName, LastName, ID_Number, Gender, DOB, Phone, Street_Address, Suburb, City, Country, Employee_Type, Practice_ID, Email) {
            return $http.post("api/Employees/UpdateEmployee",
            {
                'ID': ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'ID_Number': ID_Number,
                'Gender': Gender,
                'DOB': DOB,
                'Phone': Phone,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'Employee_Type': Employee_Type,
                'Practice_ID': Practice_ID,
                'Email': Email
            });
        };

        var DeleteEmployee = function (ID) {
            return $http.post("api/Employees/DeleteEmployee/" + ID);
        };

        return {
            GetAllEmployees: GetAllEmployees,
            GetEmployeeByID: GetEmployeeByID,
            GetAllAccessLevel: GetAllAccessLevel,
            GetAccessLevelByID: GetAccessLevelByID,
            GetAllPractices: GetAllPractices,
            InsertEmployee: InsertEmployee,
            UpdateEmployee: UpdateEmployee,
            DeleteEmployee: DeleteEmployee
        };
    }
);