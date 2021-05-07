/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE506_Embedded_Malicious_Code__file_transfer_listen_tcp_15.cs
Label Definition File: CWE506_Embedded_Malicious_Code.badonly.label.xml
Template File: point-flaw-badonly-15.tmpl.cs
*/
/*
* @description
* CWE: 506 Embedded Malicious Code
* Sinks: file_transfer_listen_tcp
*    BadSink : Send file contents over the network using a listening tcp connection
*    BadOnly (No GoodSink)
* Flow Variant: 15 Control flow: switch(7)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net.Sockets;
using System.Net;

namespace testcases.CWE506_Embedded_Malicious_Code
{
class CWE506_Embedded_Malicious_Code__file_transfer_listen_tcp_15 : AbstractTestCaseBadOnly
{
#if (!OMITBAD)
    public override void Bad()
    {
        switch (7)
        {
        case 7:
            string path = @"MyTest.txt";
            File.Create(path).Close();
            string contents = "";
            try
            {
                /* read string from file */
                using (StreamReader sr = new StreamReader(path))
                {
                    /* This will be reading the first "line" of the file, which
                     * could be very long if there are little or no newlines in the file */
                    contents = sr.ReadLine();
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
            TcpListener listener = null;
            TcpClient tcpConn = null;
            try
            {
                /* send file contents using socket */
                listener = new TcpListener(IPAddress.Parse("10.10.1.10"), 39543);
                tcpConn = listener.AcceptTcpClient();
                using (StreamWriter sw = new StreamWriter(tcpConn.GetStream()))
                {
                    /* FLAW: Send file contents over the network */
                    if (contents != null)
                    {
                        sw.Write(contents);
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream writing");
            }
            finally
            {
                /* clean up socket objects */
                try
                {
                    if (tcpConn != null)
                    {
                        tcpConn.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing Socket");
                }

                try
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing ServerSocket");
                }
            }
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
}
}
