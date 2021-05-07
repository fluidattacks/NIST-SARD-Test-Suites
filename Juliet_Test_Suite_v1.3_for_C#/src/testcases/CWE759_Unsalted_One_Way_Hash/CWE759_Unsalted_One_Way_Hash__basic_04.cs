/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE759_Unsalted_One_Way_Hash__basic_04.cs
Label Definition File: CWE759_Unsalted_One_Way_Hash__basic.label.xml
Template File: point-flaw-04.tmpl.cs
*/
/*
* @description
* CWE: 759 Use of one-way hash with no salt
* Sinks:
*    GoodSink: use a sufficiently random salt
*    BadSink : SHA512 with no salt
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE759_Unsalted_One_Way_Hash
{
class CWE759_Unsalted_One_Way_Hash__basic_04 : AbstractTestCase
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
            using (HashAlgorithm sha = new SHA512CryptoServiceProvider())
            {
                /* FLAW: SHA512 with no salt */
                byte[] textWithoutSaltBytes = Encoding.UTF8.GetBytes("hash me");
                byte[] hashedBytes = sha.ComputeHash(textWithoutSaltBytes);
                sha.Clear();
                IO.WriteLine(IO.ToHex(hashedBytes));
            }
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
            using (HashAlgorithm sha = new SHA512CryptoServiceProvider())
            {
                /* FIX: Use a sufficiently random salt */
                var salt = new byte[32];
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetNonZeroBytes(salt);
                    byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat("hash me", salt));
                    byte[] hashedBytes = sha.ComputeHash(textWithSaltBytes);
                    sha.Clear();
                    IO.WriteLine(IO.ToHex(hashedBytes));
                }
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PRIVATE_CONST_TRUE)
        {
            using (HashAlgorithm sha = new SHA512CryptoServiceProvider())
            {
                /* FIX: Use a sufficiently random salt */
                var salt = new byte[32];
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetNonZeroBytes(salt);
                    byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat("hash me", salt));
                    byte[] hashedBytes = sha.ComputeHash(textWithSaltBytes);
                    sha.Clear();
                    IO.WriteLine(IO.ToHex(hashedBytes));
                }
            }
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
