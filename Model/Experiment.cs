/// <summary>
/// 描述：实验类，用来对实验参数进行维护（新建实验、实验参数维护、查询实验、更新实验是否正在进行状态）
/// 作者：杨慧炯
/// 创建日期：2023/6/23 10:00:51
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
using static Rheometer_Torque.Machine.Machine;
using Utils.Utils;

namespace Rheometer_Torque.Model
{
    public class Experiment
    {
        #region 数据库操作SQL语句
        private const string SQL_SELECT_EXPERIMENT_BY_ID = "SELECT ExperimentID,ExperimentName,ExperimentTime," +
                                                          "UserName,SampleName,SampleDensity,ExperimentTemperature," +
                                                          "CapillaryDiameter,CapillaryLength,TorqueThreshold,PressureThreshold," +
                                                          "TemperatureThreshold,MainMotorSpeedThreshold,ExperimentStageNumber,IsRuning" +
                                                          " FROM Rheomoter_ExperimentParameter WHERE ExperimentID=@ExperimentID";        

        private const string SQL_SELECT_LASTEXPERIMENT = "SELECT TOP 1 ExperimentID,ExperimentName,ExperimentTime," +
                                                          "UserName,SampleName,SampleDensity,ExperimentTemperature," +
                                                          "CapillaryDiameter,CapillaryLength,TorqueThreshold,PressureThreshold," +
                                                          "TemperatureThreshold,MainMotorSpeedThreshold,ExperimentStageNumber,IsRuning" +
                                                          " FROM Rheomoter_ExperimentParameter ORDER BY ExperimentID DESC";

        private const string SQL_SELECT_EXPERIMENTS_BY_RUNNINGSTATE = "SELECT ExperimentID,ExperimentName,ExperimentTime," +
                                                               "UserName,SampleName,SampleDensity,ExperimentTemperature,"+
                                                               "CapillaryDiameter,CapillaryLength,TorqueThreshold,PressureThreshold," +
                                                               "TemperatureThreshold,MainMotorSpeedThreshold,ExperimentStageNumber,IsRuning" +
                                                               " FROM Rheomoter_ExperimentParameter" +
                                                               " WHERE IsRuning=@IsRuning ORDER BY ExperimentID DESC";

        private const string SQL_SELECT_RUNNINGEXPERIMENT = "SELECT ExperimentID,ExperimentName,ExperimentTime," +
                                                          "UserName,SampleName,SampleDensity,ExperimentTemperature," +
                                                          "CapillaryDiameter,CapillaryLength,TorqueThreshold,PressureThreshold," +
                                                          "TemperatureThreshold,MainMotorSpeedThreshold,ExperimentStageNumber,IsRuning" +
                                                          " FROM Rheomoter_ExperimentParameter WHERE IsRuning=true";

        private const string SQL_INSERT_NEWEXPERIMENT = "INSERT INTO Rheomoter_ExperimentParameter(ExperimentName,ExperimentTime," +
                                                        "UserName,SampleName,SampleDensity,ExperimentTemperature,PressureThreshold,"+
                                                        "CapillaryDiameter,CapillaryLength,TorqueThreshold,"+
                                                        "TemperatureThreshold,MainMotorSpeedThreshold,ExperimentStageNumber,IsRuning)"+
                                                        " VALUES(@ExperimentName,@ExperimentTime,@UserName,@SampleName,@SampleDensity," +
                                                      "@ExperimentTemperature,@PressureThreshold,@CapillaryDiameter,@CapillaryLength,@TorqueThreshold," +
                                                      "@TemperatureThreshold,@MainMotorSpeedThreshold,@ExperimentStageNumber,true,)";
        
        private const string SQL_UPDATA_PARAMETER = "UPDATE Rheomoter_ExperimentParameter  SET  ExperimentName = @ExperimentName," +
                                                    "ExperimentTime = @ExperimentTime,SampleName=@SampleName,SampleDensity=@SampleDensity," +
                                                    "ExperimentTemperature=@ExperimentTemperature,PressureThreshold=@PressureThreshold,"+
                                                    "CapillaryDiameter=@CapillaryDiameter,CapillaryLength=@CapillaryLength,TorqueThreshold=@TorqueThreshold," +
                                                    "TemperatureThreshold=@TemperatureThreshold,MainMotorSpeedThreshold=@MainMotorSpeedThreshold," +
                                                    "ExperimentStageNumber=@ExperimentStageNumber" +
                                                    " WHERE ExperimentID=@ExperimentID";

