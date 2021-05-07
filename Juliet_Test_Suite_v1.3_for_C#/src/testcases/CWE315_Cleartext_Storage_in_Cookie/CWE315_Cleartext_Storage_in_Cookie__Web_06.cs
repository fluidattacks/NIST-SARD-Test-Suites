/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_06.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-06.tmpl.cs
*/
/*
* @description
* CWE: 315 Cleartext storage of data in a cookie
* BadSource:  Set data to credentials (without hashing or encryption)
* GoodSource: Set data to a hash of credentials
* Sinks:
*    GoodSink: Hash data before storing in cookie
*    BadSink : Store data directly in cookie
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
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
class CWE315_Cleartext_Storage_in_Cookie__Web_06 : AbstractTestCaseWeb
{

    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value. */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PRIVATE_CONST_FIVE==5)
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
        if (PRIVATE_CONST_FIVE==5)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PRIVATE_CONST_FIVE!=5)
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
        if (PRIVATE_CONST_FIVE==5)
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
        if (PRIVATE_CONST_FIVE==5)
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
        if (PRIVATE_CONST_FIVE==5)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PRIVATE_CONST_FIVE==5)
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
        if (PRIVATE_CONST_FIVE!=5)
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
        if (PRIVATE_CONST_FIVE==5)
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
        if (PRIVATE_CONST_FIVE==5)
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
