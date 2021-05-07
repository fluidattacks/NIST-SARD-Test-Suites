/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_71b.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-71b.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource:  Establish data as a password
 * GoodSource: Use a regular string (non-sensitive string)
 * Sinks:
 *    GoodSink: encrypted_channel
 *    BadSink : unencrypted_channel
 * Flow Variant: 71 Data flow: data passed as an Object reference argument from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;

using System;

using System.IO;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__send_71b
{
#if (!OMITBAD)
    public static void BadSink(Object dataObject )
    {
        string data = (string)dataObject;
        try
        {
            using (TcpClient tcpClient = new TcpClient("remote_host", 1337))
            {
                using (StreamWriter writer = new StreamWriter(tcpClient.GetStream()))
                {
                    /* POTENTIAL FLAW: sending data over an unencrypted (non-SSL) channel */
                    writer.WriteLine(data);
                }
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(Object dataObject )
    {
        string data = (string)dataObject;
        try
        {
            using (TcpClient tcpClient = new TcpClient("remote_host", 1337))
            {
                using (StreamWriter writer = new StreamWriter(tcpClient.GetStream()))
                {
                    /* POTENTIAL FLAW: sending data over an unencrypted (non-SSL) channel */
                    writer.WriteLine(data);
                }
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(Object dataObject )
    {
        string data = (string)dataObject;
        try
        {
            using (TcpClient client = new TcpClient("remote_host", 1337))
            {
                using (SslStream sslStream = new SslStream(client.GetStream()))
                {
                    /* FIX: sending data over an SSL encrypted channel */
                    sslStream.Write(Encoding.UTF8.GetBytes(data));
                }
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error writing to the TcpClient", exceptIO);
        }
    }
#endif
}
}
