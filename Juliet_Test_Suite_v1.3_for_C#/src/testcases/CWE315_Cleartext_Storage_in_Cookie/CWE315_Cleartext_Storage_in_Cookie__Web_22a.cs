/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_22a.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 315 Cleartext storage of data in a cookie
 * BadSource:  Set data to credentials (without hashing or encryption)
 * GoodSource: Set data to a hash of credentials
 * Sinks:
 *    GoodSink: Hash data before storing in cookie
 *    BadSink : Store data directly in cookie
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;
using System.Web;

using System.Security;

namespace testcases.CWE315_Cleartext_Storage_in_Cookie
{
class CWE315_Cleartext_Storage_in_Cookie__Web_22a : AbstractTestCaseWeb
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        badPublicStatic = true;
        CWE315_Cleartext_Storage_in_Cookie__Web_22b.BadSink(data , req, resp);
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
        GoodG2B(req, resp);
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        goodB2G1PublicStatic = false;
        CWE315_Cleartext_Storage_in_Cookie__Web_22b.GoodB2G1Sink(data , req, resp);
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        goodB2G2PublicStatic = true;
        CWE315_Cleartext_Storage_in_Cookie__Web_22b.GoodB2G2Sink(data , req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        using (SecureString securePwd = new SecureString())
        {
            using( SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* FIX: Set data to a hash of credentials */
                {
                    string salt = "ThisIsMySalt";
                    using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                    {
                        string credentialsToHash = secureUser.ToString() + ":" + securePwd.ToString();
                        byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, credentialsToHash));
                        byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                        data = IO.ToHex(hashedCredsAsBytes);
                    }
                }
            }
        }
        goodG2BPublicStatic = true;
        CWE315_Cleartext_Storage_in_Cookie__Web_22b.GoodG2BSink(data , req, resp);
    }
#endif //omitgood
}
}
