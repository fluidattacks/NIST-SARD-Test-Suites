/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE284_Improper_Access_Control__RegistryKey_17.cs
Label Definition File: CWE284_Improper_Access_Control.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 284 Improper Access Control
* Sinks: RegistryKey
*    GoodSink: Create a registry key without excessive privileges
*    BadSink : Create a registry key with excessive privileges
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Security.AccessControl;
using Microsoft.Win32;

using System.Web;

namespace testcases.CWE284_Improper_Access_Control
{
class CWE284_Improper_Access_Control__RegistryKey_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        for(int j = 0; j < 1; j++)
        {
            /* FLAW: Create a registry key with excessive privileges */
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("CWE314");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1()
    {
        for(int k = 0; k < 1; k++)
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
    }
#endif //omitgood
}
}
