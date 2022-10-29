
using System;
//引用类
using System.Data;
using System.Data.SQLite;
using System.ComponentModel;
using System.IO;

namespace NTDCommon
{
    public class SQLiteDataBase : IDisposable
    {
        private string _dbFile;
        public string DbFile { get { return _dbFile; } set { _dbFile = value; } }

        private string _dbPassword;
        public string DbPassword { get { return _dbPassword; } set { _dbPassword = value; } }      // encrypted database may be not supported by other client

        private int _dbVersion = 3;
        public int DbVersion { get { return _dbVersion; } set { _dbVersion = value; } }

        private bool _pooling = true;
        public bool Pooling { get { return _pooling; } set { _pooling = value; } }

        private bool _failIfMissing = false;
        public bool FailIfMissing { get { return _failIfMissing; } set { _failIfMissing = value; } }

        private bool _useUTF16Encoding = false;
        public bool UseUTF16Encoding { get { return _useUTF16Encoding; } set { _useUTF16Encoding = value; } }

        private bool _readOnly = false;
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } } 


        private SQLiteConnection con;  //创建连接对象

#region   打开数据库连接
        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        public void Open()
        {
            // Data Source=filename;Version=3;Password=myPassword;UseUTF16Encoding=True;
            string connectStr;  //数据库连接信息
            connectStr = "Data Source=" + DbFile + ";"
                       + "Version=" + DbVersion + ";"
                       + (string.IsNullOrEmpty(DbPassword) ? "" : "Password=" + DbPassword + ";")
                       + "Pooling=" + (Pooling ? "True" : "False") + ";"
                       + "FailIfMissing=" + (FailIfMissing ? "True" : "False") + ";"
                       + (UseUTF16Encoding ? "UseUTF16Encoding=True;" : "")
                       + (ReadOnly ? "Read Only=True;" : "")
                       ;

            if (con == null)//判断连接对象是否为空
            {
                con = new SQLiteConnection(connectStr);//创建数据库连接对象
            }
            if (con.State == ConnectionState.Closed) //判断数据库连接是否关闭
                con.Open();//打开数据库连接
            if (con.State == ConnectionState.Broken) //判断数据库连接是否断开
            {
                con.Close();
                con.Open();
            }
        }
        /// 打开数据库连接.
        public void Open(string fileName, string password)
        {
          

            // 判断文件是否存在，不存在则创建
            if (!File.Exists(fileName))
            {
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                //File.WriteAllText(pathname, null);
                File.Create(fileName).Dispose();//创建完文件关闭，防止文件被占用;
                throw new Exception("数据库文件不存在，请将数据库文件拷贝到指定文件夹下。");
            }
            DbFile = fileName;
            DbPassword = password;
            Open();
        }
#endregion

#region  关闭连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if( con != null) con.Close();
        }
#endregion

#region 释放数据库连接资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if(con != null)
            {
                con.Dispose();//释放数据库连接资源
                con = null;//设置数据库连接为空
            }
            
        }
#endregion

#region   传入参数并且转换为mySqlParameter类型
        public static SQLiteParameter MakeInParam(string name, DbType type, object val)
        {
            return new SQLiteParameter(name, type) { Direction = ParameterDirection.Input, Value = val, };
        }

        public static SQLiteParameter MakeOutParam(string name, DbType type, int size)
        {
            return new SQLiteParameter(name, type, size) { Direction = ParameterDirection.Output, };
        }

        public static SQLiteParameter MakeReturnParam(string name, DbType type, int size)
        {
            return new SQLiteParameter(name, type, size) { Direction = ParameterDirection.ReturnValue, };
        }

        /// <summary>
        /// 初始化参数值
        /// </summary>
        /// <param name="ParamName">存储过程名称或命令文本</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SQLiteParameter MakeParam(string ParamName, DbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SQLiteParameter param;//声明SQL参数对象
            if (Size > 0)//判断参数字段是否大于0
                param = new SQLiteParameter(ParamName, DbType, Size);//根据指定的类型和大小创建SQL参数
            else
                param = new SQLiteParameter(ParamName, DbType);//根据指定的类型创建SQL参数
            param.Direction = Direction;//设置SQL参数的类型
            if (!(Direction == ParameterDirection.Output && Value == null))//判断是否为输出参数
                param.Value = Value;//设置参数返回值
            return param;//返回SQL参数
        }
