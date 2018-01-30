using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace AIYunNet.CMS.Domain.DataHelper
{
    public class MsSqlDataSource
    {
        private static string connectionString = null;

        public string ConnectionString
        {
            set { connectionString = value; }
        }

        public MsSqlDataSource()
        {
            if (connectionString == null)
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        public MsSqlDataSource(string connectionString)
        {
            MsSqlDataSource.connectionString = connectionString;
        }
        #region Transaction
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public int ExecuteNonQuery(string commandText, SqlConnection connection, SqlTransaction transaction)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null, connection, transaction);
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters, SqlConnection connection, SqlTransaction transaction)
        {
            int rowsAffected = 0;
            using (SqlCommand cmd = new SqlCommand(commandText, connection, transaction))
            {
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }
        #endregion

        #region ExecuteDataTable
        public DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    //command.CommandTimeout = 1800;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }

            return data;
        }
        /// <summary>
        /// 定义输出参数
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        /// <param name="paras">sql参数数组</param>
        /// <param name="par">一个sql参数</param>
        /// <param name="ct">参数类型</param>
        /// <param name="num">数目</param>
        /// <returns>返回一个数据表</returns>
        public DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters, SqlParameter par, out int num)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, connection))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    if (par != null)
                    {
                        cmd.Parameters.Add(par);
                        par.Direction = ParameterDirection.Output;
                    }
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;

                    }
                    finally
                    {
                        connection.Close();
                    }
                    if (par.Value != null)
                    {
                        num = Convert.ToInt32(par.Value);
                    }
                    else
                    {
                        num = 0;
                    }
                }
            }
            return dt;
        }
        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null);
        }
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    command.CommandTimeout = 180000;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    count = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return count;
        }

        #endregion

        #region ExecuteReader
        public SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, CommandType.Text, null);
        }

        public SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }
        public SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);

        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }

        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }

        public object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    //command.CommandTimeout = 18000;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    result = command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
        }

        #endregion

        #region ExecuteNonQueryReturnOutParameterValue
        public int ExecuteNonQueryReturnOutParameterValue(string commandText, CommandType commandType, SqlParameter[] parameters, string outParameterName)
        {
            int value = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    //command.CommandTimeout = 180000;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                    value = int.Parse(command.Parameters[outParameterName].Value.ToString());
                    connection.Close();
                }
            }
            return value;
        }

        #endregion

        #region Others
        public DataTable GetTables()
        {
            DataTable data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                data = connection.GetSchema("Tables");
            }
            return data;
        }

        internal string ListToString(List<int> intList)
        {
            string result = " (";
            if (intList == null || intList.Count == 0)
            {
                result = result + "-1";
            }
            else
            {
                int count = intList.Count;
                for (int i = 0; i < count - 1; i++)
                {
                    result = result + intList[i].ToString() + ",";
                }
                result = result + intList[count - 1].ToString();
            }
            result = result + ")";
            return result;
        }
        #endregion

        #region
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandTimeout = 180000;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
        /// <summary>
        /// 执行存储过程返回数据集ds
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>返回DataSet</returns>
        public static DataTable RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dt);
                connection.Close();
                return dt;
            }
        }
        /// <summary>
        /// 分页获取数据列表根据主键查询所有字段
        /// </summary>
        /// <param name="strtblname">表名</param>
        /// <param name="fldname">主键名称</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="PageIndex">开始索引位置</param>
        /// <param name="isrecout">返回统计的表中总的记录数，如果是0则不返回，1表示返回</param>
        /// <param name="ordertype">正排序，0升序，1降序</param>
        /// <param name="strWhere">查询条件不要带where，默认是"1=1"必须写</param>
        /// <returns></returns>
        public static DataTable GetListPage(string strtblname, string fldname, int PageSize, int PageIndex, int isrecout, int ordertype, string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = strtblname;
            parameters[1].Value = fldname;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = isrecout;
            parameters[5].Value = ordertype;
            parameters[6].Value = strWhere;
            return MsSqlDataSource.RunProcedure("spfront_Common_Pager", parameters, "dt");
        }

        /// <summary>
        /// 通用分页存储过程
        /// </summary>
        /// <param name="queryStr">查询字符串的方法 包含：For：SELECT * FROM 表名</param>
        /// <param name="pageSize">当前页查询的数据条数</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="sortName">排序字段</param>
        /// <param name="sortOrder">排序方式</param>
        /// <param name="recordCount">返回记录总条数</param>
        /// <returns></returns>
        public DataTable ListPager(string queryStr, int pageSize, int pageIndex, string sortOrder, out int recordCount)
        {
            SqlParameter[] parms = new SqlParameter[]{
                        new SqlParameter("@QueryStr",queryStr),
                        new SqlParameter("@PageSize",pageSize),
                        new SqlParameter("@PageCurrent",pageIndex),
                        new SqlParameter("@FdOrder",string.Format("{0}",sortOrder)),
                        new SqlParameter("@Rows",0)
                    };
            parms[4].Direction = ParameterDirection.Output;

            DataTable dt = ExecuteDataTable("sp_Crs_GridPager", CommandType.StoredProcedure, parms);
            recordCount = Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 添加datsset表有参数的，分页控件用
        /// </summary>
        /// <param name="SQLString">sql语句</param>
        /// <param name="startindex">索引位置</param>
        /// <param name="num">大小</param>
        /// <param name="dataname">表名</param>
        /// <returns></returns>
        public DataTable Getdatatable(string SQLString, int startindex, int num, string dataname)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, startindex, num, dataname);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
                finally { connection.Close(); }
                return ds.Tables[0];
            }
        }
        #endregion

        public object ConvertDBNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else {
                return value;
            }
        }
    }
}
