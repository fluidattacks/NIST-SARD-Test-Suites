/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE328_Reversible_One_Way_Hash__SHA1_17.cs
Label Definition File: CWE328_Reversible_One_Way_Hash.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 328 Reversible One Way Hash
* Sinks: SHA1
*    GoodSink: SHA512
*    BadSink : SHA1
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE328_Reversible_One_Way_Hash
{
class CWE328_Reversible_One_Way_Hash__SHA1_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        for(int j = 0; j < 1; j++)
        {
            using (HashAlgorithm sha1 = new SHA1CryptoServiceProvider())
            {
                /* FLAW: Insecure cryptographic hashing algorithm (SHA1) */
                byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
                byte[] textWithReversibleHash = sha1.ComputeHash(textWithUTF8);
                IO.WriteLine(IO.ToHex(textWithReversibleHash));
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1()
    {
        for(int k = 0; k < 1; k++)
        {
            using (HashAlgorithm sha512 = new SHA512CryptoServiceProvider())
            {
                /* FIX: Secure cryptographic hashing algorithm (SHA-512) */
                byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
                byte[] textWithReversibleHash = sha512.ComputeHash(textWithUTF8);
                IO.WriteLine(IO.ToHex(textWithReversibleHash));
            }
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
