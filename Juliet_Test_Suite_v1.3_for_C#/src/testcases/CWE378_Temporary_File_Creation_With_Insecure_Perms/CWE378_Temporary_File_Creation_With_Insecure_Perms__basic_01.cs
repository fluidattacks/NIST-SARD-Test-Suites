/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE378_Temporary_File_Creation_With_Insecure_Perms__basic_01.cs
Label Definition File: CWE378_Temporary_File_Creation_With_Insecure_Perms__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 378 Explicitly set permissions on files
* Sinks:
*    GoodSink: Restrict permissions on file
*    BadSink : Permissions never set on file
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.AccessControl;

namespace testcases.CWE378_Temporary_File_Creation_With_Insecure_Perms
{
class CWE378_Temporary_File_Creation_With_Insecure_Perms__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string tempPathB = Path.GetTempFileName();
        try
        {
            using (StreamWriter sw = new StreamWriter(tempPathB))
            {
                /* FLAW: Permissions never set on file */
                /* Write something to the file */
                sw.Write(42);
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to temporary file", exceptIO);
        }
        finally
        {
            /* Delete the temporary file */
            if (File.Exists(tempPathB))
            {
                File.Delete(tempPathB);
            }
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
        string tempPathG = Path.GetTempFileName();
        try
        {
            using (StreamWriter sw = new StreamWriter(tempPathG))
            {
                FileSecurity fSecurity = File.GetAccessControl(tempPathG);
                /* FIX: Set file as writable by owner, readable by owner */
                File.SetAttributes(tempPathG, FileAttributes.Normal);
                /* Write something to the file */
                sw.Write(42);
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to temporary file", exceptIO);
        }
        finally
        {
            /* Delete the temporary file */
            if (File.Exists(tempPathG))
            {
                File.Delete(tempPathG);
            }
        }
    }
#endif //omitgood
}
}
