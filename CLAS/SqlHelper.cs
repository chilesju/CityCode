namespace CLAS
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public sealed class SqlHelper
    {
        private SqlHelper()
        {
        }

        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters != null) && (parameterValues != null))
            {
                if (commandParameters.Length != parameterValues.Length)
                {
                    throw new ArgumentException("Parameter count does not match Parameter Value count.");
                }
                int num1 = 0;
                int num2 = commandParameters.Length;
                while (num1 < num2)
                {
                    commandParameters[num1].Value = parameterValues[num1];
                    num1++;
                }
            }
        }

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter parameter1 in commandParameters)
            {
                if ((parameter1.Direction == ParameterDirection.InputOutput) && (parameter1.Value == null))
                {
                    parameter1.Value = DBNull.Value;
                }
                command.Parameters.Add(parameter1);
            }
        }

        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] parameterArray1 = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                SqlHelper.AssignParameterValues(parameterArray1, parameterValues);
                return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, parameterArray1);
            }
            return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, new SqlParameter[0]);
        }

        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command1 = new SqlCommand();
            SqlHelper.PrepareCommand(command1, connection, null, commandType, commandText, commandParameters);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataSet set1 = new DataSet();
            adapter1.Fill(set1);
            command1.Parameters.Clear();
            return set1;
        }

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                connection1.Open();
                return SqlHelper.ExecuteDataset(connection1, commandType, commandText, commandParameters);
            }
        }

        public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] parameterArray1 = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                SqlHelper.AssignParameterValues(parameterArray1, parameterValues);
                return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, parameterArray1);
            }
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, new SqlParameter[0]);
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command1 = new SqlCommand();
            SqlHelper.PrepareCommand(command1, connection, null, commandType, commandText, commandParameters);
            int num1 = command1.ExecuteNonQuery();
            command1.Parameters.Clear();
            return num1;
        }

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                connection1.Open();
                return SqlHelper.ExecuteNonQuery(connection1, commandType, commandText, commandParameters);
            }
        }

        public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] parameterArray1 = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                SqlHelper.AssignParameterValues(parameterArray1, parameterValues);
                return SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, parameterArray1);
            }
            return SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, new SqlParameter[0]);
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command1 = new SqlCommand();
            SqlHelper.PrepareCommand(command1, connection, null, commandType, commandText, commandParameters);
            object obj1 = command1.ExecuteScalar();
            command1.Parameters.Clear();
            return obj1;
        }

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                connection1.Open();
                return SqlHelper.ExecuteScalar(connection1, commandType, commandText, commandParameters);
            }
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.Connection = connection;
            command.CommandText = commandText;
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                SqlHelper.AttachParameters(command, commandParameters);
            }
        }

    }
}

