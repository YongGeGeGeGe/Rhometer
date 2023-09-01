/// <summary>
/// 描述：操作日志的数据库读写
/// 作者：杨慧炯
/// 创建日期：2023/6/11 17:52:44
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：
///修改日期：
///修改内容：
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Utils
{
    public class OPerationLog
    {
        #region 数据库SQL语句
        private const string SQL_SELECT_OPERATION_LOG = "SELECT LogID,ExperimentID,LogTime,Record FROM Rheometer_OPerationLog";
        /// <summary>
        /// 按照实验ID查询操作日志数据
        /// </summary>
        private const string SQL_SELECT_OPERATION_LOG_BY_EXPERIMENTID = "SELECT LogID,ExperimentID,LogTime,Record " +
                                                                 "FROM Rheometer_OPerationLog WHERE ExperimentID=@ExperimentID";

        private const string SQL_INSERT_OPERATION_LOG = "INSERT INTO　Rheometer_OPerationLog (ExperimentID,LogTime,Record) Values (@ExperimentID,@LogTime,@Record)";

        /// <summary>
        /// 删除日志表中所有记录 
        /// </summary>
        private const string SQL_DELETE_LOGDATA = "DELETE FROM Rheometer_OPerationLog";
        #endregion

        #region 字段（成员变量）
        int _logID;
        int _experimentID;
        DateTime _logTime;
        string _record;
        #endregion 

        public OPerationLog()
        {
        }
        public OPerationLog(DateTime logTime, string Record)
        {
            _logTime = logTime;
            _record = Record;
        }

        #region 属性
        /// <summary>
        /// 日志ID
        /// </summary>
        public int LogID { get => _logID; set => _logID = value; }
        /// <summary>
        /// 实验ID
        /// </summary>
        public int ExperimentID { get => _experimentID; set => _experimentID = value; }
        /// <summary>
        /// 记录日志时间
        /// </summary>
        public DateTime LogTime { get => _logTime; set => _logTime = value; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Record { get => _record; set => _record = value; }
        #endregion

        #region 查询所有日志数据
        /// <summary>
        /// 查询所有日志数据
        /// </summary>
        /// <returns></returns>
        public IList<OPerationLog> GetLogs()
        {
            IList<OPerationLog> IOPerationLogS = new List<OPerationLog>();
            //从数据库中查询所有日志数据并赋值给IOPerationLogS
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_OPERATION_LOG))
            {
                while (reader.Read())//读取查询结果
                {
                    //构造ErrorData对象
                    OPerationLog OperationLog = new OPerationLog
                    {
                        LogID = Convert.ToInt32(reader["LogID"].ToString()),
                        ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString()),
                        LogTime = Convert.ToDateTime(reader["LogTime"].ToString()),
                        Record = Convert.ToString(reader["Record"].ToString())
                    };
                    //将reader读出并构造的查询结果添加到List中
                    IOPerationLogS.Add(OperationLog);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return IOPerationLogS;
        }
        #endregion

        #region 按照实验ID查询日志数据
        /// <summary>
        /// 按照实验ID查询日志数据
        /// </summary>
        /// <param name="ExperimentID">实验ID</param>
        /// <returns>日志数据列表</returns>
        public IList<OPerationLog> GetLogs(int experimentID)
        {
            IList<OPerationLog> IOperationLogS = new List<OPerationLog>();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                    new OleDbParameter("@ExperimentID",OleDbType.Integer)
            };
            parms[0].Value = experimentID;
            //从数据库中查询日志数据并赋值给IOperationLogS
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_OPERATION_LOG_BY_EXPERIMENTID, parms))
            {
                while (reader.Read())//读取查询结果
                {
                    //构造OperationLog对象
                    OPerationLog OperationLog = new OPerationLog
                    {
                        LogID = Convert.ToInt32(reader["LogID"].ToString()),
                        ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString()),
                        LogTime = Convert.ToDateTime(reader["LogTime"].ToString()),
                        Record = Convert.ToString(reader["Record"].ToString())
                    };
                    //将reader读出并构造的查询结果添加到List中
                    IOperationLogS.Add(OperationLog);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return IOperationLogS;
        }
        #endregion

        #region 添加日志数据
        /// <summary>
        /// 添加日志记录数据
        /// </summary>
        /// <param name="operationLog"></param>
        /// <returns>成功失败</returns>
        public bool AddLog(OPerationLog operationLog)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentID", OleDbType.Integer),
                new OleDbParameter("@LogTime", OleDbType.VarChar, 255),
                new OleDbParameter("@Record", OleDbType.LongVarChar)
            };
            parms[0].Value = operationLog.ExperimentID;
            parms[1].Value = operationLog.LogTime.ToString();
            parms[2].Value = operationLog.Record;
            if (DbHelperAccess.ExecuteSql(SQL_INSERT_OPERATION_LOG, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 删除表中所有日志记录

        public int DeleteData()
        {
            return DbHelperAccess.ExecuteSql(SQL_DELETE_LOGDATA);
        }

        #endregion        
    }
}
