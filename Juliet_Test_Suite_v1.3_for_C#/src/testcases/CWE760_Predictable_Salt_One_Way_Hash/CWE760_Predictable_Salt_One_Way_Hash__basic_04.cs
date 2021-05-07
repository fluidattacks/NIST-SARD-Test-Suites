/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE760_Predictable_Salt_One_Way_Hash__basic_04.cs
Label Definition File: CWE760_Predictable_Salt_One_Way_Hash__basic.label.xml
Template File: point-flaw-04.tmpl.cs
*/
/*
* @description
* CWE: 760 Use of one-way hash with a predictable salt
* Sinks:
*    GoodSink: SHA512 with a sufficiently random salt
*    BadSink : SHA512 with a predictable salt
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE760_Predictable_Salt_One_Way_Hash
{
class CWE760_Predictable_Salt_One_Way_Hash__basic_04 : AbstractTestCase
{
    /* The two variables below are declared "const", so a tool should
     * be able to identify that reads of these will always return their
     * initialized values.
     */
    private const bool PRIVATE_CONST_TRUE = true;
    private const bool PRIVATE_CONST_FALSE = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_TRUE)
        {
            Random random = new Random();
            byte[] hashedBytes;
            using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
            {
                /* FLAW: SHA512 with a predictable salt */
                byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat("hash me", random.Next().ToString()));
                hashedBytes = sha512.ComputeHash(textWithSaltBytes);
            }
            IO.WriteLine(IO.ToHex(hashedBytes));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void Good1()
    {
        if (PRIVATE_CONST_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            byte[] hashedBytes;
            using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
            {
                using (RNGCryptoServiceProvider random = new RNGCryptoServiceProvider())
                {
                    var salt = new byte[32];
                    /* FIX: Use a sufficiently random salt */
                    random.GetNonZeroBytes(salt);
                    byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat("hash me", salt));
                    hashedBytes = sha512.ComputeHash(textWithSaltBytes);
                }
            }
            IO.WriteLine(IO.ToHex(hashedBytes));
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_TRUE)
        {
            byte[] hashedBytes;
            using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
            {
                using (RNGCryptoServiceProvider random = new RNGCryptoServiceProvider())
                {
                    var salt = new byte[32];
                    /* FIX: Use a sufficiently random salt */
                    random.GetNonZeroBytes(salt);
                    byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat("hash me", salt));
                    hashedBytes = sha512.ComputeHash(textWithSaltBytes);
                }
            }
            IO.WriteLine(IO.ToHex(hashedBytes));
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
