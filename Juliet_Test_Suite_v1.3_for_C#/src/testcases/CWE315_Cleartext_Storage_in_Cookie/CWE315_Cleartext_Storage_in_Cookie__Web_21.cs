/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_21.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-21.tmpl.cs
*/
/*
 * @description
 * CWE: 315 Cleartext storage of data in a cookie
 * BadSource:  Set data to credentials (without hashing or encryption)
 * GoodSource: Set data to a hash of credentials
 * Sinks:
 *    GoodSink: Hash data before storing in cookie
 *    BadSink : Store data directly in cookie
 * Flow Variant: 21 Control flow: Flow controlled by value of a private variable. All functions contained in one file.
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
class CWE315_Cleartext_Storage_in_Cookie__Web_21 : AbstractTestCaseWeb
{

    /* The variable below is used to drive control flow in the sink function */
    private bool badPrivate = false;
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
        badPrivate = true;
        BadSink(data , req, resp);
    }

    private void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (badPrivate)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }
#endif //omitbad
    /* The variables below are used to drive control flow in the sink functions. */
    private bool goodB2G1Private = false;
    private bool goodB2G2Private = false;
    private bool goodG2BPrivate = false;
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
        GoodG2B(req, resp);
    }

    /* goodB2G1() - use BadSource and GoodSink by setting the variable to false instead of true */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
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
        goodB2G1Private = false;
        GoodB2G1Sink(data , req, resp);
    }

    private void GoodB2G1Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (goodB2G1Private)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Hash data before storing in cookie */
            {
                string salt = "ThisIsMySalt";
                using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, data));
                    byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                    data = IO.ToHex(hashedCredsAsBytes);
                }
            }
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }

    /* goodB2G2() - use BadSource and GoodSink by reversing the blocks in the if in the sink function */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
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
        goodB2G2Private = true;
        GoodB2G2Sink(data , req, resp);
    }

    private void GoodB2G2Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (goodB2G2Private)
        {
            /* FIX: Hash data before storing in cookie */
            {
                string salt = "ThisIsMySalt";
                using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, data));
                    byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                    data = IO.ToHex(hashedCredsAsBytes);
                }
            }
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }

    /* goodG2B() - use GoodSource and BadSink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
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
        goodG2BPrivate = true;
        GoodG2BSink(data , req, resp);
    }

    private void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (goodG2BPrivate)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }
#endif //omitgood
}
}
