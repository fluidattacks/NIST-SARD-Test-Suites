/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_22b.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-22b.tmpl.cs
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

namespace testcases.CWE315_Cleartext_Storage_in_Cookie
{
class CWE315_Cleartext_Storage_in_Cookie__Web_22b
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE315_Cleartext_Storage_in_Cookie__Web_22a.badPublicStatic)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE315_Cleartext_Storage_in_Cookie__Web_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
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

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE315_Cleartext_Storage_in_Cookie__Web_22a.goodB2G2PublicStatic)
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
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE315_Cleartext_Storage_in_Cookie__Web_22a.goodG2BPublicStatic)
        {
            /* NOTE: potential incidental issues with not setting secure or HttpOnly flag */
            /* POTENTIAL FLAW: Store data directly in cookie */
            resp.AppendCookie(new HttpCookie("auth", data));
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif
}
}
