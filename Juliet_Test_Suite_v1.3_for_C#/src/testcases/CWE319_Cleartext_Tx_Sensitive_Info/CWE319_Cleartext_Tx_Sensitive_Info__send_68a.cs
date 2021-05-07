/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_68a.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-68a.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource:  Establish data as a password
 * GoodSource: Use a regular string (non-sensitive string)
 * Sinks:
 *    GoodSink: encrypted_channel
 *    BadSink : unencrypted_channel
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Security;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__send_68a : AbstractTestCase
{

    public static string data;
#if (!OMITBAD)
    public override void Bad()
    {
        using (SecureString securePwd = new SecureString())
        {
            for (int i = 0; i < "AP@ssw0rd".Length; i++)
            {
                /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                securePwd.AppendChar("AP@ssw0rd"[i]);
            }
            /* POTENTIAL FLAW: Set data to be a password, which can be transmitted over a non-secure
             * channel in the sink */
            data = securePwd.ToString();
        }
        CWE319_Cleartext_Tx_Sensitive_Info__send_68b.BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        /* FIX: Use a regular string (non-sensitive string) */
        data = "Hello World";
        CWE319_Cleartext_Tx_Sensitive_Info__send_68b.GoodG2BSink();
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        using (SecureString securePwd = new SecureString())
        {
            for (int i = 0; i < "AP@ssw0rd".Length; i++)
            {
                /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                securePwd.AppendChar("AP@ssw0rd"[i]);
            }
            /* POTENTIAL FLAW: Set data to be a password, which can be transmitted over a non-secure
             * channel in the sink */
            data = securePwd.ToString();
        }
        CWE319_Cleartext_Tx_Sensitive_Info__send_68b.GoodB2GSink();
    }
#endif //omitgood
}
}
