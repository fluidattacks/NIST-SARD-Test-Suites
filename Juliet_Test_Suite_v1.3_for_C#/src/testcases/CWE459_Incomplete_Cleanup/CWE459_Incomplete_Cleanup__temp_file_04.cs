/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE459_Incomplete_Cleanup__temp_file_04.cs
Label Definition File: CWE459_Incomplete_Cleanup.label.xml
Template File: point-flaw-04.tmpl.cs
*/
/*
* @description
* CWE: 459 Incomplete Cleanup
* Sinks: temp_file
*    GoodSink: Delete the temporary file on exit
*    BadSink : Don't delete the temporary file
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE459_Incomplete_Cleanup
{
class CWE459_Incomplete_Cleanup__temp_file_04 : AbstractTestCase
{
    /* The two variables below are declared "const", so a tool should
     * be able to identify that reads of these will always return their
     * initialized values.
     */
    private const bool PRIVATE_CONST_TRUE = true;
    private const bool PRIVATE_CONST_FALSE = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_TRUE)
        {
            string tempPath = Path.GetTempFileName();
            try
            {
                using (StreamWriter sw = File.CreateText(tempPath))
                {
                    IO.WriteLine(sw.ToString());
                    /* FLAW: Do not delete the temporary file */
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Could not create temporary file", exceptIO);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void Good1()
    {
        if (PRIVATE_CONST_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            string tempPath = Path.GetTempFileName();
            try
            {
                using (StreamWriter sw = File.CreateText(tempPath))
                {
                    IO.WriteLine(sw.ToString());
                    /* FIX: Call Delete() so that the file will be deleted */
                    File.Delete(tempPath);
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Could not create temporary file", exceptIO);
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_TRUE)
        {
            string tempPath = Path.GetTempFileName();
            try
            {
                using (StreamWriter sw = File.CreateText(tempPath))
                {
                    IO.WriteLine(sw.ToString());
                    /* FIX: Call Delete() so that the file will be deleted */
                    File.Delete(tempPath);
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Could not create temporary file", exceptIO);
            }
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
