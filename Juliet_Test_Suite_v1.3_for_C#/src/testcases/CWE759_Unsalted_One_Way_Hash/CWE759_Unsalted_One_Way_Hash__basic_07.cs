/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE759_Unsalted_One_Way_Hash__basic_07.cs
Label Definition File: CWE759_Unsalted_One_Way_Hash__basic.label.xml
Template File: point-flaw-07.tmpl.cs
*/
/*
* @description
* CWE: 759 Use of one-way hash with no salt
* Sinks:
*    GoodSink: use a sufficiently random salt
*    BadSink : SHA512 with no salt
* Flow Variant: 07 Control flow: if(privateFive==5) and if(privateFive!=5)
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE759_Unsalted_One_Way_Hash
{
class CWE759_Unsalted_One_Way_Hash__basic_07 : AbstractTestCase
{
    /* The variable below is not declared "readonly", but is never assigned
     * any other value so a tool should be able to identify that reads of
     * this will always give its initialized value.
     */
    private int privateFive = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateFive == 5)
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
    /* Good1() changes privateFive==5 to privateFive!=5 */
    private void Good1()
    {
        if (privateFive != 5)
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
        if (privateFive == 5)
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
