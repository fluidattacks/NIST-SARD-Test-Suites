/*
 * @description Improper Resource Shutdown.  Performs some, but not all, necessary resource cleanup (DB connection is not closed properly).
 * 
 * */

using TestCaseSupport;
using System;
using System.Data.SqlClient;
using System.Data;

namespace testcases.CWE404_Improper_Resource_Shutdown
{

    class CWE404_Improper_Resource_Shutdown__db_Connection_01 : AbstractTestCase
    {
#if (!OMITBAD)
        /* uses badsource and badsink */
        public override void Bad()
        {
            SqlConnection dBConnection = null;
            SqlCommand command = null;

            try
            {
                int intId = (new Random()).Next(200);

                dBConnection = IO.GetDBConnection();
                command = new SqlCommand(null, dBConnection);
                command.CommandText = "select * from users where id=@id";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                idParam.Value = 1;
                command.Prepare();
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows != 0)
                {
                    IO.WriteString(affectedRows.ToString());
                }

                /* FLAW: DB objects are not closed properly. They should be in a finally block. */
                try
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error disposing SqlCommand", exceptSql);
                }

                try
                {
                    if (dBConnection != null)
                    {
                        dBConnection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Connection", exceptSql);
                }

            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "SQL Error", exceptSql);
            }
        }
#endif // OMITBAD
#if (!OMITGOOD)
        public override void Good()
        {
            Good1();
        }

        /* goodG2B() - uses goodsource and badsink */
        private void Good1()
        {
            SqlConnection dBConnection = null;
            SqlCommand command = null;

            try
            {
                int intId = (new Random()).Next(200);

                dBConnection = IO.GetDBConnection();
                command = new SqlCommand(null, dBConnection);
                command.CommandText = "select * from users where id=@id";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                idParam.Value = 1;
                command.Prepare();
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows != 0)
                {
                    IO.WriteString(affectedRows.ToString());
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "SQL Error", exceptSql);
            }
            /* FIX: Close DB objects in a finally block */
            finally
            {
                try
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing SqlCommand", exceptSql);
                }

                try
                {
                    if (dBConnection != null)
                    {
                        dBConnection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Connection", exceptSql);
                }
            }
        }
#endif // OMITGOOD
}
}
