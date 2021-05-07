/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_81_goodB2G.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-81_goodB2G.tmpl.cs
*/
/*
 * @description
 * CWE: 319 Cleartext Transmission of Sensitive Information
 * BadSource:  Establish data as a password
 * GoodSource: Use a regular string (non-sensitive string)
 * Sinks:
 *    GoodSink: encrypted_channel
 *    BadSink : unencrypted_channel
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */
#if (!OMITGOOD)

using TestCaseSupport;
using System;

using System.IO;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;

namespace testcases.CWE319_Cleartext_Tx_Sensitive_Info
{
class CWE319_Cleartext_Tx_Sensitive_Info__send_81_goodB2G : CWE319_Cleartext_Tx_Sensitive_Info__send_81_base
{

    public override void Action(string data )
    {
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
}
}
#endif
