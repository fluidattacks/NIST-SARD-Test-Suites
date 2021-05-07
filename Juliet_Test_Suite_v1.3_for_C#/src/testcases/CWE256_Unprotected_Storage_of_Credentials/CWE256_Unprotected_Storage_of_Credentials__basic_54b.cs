/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE256_Unprotected_Storage_of_Credentials__basic_54b.cs
Label Definition File: CWE256_Unprotected_Storage_of_Credentials__basic.label.xml
Template File: sources-sinks-54b.tmpl.cs
*/
/*
 * @description
 * CWE: 256 Unprotected Storage of Credentials
 * BadSource:  Read password from a .txt file
 * GoodSource: Read password from a .txt file (from the property named password) and then decrypt it
 * Sinks:
 *    GoodSink: Decrypt password and use decrypted password as password to connect to DB
 *    BadSink : Use password as password to connect to DB
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace testcases.CWE256_Unprotected_Storage_of_Credentials
{
class CWE256_Unprotected_Storage_of_Credentials__basic_54b
{
#if (!OMITBAD)
    public static void BadSink(string password )
    {
        CWE256_Unprotected_Storage_of_Credentials__basic_54c.BadSink(password );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string password )
    {
        CWE256_Unprotected_Storage_of_Credentials__basic_54c.GoodG2BSink(password );
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string password )
    {
        CWE256_Unprotected_Storage_of_Credentials__basic_54c.GoodB2GSink(password );
    }
#endif
}
}
