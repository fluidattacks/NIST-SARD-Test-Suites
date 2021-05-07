/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE319_Cleartext_Tx_Sensitive_Info__send_08.cs
Label Definition File: CWE319_Cleartext_Tx_Sensitive_Info__send.label.xml
Template File: sources-sinks-08.tmpl.cs
*/
/*
* @description
* CWE: 319 Cleartext Transmission of Sensitive Information
* BadSource:  Establish data as a password
* GoodSource: Use a regular string (non-sensitive string)
* Sinks:
*    GoodSink: encrypted_channel
*    BadSink : unencrypted_channel
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
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
class CWE319_Cleartext_Tx_Sensitive_Info__send_08 : AbstractTestCase
{

    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false. */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
        {
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodG2B1()
    {
        string data;
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a regular string (non-sensitive string) */
            data = "Hello World";
        }
        if (PrivateReturnsTrue())
        {
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
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2()
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* FIX: Use a regular string (non-sensitive string) */
            data = "Hello World";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
        {
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
    }

    /* goodB2G1() - use badsource and goodsink by changing second PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodB2G1()
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
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

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2()
    {
        string data;
        if (PrivateReturnsTrue())
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
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

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
