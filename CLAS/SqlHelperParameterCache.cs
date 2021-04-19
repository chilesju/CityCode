namespace CLAS
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;

    public sealed class SqlHelperParameterCache
    {
        static SqlHelperParameterCache()
        {
            SqlHelperParameterCache.paramCache = Hashtable.Synchronized(new Hashtable());
        }

        private SqlHelperParameterCache()
        {
        }

        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            string text1 = connectionString + ":" + commandText;
            SqlHelperParameterCache.paramCache[text1] = commandParameters;
        }

        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] parameterArray1 = new SqlParameter[originalParameters.Length];
            int num1 = 0;
            int num2 = originalParameters.Length;
            while (num1 < num2)
            {
                parameterArray1[num1] = (SqlParameter) ((ICloneable) originalParameters[num1]).Clone();
                num1++;
            }
            return parameterArray1;
        }

        private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            SqlParameter[] parameterArray2;
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                using (SqlCommand command1 = new SqlCommand(spName, connection1))
                {
                    connection1.Open();
                    command1.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(command1);
                    if (!includeReturnValueParameter)
                    {
                        command1.Parameters.RemoveAt(0);
                    }
                    SqlParameter[] parameterArray1 = new SqlParameter[command1.Parameters.Count];
                    command1.Parameters.CopyTo(parameterArray1, 0);
                    parameterArray2 = parameterArray1;
                }
            }
            return parameterArray2;
        }

        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string text1 = connectionString + ":" + commandText;
            SqlParameter[] parameterArray1 = (SqlParameter[]) SqlHelperParameterCache.paramCache[text1];
            if (parameterArray1 == null)
            {
                return null;
            }
            return SqlHelperParameterCache.CloneParameters(parameterArray1);
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return SqlHelperParameterCache.GetSpParameterSet(connectionString, spName, false);
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            string text1 = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            SqlParameter[] parameterArray1 = (SqlParameter[]) SqlHelperParameterCache.paramCache[text1];
            if (parameterArray1 == null)
            {
                object obj1;
                SqlHelperParameterCache.paramCache[text1] = obj1 = SqlHelperParameterCache.DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter);
                parameterArray1 = (SqlParameter[]) obj1;
            }
            return SqlHelperParameterCache.CloneParameters(parameterArray1);
        }


        private static Hashtable paramCache;
    }
}

