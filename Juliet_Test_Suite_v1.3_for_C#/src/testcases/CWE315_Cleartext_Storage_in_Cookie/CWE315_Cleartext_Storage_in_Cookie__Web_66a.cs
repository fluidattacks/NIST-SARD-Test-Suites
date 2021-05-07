/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_66a.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-66a.tmpl.cs
*/
/*
 * @description
 * CWE: 315 Cleartext storage of data in a cookie
 * BadSource:  Set data to credentials (without hashing or encryption)
 * GoodSource: Set data to a hash of credentials
 * Sinks:
 *    GoodSink: Hash data before storing in cookie
 *    BadSink : Store data directly in cookie
 * Flow Variant: 66 Data flow: data passed in an array from one method to another in different source files in the same package
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
class CWE315_Cleartext_Storage_in_Cookie__Web_66a : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
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
        string[] dataArray = new string[5];
        dataArray[2] = data;
        CWE315_Cleartext_Storage_in_Cookie__Web_66b.BadSink(dataArray , req, resp );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
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
        string[] dataArray = new string[5];
        dataArray[2] = data;
        CWE315_Cleartext_Storage_in_Cookie__Web_66b.GoodG2BSink(dataArray , req, resp );
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
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
        string[] dataArray = new string[5];
        dataArray[2] = data;
        CWE315_Cleartext_Storage_in_Cookie__Web_66b.GoodB2GSink(dataArray , req, resp );
    }
#endif //omitgood
}
}
