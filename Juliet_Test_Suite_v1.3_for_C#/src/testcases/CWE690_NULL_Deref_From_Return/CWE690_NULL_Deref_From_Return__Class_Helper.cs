/*
 * @description A user function in this helper class returns null.  Calling methods should 
 *   be checking returned values against null.
 * 
 * */

using System;
using System.Text;

namespace testcases.CWE690_NULL_Deref_From_Return
{
    class CWE690_NULL_Deref_From_Return__Class_Helper
    {

        public static string getStringBad()
        {
            return null;
        }

        public static string getStringGood()
        {
            return "getStringGood";
        }

        public static StringBuilder getStringBuilderBad()
        {
            return null;
        }

        public static StringBuilder getStringBuilderGood()
        {
            return new StringBuilder("getStringBuilderGood");
        }

    }
}
