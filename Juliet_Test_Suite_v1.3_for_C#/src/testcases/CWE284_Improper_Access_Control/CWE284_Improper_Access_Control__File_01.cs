/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE284_Improper_Access_Control__File_01.cs
Label Definition File: CWE284_Improper_Access_Control.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 284 Improper Access Control
* Sinks: File
*    GoodSink: Create a file without excessive privileges
*    BadSink : Create a file with excessive privileges
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.AccessControl;

using System.Web;

namespace testcases.CWE284_Improper_Access_Control
{
class CWE284_Improper_Access_Control__File_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        /* FLAW: Create a file with excessive privileges */
        string path = @"C:\Temp\WriteText.txt";
        File.Create(path);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        /* FIX: Create a file without excessive privileges */
        string user = Environment.UserDomainName + "\\" + Environment.UserName;
        string path = @"C:\Temp\WriteText.txt";
        FileSecurity fSecurity = new FileSecurity();
        fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Allow));
        fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, AccessControlType.Deny));
        File.Create(path, 1024, FileOptions.WriteThrough, fSecurity);
    }
#endif //omitgood
}
}