#endregion

#region   执行参数命令文本(无数据库中数据返回)
        /// <summary>
        /// 执行命令
        /// </summary>
        public int RunProc(string proc, SQLiteParameter[] prams)
        {
            SQLiteCommand cmd = CreateCommand(proc, prams);
            return cmd.ExecuteNonQuery();
        }
        public int RunProc(string proc)
        {
            return RunProc(proc, null);
        }

        public int InsertProc(string proc, SQLiteParameter[] prams)
        {
            proc += " Select LAST_INSERT_ROWID();";
            var dt = QueryTable(proc, prams);
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

#endregion

#region 查询数据表
        public DataTable QueryTable(string proc)
        {
            return QueryTable(proc, null);
        }
        public DataTable QueryTable(string proc, SQLiteParameter[] prams)
        {
            SQLiteDataAdapter dap = CreateDataAdapter(proc, prams);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        public DataSet QuerySet(string proc)
        {
            return QuerySet(proc, null);
        }
        public DataSet QuerySet(string proc, SQLiteParameter[] prams)
        {
            SQLiteDataAdapter dap = CreateDataAdapter(proc, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }

#endregion

#region   将命令文本添加到SqlCommand
        /// <summary>
        /// 创建一个SqlCommand对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams"命令文本所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private SQLiteCommand CreateCommand(string procName, SQLiteParameter[] prams)
        {
            SQLiteCommand cmd = new SQLiteCommand(procName, con);//创建SqlCommand命令对象
            cmd.CommandType = CommandType.Text;//指定要执行的类型为命令文本
            // 依次把参数传入命令文本
            if (prams != null)//判断SQL参数是否不为空
                cmd.Parameters.AddRange(prams);
            return cmd;//返回SqlCommand命令对象
        }
#endregion

#region 将命令文本添加到SqlDataAdapter
        /// <summary>
        /// 创建一个SqlDataAdapter对象以此来执行命令文本
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="prams">参数对象</param>
        /// <returns></returns>
        private SQLiteDataAdapter CreateDataAdapter(string procName, SQLiteParameter[] prams)
        {
            SQLiteDataAdapter dap = new SQLiteDataAdapter(procName, con);//创建桥接器对象
            dap.SelectCommand.CommandType = CommandType.Text;//指定要执行的类型为命令文本
            if (prams != null)//判断SQL参数是否不为空
            {
                foreach (var parameter in prams)//遍历传递的每个SQL参数
                    dap.SelectCommand.Parameters.Add(parameter);//将SQL参数添加到执行命令对象中
            }
            ////加入返回参数
            //dap.SelectCommand.Parameters.Add(new SQLiteParameter("ReturnValue", DbType.Int32, 4,
            //    ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return dap;//返回桥接器对象
        }
        #endregion

        [DefaultValue("t_system")]
        public string SystemTableName { get; set; }
        public string SystemTableCreate
        {
            get
            {
                return "create table if not exists " + SystemTableName + " (f_name primary key not null, f_value, f_updateTime);";
            }
        }

        public int GetDbVersion()
        {
            
            RunProc(SystemTableCreate);
            var dt = QueryTable("select * from " + SystemTableName + " where f_name='version';");
            if (dt.Rows.Count > 0 && dt != null)
            {
                int version;
                string value = dt.Rows[0].Field<string>("f_value");

                try
                {
                   version = int.Parse(value);
                }
                catch
                {
                    version = 0;
 
                }
                return version;
            }
            return -1;
        }

        public void SetDbVersion(int version)
        {
            RunProc(SystemTableCreate);
            RunProc("replace into " + SystemTableName + "(f_name, f_value, f_updateTime) values('version', '" + version + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');");
        }

    }
}


