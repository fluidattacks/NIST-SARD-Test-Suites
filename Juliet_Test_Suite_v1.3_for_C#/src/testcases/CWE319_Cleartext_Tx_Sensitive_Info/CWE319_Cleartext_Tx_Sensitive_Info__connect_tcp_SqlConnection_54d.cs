/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__connect_tcp_SqlConnection_54d.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info.label.xml
Template File: sources-sinks-54d.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource: connect_tcp Read password using an outbound tcp connection
 * GoodSource: Set password to a hardcoded value (one that was not sent over the network)
 * Sinks: SqlConnection
 *    GoodSink: Decrypt the password from the source before using it in database connection
 *    BadSink : Use password directly from source in database connection
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__connect_tcp_SqlConnection_54d
{
#if (!OMITBAD)
    public static void BadSink(string password )
    {
        CWE319_Cleartext_Tx_Sensitive_Info__connect_tcp_SqlConnection_54e.BadSink(password );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string password )
    {
        CWE319_Cleartext_Tx_Sensitive_Info__connect_tcp_SqlConnection_54e.GoodG2BSink(password );
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string password )
    {
        CWE319_Cleartext_Tx_Sensitive_Info__connect_tcp_SqlConnection_54e.GoodB2GSink(password );
    }
#endif
}
}
