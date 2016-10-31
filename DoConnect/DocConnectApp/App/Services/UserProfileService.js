app.factory('UserProfileService',
    ['$http',
    function ($http) {

        var SessionData = function () {
            return $http.get("/Data/SessionData");
        };

        var GetLoggedinUserProfile = function (User_ID) {
            return $http.get("api/UserProfile/GetLoggedinUserProfile/" + User_ID);
        };

        
        var GetPassword = function (User_ID) {
            return $http.get("api/UserProfile/GetPassword/" + User_ID);
        };

        var UpdatePassword = function (User_ID, Password) {
            return $http.post("api/UserProfile/UpdatePassword",
            {
                'User_ID': User_ID,
                'Password': Password
            });
        };

        var UpdateProfileStaff = function (User_ID, FirstName, LastName, ID_Number, Gender, DOB, Phone, Street_Address, Suburb, City, Country) {
            return $http.post("api/UserProfile/UpdateProfileStaff",
            {
                'User_ID': User_ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'ID_Number': ID_Number,
                'Gender': Gender,
                'DOB': DOB,
                'Phone': Phone,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country
            });
        };

        var UpdateProfileDoctor = function (User_ID, FirstName, LastName, Gender, Street_Address) {
            return $http.post("api/UserProfile/UpdateProfileDoctor",
            {
                'User_ID': User_ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'Gender': Gender,
                'Street_Address': Street_Address
            });
        };

        return {
            SessionData: SessionData,
            GetLoggedinUserProfile: GetLoggedinUserProfile,
            GetPassword: GetPassword,
            UpdatePassword: UpdatePassword,
            UpdateProfileStaff: UpdateProfileStaff,
            UpdateProfileDoctor: UpdateProfileDoctor
        };
    }
]);