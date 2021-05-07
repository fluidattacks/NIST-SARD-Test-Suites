/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_08.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-08.tmpl.cs
*/
/*
* @description
* CWE: 315 Cleartext storage of data in a cookie
* BadSource:  Set data to credentials (without hashing or encryption)
* GoodSource: Set data to a hash of credentials
* Sinks:
*    GoodSink: Hash data before storing in cookie
*    BadSink : Store data directly in cookie
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
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
class CWE315_Cleartext_Storage_in_Cookie__Web_08 : AbstractTestCaseWeb
{

    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false. */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
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
        }
        if (PrivateReturnsTrue())
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsFalse())
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

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
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
