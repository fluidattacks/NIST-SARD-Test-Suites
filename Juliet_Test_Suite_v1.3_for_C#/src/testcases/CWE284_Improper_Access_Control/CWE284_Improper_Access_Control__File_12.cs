/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE284_Improper_Access_Control__File_12.cs
Label Definition File: CWE284_Improper_Access_Control.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 284 Improper Access Control
* Sinks: File
*    GoodSink: Create a file without excessive privileges
*    BadSink : Create a file with excessive privileges
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Security.AccessControl;

using System.Web;

namespace testcases.CWE284_Improper_Access_Control
{
class CWE284_Improper_Access_Control__File_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FLAW: Create a file with excessive privileges */
            string path = @"C:\Temp\WriteText.txt";
            File.Create(path);
        }
        else
        {
            /* FIX: Create a file without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            string path = @"C:\Temp\WriteText.txt";
            FileSecurity fSecurity = new FileSecurity();
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Allow));
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, AccessControlType.Deny));
            File.Create(path, 1024, FileOptions.WriteThrough, fSecurity);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Create a file without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            string path = @"C:\Temp\WriteText.txt";
            FileSecurity fSecurity = new FileSecurity();
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Allow));
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, AccessControlType.Deny));
            File.Create(path, 1024, FileOptions.WriteThrough, fSecurity);
        }
        else
        {
            /* FIX: Create a file without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            string path = @"C:\Temp\WriteText.txt";
            FileSecurity fSecurity = new FileSecurity();
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, AccessControlType.Allow));
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, AccessControlType.Deny));
            File.Create(path, 1024, FileOptions.WriteThrough, fSecurity);
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
