﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    // maybe static class :D
    class Verification
    {
        static private String RegExStandard = "";

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
    }
}
