/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE459_Incomplete_Cleanup__temp_file_01.cs
Label Definition File: CWE459_Incomplete_Cleanup.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 459 Incomplete Cleanup
* Sinks: temp_file
*    GoodSink: Delete the temporary file on exit
*    BadSink : Don't delete the temporary file
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE459_Incomplete_Cleanup
{
class CWE459_Incomplete_Cleanup__temp_file_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
