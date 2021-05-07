/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE226_Sensitive_Information_Uncleared_Before_Release__basic_08.cs
Label Definition File: CWE226_Sensitive_Information_Uncleared_Before_Release__basic.label.xml
Template File: point-flaw-08.tmpl.cs
*/
/*
* @description
* CWE: 226 Sensitive Information Uncleared Before Release
* Sinks:
*    GoodSink: Sensitive info (password) is stored in a mutable object, but is cleared after use
*    BadSink : Sensitive info (password) is stored in a mutable object and is uncleared
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace testcases.CWE226_Sensitive_Information_Uncleared_Before_Release
{
class CWE226_Sensitive_Information_Uncleared_Before_Release__basic_08 : AbstractTestCase
{
    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false.
     */
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
        if (PrivateReturnsTrue())
        {
            StringBuilder password = new StringBuilder();
            /* read user input from console with readLine */
            try
            {
                using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                {
                    password.Append(sr.ReadLine());
                    using (SqlConnection dBConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = " + password.ToString() + ";"))
                    {
                        dBConnection.Open();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
            /* FLAW: the password is stored in a mutable object (StringBuilder) and it is not cleared */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes PrivateReturnsTrue() to privateReturnsFalse() */
    private void Good1()
    {
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            StringBuilder password = new StringBuilder();
            /* read user input from console with readLine */
            try
            {
                using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                {
                    password.Append(sr.ReadLine());
                    using (SqlConnection dBConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = " + password.ToString() + ";"))
                    {
                        dBConnection.Open();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
            finally
            {
                /* FIX: Zeroize the password */
                password.Remove(0, password.Length);
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (PrivateReturnsTrue())
        {
            StringBuilder password = new StringBuilder();
            /* read user input from console with readLine */
            try
            {
                using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
                {
                    password.Append(sr.ReadLine());
                    using (SqlConnection dBConnection = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = " + password.ToString() + ";"))
                    {
                        dBConnection.Open();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
            finally
            {
                /* FIX: Zeroize the password */
                password.Remove(0, password.Length);
            }
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
