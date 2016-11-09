app.factory('DoctorsService',
    function ($http) {

    	//Select all Practice data
    	var GetAllDoctors = function () {
    		return $http.get("api/Doctors/GetAllDoctors");
    	};

    	//Select Practice by ID
    	var GetDoctorByID = function (ID) {
    		return $http.get("api/Doctors/GetDoctor/" + ID);
    	};

        //Set As Preffered Doctor
    	var SetAsPreffered = function (PrefferedDoctor) {
    	    return $http.get("api/Doctors/SetAsPreffered/" + PrefferedDoctor);
    	};

    	return {
    		GetAllDoctors: GetAllDoctors,
    		GetDoctorByID: GetDoctorByID,
    		SetAsPreffered: SetAsPreffered
    	};
    }
);