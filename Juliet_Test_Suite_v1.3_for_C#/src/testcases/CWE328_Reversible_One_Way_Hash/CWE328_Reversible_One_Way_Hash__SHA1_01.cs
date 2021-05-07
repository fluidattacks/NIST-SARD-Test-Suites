/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE328_Reversible_One_Way_Hash__SHA1_01.cs
Label Definition File: CWE328_Reversible_One_Way_Hash.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 328 Reversible One Way Hash
* Sinks: SHA1
*    GoodSink: SHA512
*    BadSink : SHA1
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Text;
using System.Security.Cryptography;

namespace testcases.CWE328_Reversible_One_Way_Hash
{
class CWE328_Reversible_One_Way_Hash__SHA1_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        using (HashAlgorithm sha1 = new SHA1CryptoServiceProvider())
        {
            /* FLAW: Insecure cryptographic hashing algorithm (SHA1) */
            byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
            byte[] textWithReversibleHash = sha1.ComputeHash(textWithUTF8);
            IO.WriteLine(IO.ToHex(textWithReversibleHash));
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        using (HashAlgorithm sha512 = new SHA512CryptoServiceProvider())
        {
            /* FIX: Secure cryptographic hashing algorithm (SHA-512) */
            byte[] textWithUTF8 = Encoding.UTF8.GetBytes("Test Input"); /* INCIDENTAL FLAW: Hard-coded input to hash algorithm */
            byte[] textWithReversibleHash = sha512.ComputeHash(textWithUTF8);
            IO.WriteLine(IO.ToHex(textWithReversibleHash));
        }
    }
#endif //omitgood
}
}