        private const string SQL_UPDATA_RUNINGSTATE = "UPDATE  Rheomoter_ExperimentParameter  SET  IsRuning = @IsRuning" +
                                                      " WHERE ExperimentID=@ExperimentID";
        #endregion

        #region 字段(成员变量)
        int _experimentID;
        string _experimentName;
        DateTime _experimentTime;
        User _user;
        string _sampleName;
        float _sampleDensity;
        float _experimentTemperature;
        float _capillaryDiameter;
        float _capillaryLength;
        float _torqueThreshold;
        float _pressureThreshold;
        float _temperatureThreshold;
        int _mainMotorSpeedThreshold;
        int _experimentStageNumber;
        bool _isRuning;
        List<ExperimentStage> _stageList;
        #endregion

        #region 属性
        /// <summary>
        /// 实验ID
        /// </summary>
        public int ExperimentID { get => _experimentID; set => _experimentID = value; }
        /// <summary>
        /// 实验名称
        /// </summary>
        public string ExperimentName { get => _experimentName; set => _experimentName = value; }
        /// <summary>
        /// 实验时间
        /// </summary>
        public DateTime ExperimentTime { get => _experimentTime; set => _experimentTime = value; }
        /// <summary>
        /// 操作者
        /// </summary>
        public User User { get => _user; set => _user = value; }
        /// <summary>
        /// 样品名
        /// </summary>
        public string SampleName { get => _sampleName; set => _sampleName = value; }
        /// <summary>
        /// 样品密度
        /// </summary>
        public float SampleDensity { get => _sampleDensity; set => _sampleDensity = value; }
        /// <summary>
        /// 实验温度
        /// </summary>
        public float ExperimentTemperature { get => _experimentTemperature; set => _experimentTemperature = value; }
       /// <summary>
       /// 毛细管直径
       /// </summary>
        public float CapillaryDiameter { get => _capillaryDiameter; set => _capillaryDiameter = value; }
        /// <summary>
        /// 毛细管长度
        /// </summary>
        public float CapillaryLength { get => _capillaryLength; set => _capillaryLength = value; }
        /// <summary>
        /// 扭矩安全值
        /// </summary>
        public float TorqueThreshold { get => _torqueThreshold; set => _torqueThreshold = value; }
        /// <summary>
        /// 压力安全值
        /// </summary>
        public float PressureThreshold { get => _pressureThreshold; set => _pressureThreshold = value; }
        /// <summary>
        /// 温度安全值
        /// </summary>
        public float TemperatureThreshold { get => _temperatureThreshold; set => _temperatureThreshold = value; }
        /// <summary>
        /// 主电机转速安全值
        /// </summary>
        public int MainMotorSpeedThreshold { get => _mainMotorSpeedThreshold; set => _mainMotorSpeedThreshold = value; }
        /// <summary>
        /// 实验阶段数
        /// </summary>
        public int ExperimentStageNumber { get => _experimentStageNumber; set => _experimentStageNumber = value; }
        /// <summary>
        /// 是否正在进行
        /// </summary>
        public bool IsRuning { get => _isRuning; set => _isRuning = value; }
        /// <summary>
        /// 实验阶段列表（存储每个实验阶段相关参数）
        /// </summary>
        public List<ExperimentStage> StageList { get => _stageList; set => _stageList = value; }
        #endregion

