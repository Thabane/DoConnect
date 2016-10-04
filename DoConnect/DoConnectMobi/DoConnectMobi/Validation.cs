using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DoConnectMobi
{
    public class Validation
    {
        public bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }

        public bool isValidPassword(string password, string confirmPassword)
        {
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            bool lengthReq = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool upperReq = false;
            bool loweReq = false;
            bool numericalReq = false;
            bool passwordMatch = false;
            if (lengthReq)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                        upperReq = true;
                    else if (char.IsLower(c))
                        loweReq = true;
                    else if (char.IsDigit(c))
                        numericalReq = true;
                }
                if (password.Equals(confirmPassword))
                    passwordMatch = true;
                else
                    passwordMatch = false;
            }
            else
                lengthReq = false;
            bool IsPasswordValid = lengthReq && upperReq && loweReq && numericalReq && passwordMatch;
            return IsPasswordValid;
        } 
    }
}