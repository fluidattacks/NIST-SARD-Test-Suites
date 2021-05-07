/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE760_Predictable_Salt_One_Way_Hash__basic_17.cs
Label Definition File: CWE760_Predictable_Salt_One_Way_Hash__basic.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 760 Use of one-way hash with a predictable salt
* Sinks:
*    GoodSink: SHA512 with a sufficiently random salt
*    BadSink : SHA512 with a predictable salt
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE760_Predictable_Salt_One_Way_Hash
{
class CWE760_Predictable_Salt_One_Way_Hash__basic_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        for(int j = 0; j < 1; j++)
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
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1()
    {
        for(int k = 0; k < 1; k++)
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
    }
#endif //omitgood
}
}
