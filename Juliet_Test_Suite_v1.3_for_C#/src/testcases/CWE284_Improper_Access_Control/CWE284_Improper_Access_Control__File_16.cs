/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE284_Improper_Access_Control__File_16.cs
Label Definition File: CWE284_Improper_Access_Control.label.xml
Template File: point-flaw-16.tmpl.cs
*/
/*
* @description
* CWE: 284 Improper Access Control
* Sinks: File
*    GoodSink: Create a file without excessive privileges
*    BadSink : Create a file with excessive privileges
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.AccessControl;

using System.Web;

namespace testcases.CWE284_Improper_Access_Control
{
class CWE284_Improper_Access_Control__File_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        while(true)
        {
            /* FLAW: Create a file with excessive privileges */
            string path = @"C:\Temp\WriteText.txt";
            File.Create(path);
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the conditions on the while statements */
    private void Good1()
    {
        while(true)
        {
            /* FIX: Create a file without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            string path = @"C:\Temp\WriteText.txt";
            FileSecurity fSecurity = new FileSecurity();
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Allow));
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, AccessControlType.Deny));
            File.Create(path, 1024, FileOptions.WriteThrough, fSecurity);
            break;
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
