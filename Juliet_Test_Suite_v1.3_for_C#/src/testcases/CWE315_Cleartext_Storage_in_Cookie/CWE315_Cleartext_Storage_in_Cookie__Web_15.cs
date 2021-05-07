/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_15.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-15.tmpl.cs
*/
/*
* @description
* CWE: 315 Cleartext storage of data in a cookie
* BadSource:  Set data to credentials (without hashing or encryption)
* GoodSource: Set data to a hash of credentials
* Sinks:
*    GoodSink: Hash data before storing in cookie
*    BadSink : Store data directly in cookie
* Flow Variant: 15 Control flow: switch(6) and switch(7)
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
class CWE315_Cleartext_Storage_in_Cookie__Web_15 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        switch (6)
        {
        case 6:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
            break;
        }
        switch (7)
        {
        case 7:
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing the first switch to switch(5) */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        switch (5)
        {
        case 6:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
            break;
        default:
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
            break;
        }
        switch (7)
        {
        case 7:
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing the blocks in the first switch  */
    private void GoodG2B2(HttpRequest req, HttpResponse resp)
    {
        string data;
        switch (6)
        {
        case 6:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
            break;
        }
        switch (7)
        {
        case 7:
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing the second switch to switch(8) */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data;
        switch (6)
        {
        case 6:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
            break;
        }
        switch (8)
        {
        case 7:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        default:
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
        break;
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the second switch  */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data;
        switch (6)
        {
        case 6:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
            break;
        }
        switch (7)
        {
        case 7:
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
        break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B1(req, resp);
        GoodG2B2(req, resp);
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
    }
#endif //omitgood
}
}
