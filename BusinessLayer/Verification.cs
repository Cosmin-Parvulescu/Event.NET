using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    // maybe static class :D
    class Verification
    {
        static private String RegExStandard = "";
        static private String DateTimeFormat = "yyyy-MM-dd HH:mm";

        static public bool IsStandard(String value)
        {
            return false;
        }

        /// <summary>
        /// Checks the string input for script and html tags. This is a very rough check!
        /// </summary>
        /// <param name="value"></param>
        /// <returns>1 - Clean string | 2 - Scripts detected</returns>
        static public bool IsNotScript(String value)
        {
            if (value.Contains("<script>") || value.Contains("<html>"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the input string is in the right date & time format
        /// </summary>
        /// <param name="value">Contains the date & time as string</param>
        /// <returns>True - correct format | false - incorrect format</returns>
        static public bool IsDateTime(String value)
        {
            try
            {
                DateTime result = DateTime.ParseExact(value, Verification.DateTimeFormat, null);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

    }
}
