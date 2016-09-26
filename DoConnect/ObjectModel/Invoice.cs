using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{   
    public class Invoice
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string InvoiceSummary { get; set; }
        public decimal Total { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceOwing { get; set; }
        public int PaidStatus { get; set; }
        public int Medical_Aid_ID { get; set; }
        public int Patient_ID { get; set; }
        public string Patient_FirstName { get; set; }
        public string Patient_LastName { get; set; }
        public string Patient_Email { get; set; }
        public int Doctor_ID { get; set; }
        public string Doctor_FirstName { get; set; }
        public string Doctor_LastName { get; set; }
        public string Doctor_Email { get; set; }
        public string Patient_Street_Address { get; set; }
        public string Patient_Suburb { get; set; }
        public string Patient_City { get; set; }
        public string Patient_Country { get; set; }
        public string Patient_Phone_Number { get; set; }
        public string Practice_Name { get; set; }
        public string Practice_Street_Address { get; set; }
        public string Practice_Suburb { get; set; }
        public string Practice_City { get; set; }
        public string Practice_Country { get; set; }
        public string Practice_Phone_Number { get; set; }
        public string Medical_Aid_Name { get; set; }
        public string Medical_Aid_Address { get; set; }
        public string Medical_Aid_Cell_Number { get; set; }
        public string Diagnosis { get; set; }

        public Invoice Create(SqlDataReader reader)
        {
            return new Invoice
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                InvoiceSummary = reader.GetString(reader.GetOrdinal("InvoiceSummary")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),                
                BalanceOwing = reader.GetDecimal(reader.GetOrdinal("BalanceOwing")),
                PaidStatus = reader.GetInt32(reader.GetOrdinal("PaidStatus")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName")),
                Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName")),
                Patient_Email = reader.GetString(reader.GetOrdinal("Patient_Email")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                Doctor_FirstName = reader.GetString(reader.GetOrdinal("Doctor_FirstName")),
                Doctor_LastName = reader.GetString(reader.GetOrdinal("Doctor_LastName")),
                Doctor_Email = reader.GetString(reader.GetOrdinal("Doctor_Email"))
            };
        }

        public Invoice ViewInvoiceByID(SqlDataReader reader)
        {
            return new Invoice
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
                InvoiceSummary = reader.GetString(reader.GetOrdinal("InvoiceSummary")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                AmountPaid = reader.GetDecimal(reader.GetOrdinal("AmountPaid")),
                BalanceOwing = (reader.GetDecimal(reader.GetOrdinal("Total")) - reader.GetDecimal(reader.GetOrdinal("AmountPaid"))),
                PaidStatus = reader.GetInt32(reader.GetOrdinal("PaidStatus")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName")),
                Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName")),
                Patient_Email = reader.GetString(reader.GetOrdinal("Patient_Email")),
                Patient_Street_Address = reader.GetString(reader.GetOrdinal("Patient_Street_Address")),
                Patient_Suburb = reader.GetString(reader.GetOrdinal("Patient_Suburb")),
                Patient_City = reader.GetString(reader.GetOrdinal("Patient_City")),
                Patient_Country = reader.GetString(reader.GetOrdinal("Patient_Country")),
                Patient_Phone_Number = reader.GetString(reader.GetOrdinal("Patient_Phone_Number")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                Doctor_FirstName = reader.GetString(reader.GetOrdinal("Doctor_FirstName")),
                Doctor_LastName = reader.GetString(reader.GetOrdinal("Doctor_LastName")),
                Doctor_Email = reader.GetString(reader.GetOrdinal("Doctor_Email")),
                Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name")),
                Practice_Street_Address = reader.GetString(reader.GetOrdinal("Practice_Street_Address")),
                Practice_Suburb = reader.GetString(reader.GetOrdinal("Practice_Suburb")),
                Practice_City = reader.GetString(reader.GetOrdinal("Practice_City")),
                Practice_Country = reader.GetString(reader.GetOrdinal("Practice_Country")),
                Practice_Phone_Number = reader.GetString(reader.GetOrdinal("Practice_Phone_Number")),
                Medical_Aid_Name = reader.GetString(reader.GetOrdinal("Medical_Aid_Name")),
                Medical_Aid_Address = reader.GetString(reader.GetOrdinal("Medical_Aid_Address")),
                Medical_Aid_Cell_Number = reader.GetString(reader.GetOrdinal("Medical_Aid_Cell_Number"))
            };
        }

        public Invoice GetAllDiagnosisByPatientID(SqlDataReader reader)
        {
            return new Invoice
            {
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Diagnosis = reader.GetString(reader.GetOrdinal("Diagnosis"))
            };
        }
    }
}