app.controller("AccountingController", ["$scope", "AccountingService", "$interval", "$filter", "$ngBootbox", "$location",
    function ($scope, AccountingService, $interval, $filter, $ngBootbox, $location) {

        $scope.PageTitleAccounting = 'Accounting';
        $scope.PageTitleExpenses = 'Expenses';
        $scope.PageTitleNewExpenseEntry = 'New Expense Entry';
        $scope.PageTitleNewPatientInvoiceEntry = 'New Patient Invoice Entry';

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }
        //--#region Invoices------------------------------------------------------------------------------------------------------
        
        $scope.today = $filter('date')(new Date(), 'yyyy-MM-dd');

        $scope.GetInvoices = function () {
            AccountingService.GetAllInvoices().then(function (result) {
                $scope.Invoices = result.data;
                $scope.numOfUnPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfUnPaid;
                $scope.numOfPatiallyPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfPatiallyPaid;
            });            

            AccountingService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID = result["User_ID"];
                sessionStorage.SessionData_FirstName = result["FirstName"];
                sessionStorage.SessionData_LastName = result["LastName"];
                sessionStorage.SessionData_Email = result["Email"];
                sessionStorage.SessionData_Practice_ID = result["Practice_ID"];
                sessionStorage.SessionData_AccessLevel = result["AccessLevel"];                
            });
        };
        $scope.GetInvoices();

        $scope.ViewUnInvoicedConsultations = function () {
            AccountingService.ViewUnInvoicedConsultations().success(function (result) {
                $scope.UnInvoicedConsultations = result;
                $scope.numOfUnInvoicedConsultations = $scope.UnInvoicedConsultations.length;
            });
        };
        $scope.ViewUnInvoicedConsultations();

        $scope.SelectedConsultationDetails = function (__Consultation_ID, __PatientFullName, __DoctorFullName, __Patient_ID, __Doctors_ID, __Medical_Aid_ID, __Diagnosis, __Additionalfee) {
            $scope.__Consultation_ID = __Consultation_ID;
            $scope.__PatientFullName = __PatientFullName;
            $scope.__DoctorFullName = __DoctorFullName;
            $scope.__Patient_ID = __Patient_ID;
            $scope.__Doctors_ID = __Doctors_ID;
            $scope.__Medical_Aid_ID = __Medical_Aid_ID;
            $scope.__Diagnosis = __Diagnosis;
            $scope.__Additionalfee = __Additionalfee;
        };        

        if (sessionStorage.SessionData_AccessLevel == '1' || sessionStorage.SessionData_AccessLevel == '2') {
            angular.element(".doctorControls").show();
        }
        else {
            angular.element(".doctorControls").hide();
        }

        $scope.ViewInvoice = function (ID) {
            AccountingService.GetInvoiceByID(ID).success(function (result) {
                $scope.ID                      = result["ID"];
                $scope.Date                    = result["Date"];
                $scope.InvoiceSummary          = result["InvoiceSummary"];
                $scope.Total                   = result["Total"];
                $scope.AmountPaid              = result["AmountPaid"];                
                $scope.BalanceOwing            = result["BalanceOwing"];
                
                if (result["PaidStatus"] == 0) { $scope.PaidStatus = "Unpaid"; }//0 == Unpaid, 1 == Fully-Paid, 2 == Partially-Paid
                else if (result["PaidStatus"] == 1) { $scope.PaidStatus = "Fully-Paid"; }
                else { $scope.PaidStatus = "Partially-Paid"; }

                $scope.Medical_Aid_ID          = result["Medical_Aid_ID"];
                $scope.Patient_ID              = result["Patient_ID"];
                $scope.Patient_FirstName       = result["Patient_FirstName"];
                $scope.Patient_LastName        = result["Patient_LastName"];
                $scope.Patient_Email           = result["Patient_Email"];
                $scope.Patient_Street_Address  = result["Patient_Street_Address"];
                $scope.Patient_Suburb          = result["Patient_Suburb"];
                $scope.Patient_City            = result["Patient_City"];
                $scope.Patient_Country         = result["Patient_Country"];
                $scope.Patient_Phone_Number    = result["Patient_Country"];
                $scope.Doctor_ID               = result["Doctor_ID"];
                $scope.Doctor_FirstName        = result["Doctor_FirstName"];
                $scope.Doctor_LastName         = result["Doctor_LastName"];
                $scope.Doctor_Email            = result["Doctor_Email"];
                $scope.Practice_Name           = result["Practice_Name"];
                $scope.Practice_Street_Address = result["Practice_Street_Address"];
                $scope.Practice_Suburb         = result["Practice_Suburb"];
                $scope.Practice_City           = result["Practice_City"];
                $scope.Practice_Country        = result["Practice_Country"];
                $scope.Practice_Phone_Number   = result["Practice_Phone_Number"];
                $scope.Medical_Aid_Name        = result["Medical_Aid_Name"];
                $scope.Medical_Aid_Address     = result["Medical_Aid_Address"];
                $scope.Medical_Aid_Cell_Number = result["Medical_Aid_Cell_Number"];
            });
        };

        $scope.GetPatients = function () {
            AccountingService.GetAllPatients().then(function (result) {
                $scope.Patients = result.data;
            });
        };
        $scope.GetPatients();

        $scope.PatientID = 0;
        $scope.changedValueGetPatientID = function (item) {
            $scope.PatientID = item.ID;
            $scope.MedicalAidID = item.Medical_Aid_ID;
        };

        $scope.GetDiagnosis = function (PatientID) {
            if (PatientID != 0) {
                AccountingService.GetAllDiagnosisByPatientID(PatientID).then(function (result) {
                    $scope.Diagnosis = result.data;
                });
            }            
        };
        $scope.GetDiagnosis(1);
        
        $scope.SelectedDiagnosis = 0;
        $scope.changedValueGetInvoiceSummary = function (item) {
            $scope.SelectedDiagnosis = item.Diagnosis;
        };

        $scope.GetDoctors = function () {
            AccountingService.GetAllDoctors().then(function (result) {
                $scope.Doctors = result.data;
            });
        };
        $scope.GetDoctors();

        $scope.DoctorID = 0;
        $scope.changedValueGetDoctors_ID = function (item) {
            $scope.DoctorID = item.ID;
        };

        $scope.NewInvoice = function (_Total, _AmountPaid) {
            AccountingService.InsertInvoice($scope.today, $scope.SelectedDiagnosis, _Total, _AmountPaid, $scope.MedicalAidID, $scope.PatientID, $scope.DoctorID).success(function () {
                $scope.GetInvoices();
                angular.element(".insert").val('');
                btnSuccess("Invoice successfully inserted.\nThe invoice bill has been sent to the patient.");
                $location.path('/Accounting');
            },
            function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
        };

        $scope.AddUninvoicedConsultations = function (_Total, _AmountPaid) {
            AccountingService.UpdateUnInvoicedConsultations($scope.__Consultation_ID).success(function () {
                $scope.ViewUnInvoicedConsultations();
                    AccountingService.InsertInvoice($scope.today, $scope.__Diagnosis, _Total, _AmountPaid, $scope.__Medical_Aid_ID, $scope.__Patient_ID, $scope.__Doctors_ID).success(function () {
                    $scope.GetInvoices();
                    angular.element("#AddUninvoicedConsultations").trigger("click");
                    angular.element(".insert").val('');
                    btnSuccess("Invoice successfully inserted.\nThe invoice bill has been sent to the patient.");
                },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
            },
            function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });

            
        };

        $scope.function_btnUpdateInvoice= function (ID) {
            var btnText = angular.element("#function_btnUpdateInvoice").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewInvoice").attr("readonly", false);
                angular.element("#function_btnUpdateInvoice").html("Save");
            }
            else {
                AccountingService.UpdateInvoice($scope.ID, $scope.Name, $scope.Phone_Number, $scope.Fax_Number, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Trading_Times).success(function () {
                    $scope.GetInvoices();                    
                    btnSuccess("Invoice details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });

                angular.element(".readonly_ViewInvoice").attr("readonly", true);
                angular.element(".readonly_ViewInvoice").css("background-color", "transparent");
                angular.element("#function_btnUpdateInvoice").html("Update");
            }
        };

        $scope.DeleteInvoice1 = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this Invoice?").then(function () {
                AccountingService.DeleteInvoice(ID).then(function () {
                    $scope.GetInvoices();
                    btnSuccess("Invoice record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
        $scope.DeleteInvoice2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Invoice?").then(function () {
                AccountingService.DeleteInvoice($scope.ID).then(function () {
                    $scope.GetInvoices();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Invoice record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };

        //--#region Expenses------------------------------------------------------------------------------------------------------
        
        $scope.GetExpenses = function () {
            AccountingService.GetAllExpenses().then(function (result) {                
                $scope.Expenses = result.data;
            });
        };
        $scope.GetExpenses();

        $scope.ViewExpense = function (ID) {
            AccountingService.GetExpenseByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.Description = result["Description"];
                $scope.Date = result["Date"];
                $scope.Amount = result["Amount"];
                $scope.Practice_ID = result["Practice_ID"];
                $scope.Practice_Name = result["Practice_Name"];
                $scope.User_ID = result["User_ID"];
                if (result["DoctorFullName"] != null)
                { $scope.User_Name = result["DoctorFullName"]; }
                else { $scope.User_Name = result["StaffFullName"]; }
            });
        };
        
        $scope.NewExpense = function (_Description, _Amount) {
            $scope.GetPracticeIDByUser_ID = function (User_ID) {
                alert(User_ID);
                AccountingService.GetPracticeIDByUser_ID(User_ID).then(function (result) {
                    $scope.PracticeID = result.data["Practice_ID"];
                    alert($scope.PracticeID);
                    AccountingService.InsertExpense(_Description, $scope.today, _Amount, $scope.PracticeID, 2).success(function () {
                        $scope.GetExpenses();
                        angular.element(".insert").val('');
                        btnSuccess("Expense successfully inserted.");
                    },
                        function (error) {
                            btnAlert("System Error Message", "Insert unsuccessful.");
                        });
                });
            };
            $scope.GetPracticeIDByUser_ID(2);//#User_ID Should be a sessionUserId of logged in user            
        };        

        $scope.function_btnUpdateExpense = function () {
            var btnText = angular.element("#function_btnUpdateExpense").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewExpense").attr("readonly", false);
                angular.element("#function_btnUpdateExpense").html("Save");
            }
            else {
                AccountingService.UpdateExpense($scope.ID, $scope.Description, $scope.Amount).success(function () {
                    $scope.GetExpenses();
                    btnSuccess("Expense details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewExpense").attr("readonly", true);
                angular.element(".readonly_ViewExpense").css("background-color", "transparent");
                angular.element("#function_btnUpdateExpense").html("Update");
            }
        };

        $scope.DeleteExpense1 = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this Expense?").then(function () {
                AccountingService.DeleteExpense(ID).then(function () {
                    $scope.GetExpenses();
                    btnSuccess("Expense record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
        $scope.DeleteExpense2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Expense?").then(function () {
                AccountingService.DeleteExpense($scope.ID).then(function () {
                    $scope.GetExpenses();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Expense record successfully deleted.");                    
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
    }]);