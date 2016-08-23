app.factory('EmployeesService',
    function ($http) {
        
        //Select all Employee data
        var GetAllEmployees = function () {
            return $http.get("api/Employees/GetAllEmployees");
        };

        //Select Employee by ID
        var GetEmployeeByID = function (ID) {
            return $http.get("api/Employees/GetEmployee/" + ID);
        };

        //Insert new record
        var InsertEmployee = function (FirstName, LastName, ID_Number, Gender, DOB, Phone, Employee_Type, Practice_ID, Email) {
            return $http.post("api/Employees/InsertEmployee",
            {
                'FirstName': FirstName,
                'LastName': LastName,
                'ID_Number': ID_Number,
                'Gender': Gender,
                'DOB': DOB,
                'Phone': Phone,
                'Employee_Type': Employee_Type,
                'Practice_ID': Practice_ID,
                'Email': Email
            });
        };

        //Update Employee
        var UpdateEmployee = function (ID, FirstName, LastName, ID_Number, Gender, DOB, Phone, Employee_Type, Practice_ID, Email) {
            return $http.post("api/Employees/UpdateEmployee",
            {
                'ID': ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'ID_Number': ID_Number,
                'Gender': Gender,
                'DOB': DOB,
                'Phone': Phone,
                'Employee_Type': Employee_Type,
                'Practice_ID': Practice_ID,
                'Email': Email
            });
        };

        //Delete the Record
        var DeleteEmployee = function (ID) {
            return $http.post("api/Employees/DeleteEmployee/" + ID);
        };

        return {
            GetAllEmployees: GetAllEmployees,
            GetEmployeeByID: GetEmployeeByID,
            InsertEmployee: InsertEmployee,
            UpdateEmployee: UpdateEmployee,
            DeleteEmployee: DeleteEmployee
        };
    }
);