/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_45.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource:  Establish data as a password
 * GoodSource: Use a regular string (non-sensitive string)
 * Sinks:
 *    GoodSink: encrypted_channel
 *    BadSink : unencrypted_channel
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.IO;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;

using System.Security;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__send_45 : AbstractTestCase
{

    private string dataBad;
    private string dataGoodG2B;
    private string dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        string data = dataBad;
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

    public override void Bad()
    {
        string data;
        using (SecureString securePwd = new SecureString())
        {
            for (int i = 0; i < "AP@ssw0rd".Length; i++)
            {
                /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                securePwd.AppendChar("AP@ssw0rd"[i]);
            }
            /* POTENTIAL FLAW: Set data to be a password, which can be transmitted over a non-secure
             * channel in the sink */
            data = securePwd.ToString();
        }
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private void GoodG2BSink()
    {
        string data = dataGoodG2B;
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

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string data;
        /* FIX: Use a regular string (non-sensitive string) */
        data = "Hello World";
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        string data = dataGoodB2G;
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

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        string data;
        using (SecureString securePwd = new SecureString())
        {
            for (int i = 0; i < "AP@ssw0rd".Length; i++)
            {
                /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                securePwd.AppendChar("AP@ssw0rd"[i]);
            }
            /* POTENTIAL FLAW: Set data to be a password, which can be transmitted over a non-secure
             * channel in the sink */
            data = securePwd.ToString();
        }
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
