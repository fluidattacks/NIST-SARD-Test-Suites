/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE681_Incorrect_Conversion_Between_Numeric_Types__double2float_01.cs
Label Definition File: CWE681_Incorrect_Conversion_Between_Numeric_Types.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 681 Incorrect Conversion Between Numeric Types
* Sinks: double2float
*    GoodSink: check for conversion error
*    BadSink : explicit cast
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE681_Incorrect_Conversion_Between_Numeric_Types
{
class CWE681_Incorrect_Conversion_Between_Numeric_Types__double2float_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        try
        {
            /* Enter: 1e50, result should be infinity (for bad case)
             *
             */
            double doubleNumber = 0;
            IO.WriteString("Enter double number (1e50): ");
            try
            {
                doubleNumber = Double.Parse(Console.ReadLine());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.WriteLine("Error parsing number");
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Error parsing number");
            }
            /* FLAW: should not cast without checking if conversion is safe */
            IO.WriteLine("" + (float)doubleNumber);
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with console reading");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        try
        {
            double num = 0;
            IO.WriteString("Enter double number (1e50): ");
            try
            {
                num = Double.Parse(Console.ReadLine());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.WriteLine("Error parsing number");
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Error parsing number");
            }
            /* FIX: check for conversion error */
            if (num > float.MaxValue || num < float.MinValue)
            {
                IO.WriteLine("Error, cannot safely cast this number to a float!");
                return;
            }
            IO.WriteLine("" + (float)num);
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with console reading");
        }
    }
#endif //omitgood
}
}