        #region 根据实验ID查询实验参数(包括各实验阶段参数)
        /// <summary>
        /// 根据实验ID 查询实验参数(包括各实验阶段参数)
        /// </summary>
        /// <param name="experimentID">实验ID</param>
        /// <returns>查询结果</returns>
        public Experiment GetExperiment(int experimentID)
        {
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentID",OleDbType.Integer)
            };
            parms[0].Value = experimentID;
            //从数据库中查询实验参数并赋值给相关属性
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_EXPERIMENT_BY_ID, parms))
            {
                while (reader.Read()) //读查询结果
                {
                    //构造恒温实验参数对象                    
                    ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString());
                    User = new User();                    
                    ExperimentName = reader["ExperimentName"].ToString();
                    ExperimentTime = Convert.ToDateTime(reader["ExperimentTime"].ToString());
                    User.UserName = reader["UserName"].ToString();                    
                    SampleName = reader["SampleName"].ToString();
                    SampleDensity = Convert.ToSingle(reader["SampleDensity"].ToString());
                    ExperimentTemperature = Convert.ToSingle(reader["ExperimentTemperature"].ToString());
                    CapillaryDiameter = Convert.ToSingle(reader["CapillaryDiameter"].ToString());
                    CapillaryLength = Convert.ToSingle(reader["CapillaryLength"].ToString());
                    TorqueThreshold = Convert.ToSingle(reader["TorqueThreshold"].ToString());
                    PressureThreshold = Convert.ToSingle(reader["PressureThreshold"].ToString());
                    TemperatureThreshold = Convert.ToSingle(reader["TemperatureThreshold"].ToString());
                    MainMotorSpeedThreshold = Convert.ToInt32(reader["MainMotorSpeedThreshold"].ToString());
                    ExperimentStageNumber = Convert.ToInt32(reader["ExperimentStageNumber"].ToString());
                    IsRuning = Convert.ToBoolean(reader["IsRuning"].ToString());
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            //从数据库中查询各个实验阶段参数并赋值给实验阶段列表属性            
            ExperimentStage stage = new ExperimentStage(this._experimentID);
            this.StageList = stage.GetStageList(this.ExperimentID);
            return this;
        }
        #endregion

        #region 从数据库中查询最近一次实验的相关参数信息(包括各实验阶段参数)
        /// <summary>
        /// 从数据库中查询最近一次实验的相关参数信息(包括各实验阶段参数)
        /// </summary>
        /// <returns>恒温实验参数</returns>
        public Experiment GetLastExperiment()
        {                          
            //从数据库中查询最近一次实验的实验参数并赋值给parameter
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_LASTEXPERIMENT))
            {
                while (reader.Read()) //读查询结果
                {
                    //构造恒温实验参数对象                    
                    ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString());
                    User = new User();
                    ExperimentName = reader["ExperimentName"].ToString();
                    ExperimentTime = Convert.ToDateTime(reader["ExperimentTime"].ToString());
                    User.UserName = reader["UserName"].ToString();
                    SampleName = reader["SampleName"].ToString();
                    SampleDensity = Convert.ToSingle(reader["SampleDensity"].ToString());
                    ExperimentTemperature = Convert.ToSingle(reader["ExperimentTemperature"].ToString());
                    CapillaryDiameter = Convert.ToSingle(reader["CapillaryDiameter"].ToString());
                    CapillaryLength = Convert.ToSingle(reader["CapillaryLength"].ToString());
                    TorqueThreshold = Convert.ToSingle(reader["TorqueThreshold"].ToString());
                    PressureThreshold = Convert.ToSingle(reader["PressureThreshold"].ToString());
                    TemperatureThreshold = Convert.ToSingle(reader["TemperatureThreshold"].ToString());
                    MainMotorSpeedThreshold = Convert.ToInt32(reader["MainMotorSpeedThreshold"].ToString());
                    ExperimentStageNumber = Convert.ToInt32(reader["ExperimentStageNumber"].ToString());
                    IsRuning = Convert.ToBoolean(reader["IsRuning"].ToString());
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            //从数据库中查询各个实验阶段参数并赋值给实验阶段列表属性            
            ExperimentStage stage = new ExperimentStage(this._experimentID);
            this.StageList = stage.GetStageList(this.ExperimentID);
            return this;
        }
        #endregion

        #region 根据运行状态查询相关实验列表(包括各实验阶段参数)
        /// <summary>
        /// 根据运行状态查询相关实验列表(包括各实验阶段参数)
        /// </summary>
        /// <param name="isRuning">运行状态</param>
        /// <returns>符合条件的实验列表</returns>
        public List<Experiment> GetParameter(bool isRuning)
        {
            List<Experiment> experiments = new List<Experiment>();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {                    
                new OleDbParameter("@IsRuning",OleDbType.Boolean)
            };           
            parms[0].Value = isRuning;
            //从数据库中查询所有满足条件的实验参数并赋值给
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_EXPERIMENTS_BY_RUNNINGSTATE, parms))
            {
                while (reader.Read()) //读查询结果
                {
                    Experiment experiment = new Experiment();
                    //构造恒温实验参数对象                    
                    experiment.ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString());
                    experiment.User = new User();
                    experiment.ExperimentName = reader["ExperimentName"].ToString();
                    experiment.ExperimentTime = Convert.ToDateTime(reader["ExperimentTime"].ToString());
                    experiment.User.UserName = reader["UserName"].ToString();
                    experiment.SampleName = reader["SampleName"].ToString();
                    experiment.SampleDensity = Convert.ToSingle(reader["SampleDensity"].ToString());
                    experiment.ExperimentTemperature = Convert.ToSingle(reader["ExperimentTemperature"].ToString());
                    experiment.CapillaryDiameter = Convert.ToSingle(reader["CapillaryDiameter"].ToString());
                    experiment.CapillaryLength = Convert.ToSingle(reader["CapillaryLength"].ToString());
                    experiment.TorqueThreshold = Convert.ToSingle(reader["TorqueThreshold"].ToString());
                    experiment.PressureThreshold = Convert.ToSingle(reader["PressureThreshold"].ToString());
                    experiment.TemperatureThreshold = Convert.ToSingle(reader["TemperatureThreshold"].ToString());
                    experiment.MainMotorSpeedThreshold = Convert.ToInt32(reader["MainMotorSpeedThreshold"].ToString());
                    experiment.ExperimentStageNumber = Convert.ToInt32(reader["ExperimentStageNumber"].ToString());
                    experiment.IsRuning = Convert.ToBoolean(reader["IsRuning"].ToString());
                    //从数据库中查询各个实验阶段参数并赋值给实验阶段列表属性            
                    ExperimentStage stage = new ExperimentStage(experiment.ExperimentID);
                    experiment.StageList = stage.GetStageList(experiment.ExperimentID);
                    experiments.Add(experiment);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return experiments;
        }
        #endregion

        #region 从数据库中查询正在进行的实验的实验相关参数信息(包括各实验阶段参数)
        /// <summary>
        /// 从数据库中查询正在进行的实验的实验相关参数信息(包括各实验阶段参数)
        /// </summary>
        /// <returns>恒温实验参数</returns>
        public Experiment GetRuningParameter()
        {
            //从数据库中查询最近一次实验的实验参数并赋值给parameter
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_RUNNINGEXPERIMENT))
            {
                while (reader.Read()) //读查询结果
                {
                    //构造恒温实验参数对象                    
                    ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString());
                    User = new User();
                    ExperimentName = reader["ExperimentName"].ToString();
                    ExperimentTime = Convert.ToDateTime(reader["ExperimentTime"].ToString());
                    User.UserName = reader["UserName"].ToString();
                    SampleName = reader["SampleName"].ToString();
                    SampleDensity = Convert.ToSingle(reader["SampleDensity"].ToString());
                    ExperimentTemperature = Convert.ToSingle(reader["ExperimentTemperature"].ToString());
                    CapillaryDiameter = Convert.ToSingle(reader["CapillaryDiameter"].ToString());
                    CapillaryLength = Convert.ToSingle(reader["CapillaryLength"].ToString());
                    TorqueThreshold = Convert.ToSingle(reader["TorqueThreshold"].ToString());
                    PressureThreshold = Convert.ToSingle(reader["PressureThreshold"].ToString());
                    TemperatureThreshold = Convert.ToSingle(reader["TemperatureThreshold"].ToString());
                    MainMotorSpeedThreshold = Convert.ToInt32(reader["MainMotorSpeedThreshold"].ToString());
                    ExperimentStageNumber = Convert.ToInt32(reader["ExperimentStageNumber"].ToString());
                    IsRuning = Convert.ToBoolean(reader["IsRuning"].ToString());
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            //从数据库中查询各个实验阶段参数并赋值给实验阶段列表属性            
            ExperimentStage stage = new ExperimentStage(this._experimentID);
            this.StageList = stage.GetStageList(this.ExperimentID);
            return this;
        }
        #endregion

        #region 向数据库中插入一条新建实验（实验参数，不包括各实验阶段参数)
        /// <summary>
        /// 插入一条新建实验（实验参数，不包括各实验阶段参数)
        /// </summary>
        /// <param name="experiment">实验参数</param>
        /// <returns>是否成功</returns>
        public bool InsertExperiment(Experiment experiment)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {                    
                new OleDbParameter("@ExperimentName",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentTime",OleDbType.VarChar,255),
                new OleDbParameter("@UserName",OleDbType.VarChar,255),                    
                new OleDbParameter("@SampleName",OleDbType.VarChar,255),
                new OleDbParameter("@SampleDensity",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentTemperature",OleDbType.VarChar,255),
                new OleDbParameter("@PressureThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@CapillaryDiameter",OleDbType.VarChar,255),
                new OleDbParameter("@CapillaryLength",OleDbType.VarChar,255),
                new OleDbParameter("@TorqueThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@TemperatureThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@MainMotorSpeedThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentStageNumber",OleDbType.VarChar,255)
            };            
            parms[0].Value = experiment.ExperimentName;
            parms[1].Value = experiment.ExperimentTime.ToString();
            parms[2].Value = experiment.User.UserName;            
            parms[3].Value = experiment.SampleName; 
            parms[4].Value = experiment.SampleDensity;
            parms[5].Value = experiment.ExperimentTemperature;            
            parms[6].Value = experiment.PressureThreshold.ToString(); 
            parms[7].Value = experiment.CapillaryDiameter.ToString();
            parms[8].Value = experiment.CapillaryLength.ToString();
            parms[9].Value = experiment.TorqueThreshold.ToString();
            parms[10].Value = experiment.TemperatureThreshold.ToString();
            parms[11].Value = experiment.MainMotorSpeedThreshold.ToString();
            parms[12].Value = experiment.ExperimentStageNumber.ToString();           
            if (DbHelperAccess.ExecuteSql(SQL_INSERT_NEWEXPERIMENT, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 向数据库中更新实验相关参数信息（不包括各实验阶段参数)
        /// <summary>
        /// 更新实验相关参数信息（不包括各实验阶段参数)
        /// </summary>
        /// <param name="experiment">要更新的恒温实验参数对象</param>
        /// <returns></returns>
        public bool UpdateExperiment(Experiment experiment)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentName",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentTime",OleDbType.VarChar,255),
                new OleDbParameter("@UserName",OleDbType.VarChar,255),
                new OleDbParameter("@SampleName",OleDbType.VarChar,255),
                new OleDbParameter("@SampleDensity",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentTemperature",OleDbType.VarChar,255),
                new OleDbParameter("@PressureThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@CapillaryDiameter",OleDbType.VarChar,255),
                new OleDbParameter("@CapillaryLength",OleDbType.VarChar,255),
                new OleDbParameter("@TorqueThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@TemperatureThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@MainMotorSpeedThreshold",OleDbType.VarChar,255),
                new OleDbParameter("@ExperimentStageNumber",OleDbType.VarChar,255)
            };
            parms[0].Value = experiment.ExperimentName;
            parms[1].Value = experiment.ExperimentTime.ToString();
            parms[2].Value = experiment.User.UserName;
            parms[3].Value = experiment.SampleName;
            parms[4].Value = experiment.SampleDensity;
            parms[5].Value = experiment.ExperimentTemperature;
            parms[6].Value = experiment.PressureThreshold.ToString();
            parms[7].Value = experiment.CapillaryDiameter.ToString();
            parms[8].Value = experiment.CapillaryLength.ToString();
            parms[9].Value = experiment.TorqueThreshold.ToString();
            parms[10].Value = experiment.TemperatureThreshold.ToString();
            parms[11].Value = experiment.MainMotorSpeedThreshold.ToString();
            parms[12].Value = experiment.ExperimentStageNumber.ToString();
            if (DbHelperAccess.ExecuteSql(SQL_UPDATA_PARAMETER, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新实验运行状态
        /// <summary>
        /// 更新实验运行状态
        /// </summary>
        /// <param name="experimentID">实验ID</param>
        /// <param name="runingState">运行状态</param>
        /// <returns></returns>
        public bool UpdateRuningState(int experimentID, bool runingState)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@IsRuning",OleDbType.Boolean),
                new OleDbParameter("@ExperimentID",OleDbType.Integer)
            };
            parms[0].Value = runingState; 
            parms[1].Value = experimentID;
            if (DbHelperAccess.ExecuteSql(SQL_UPDATA_RUNINGSTATE, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
