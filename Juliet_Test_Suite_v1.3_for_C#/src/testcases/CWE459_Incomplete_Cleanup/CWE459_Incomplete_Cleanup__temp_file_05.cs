/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE459_Incomplete_Cleanup__temp_file_05.cs
Label Definition File: CWE459_Incomplete_Cleanup.label.xml
Template File: point-flaw-05.tmpl.cs
*/
/*
* @description
* CWE: 459 Incomplete Cleanup
* Sinks: temp_file
*    GoodSink: Delete the temporary file on exit
*    BadSink : Don't delete the temporary file
* Flow Variant: 05 Control flow: if(privateTrue) and if(privateFalse)
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE459_Incomplete_Cleanup
{
class CWE459_Incomplete_Cleanup__temp_file_05 : AbstractTestCase
{
    /* The two variables below are not defined as "readonly", but are never
     * assigned any other value, so a tool should be able to identify that
     * reads of these will always return their initialized values.
     */
    private bool privateTrue = true;
    private bool privateFalse = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateTrue)
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
    /* Good1() changes privateTrue to privateFalse */
    private void Good1()
    {
        if (privateFalse)
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
        if (privateTrue)
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
