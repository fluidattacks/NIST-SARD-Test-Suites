/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE284_Improper_Access_Control__RegistryKey_03.cs
Label Definition File: CWE284_Improper_Access_Control.label.xml
Template File: point-flaw-03.tmpl.cs
*/
/*
* @description
* CWE: 284 Improper Access Control
* Sinks: RegistryKey
*    GoodSink: Create a registry key without excessive privileges
*    BadSink : Create a registry key with excessive privileges
* Flow Variant: 03 Control flow: if(5==5) and if(5!=5)
*
* */

using TestCaseSupport;
using System;

using System.Security.AccessControl;
using Microsoft.Win32;

using System.Web;

namespace testcases.CWE284_Improper_Access_Control
{
class CWE284_Improper_Access_Control__RegistryKey_03 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (5 == 5)
        {
            /* FLAW: Create a registry key with excessive privileges */
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("CWE314");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes 5==5 to 5!=5 */
    private void Good1()
    {
        if (5 != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Create a registry key without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
//Allow the current user to read and delete the key.
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.ReadKey | RegistryRights.Delete,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Allow));
//Prevent the current user from writing or changing the permission set of the key
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Deny));
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("CWE314");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (5 == 5)
        {
            /* FIX: Create a registry key without excessive privileges */
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
//Allow the current user to read and delete the key.
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.ReadKey | RegistryRights.Delete,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Allow));
//Prevent the current user from writing or changing the permission set of the key
            rs.AddAccessRule(new RegistryAccessRule(user,
                                                    RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                                                    InheritanceFlags.None,
                                                    PropagationFlags.None,
                                                    AccessControlType.Deny));
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("CWE314");
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
