/// <summary>
/// 描述：实时数据类，用来对设备上传的实验数据进行存储合查询
/// 作者：杨慧炯
/// 创建日期：2023/6/29 0:01:47
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
using Utils.Utils;

namespace Rheometer_Torque.Model
{
    internal class RealTimeData
    {
        #region 数据库SQL语句
        private const string SQL_SELECT_EXPERIMENTDATA_BY_EXPERIMENTID = "SELECT ExperimentID,ExperimentStage,ExperimentTime,MainMotorSpeed," +
                                                              "ScrewTorque,FeedingMotorSpeed,NoseMotorSpeed,NosePosition,NoseOpenClose," +
                                                              "BucketPosition,BucketOpenClose,NosePressure,NoseTemperature,BackWaterTemperature_1," +
                                                              "BackWaterTemperature_2,MassValue,SlicingSpeed,ShearRate,ShearStress,ShearViscosity" +
                                                              " FROM Rheometer_ExperimentData WHERE ExperimentID=@ExperimentID";
        private const string SQL_INSERT_EXPERIMENTDATA = "INSERT INTO Rheometer_ExperimentData(ExperimentID,ExperimentStage,ExperimentTime,MainMotorSpeed," +
                                                         "ScrewTorque,FeedingMotorSpeed,NoseMotorSpeed,NosePosition,BucketPosition,BucketOpenClose,"+
                                                         "NosePressure,NoseTemperature,BackWaterTemperature_1,BackWaterTemperature_2,MassValue,SlicingSpeed,"+
                                                         "ShearRate,ShearStress,ShearViscosity)" +
                                               " VALUES(@ExperimentID,@ExperimentStage,@ExperimentTime,@MainMotorSpeed,@ScrewTorque,@FeedingMotorSpeed,"+
                                               "@NoseMotorSpeed,@NosePosition,@NoseOpenClose,@BucketPosition,@BucketOpenClose,@NosePressure,@NoseTemperature,"+
                                               "@BackWaterTemperature_1,@BackWaterTemperature_2,@MassValue,@SlicingSpeed,@ShearRate,@ShearStress,@ShearViscosity)";
        #endregion

        #region 字段（成员变量）
        int _experimentID;
        int _experimentStage;
        DateTime _experimentTime;
        int _mainMotorSpeed;
        float _screwTorque;
        int _feedingMotorSpeed;
        int _noseMotorSpeed;
        float _nosePosition;
        bool _noseIsOpened;
        float _bucketPosition;
        bool _bucketIsOpened;
        float _nosePressure;
        float _noseTemperature;
        float _backWaterTemperature_1;
        float _backWaterTemperature_2;
        int _massValue;
        int _slicingSpeed;
        float _shearRate;
        float _shearStress;
        float _shearViscosity;
        #endregion

        #region 属性
        /// <summary>
        /// 实验ID
        /// </summary>
        public int ExperimentID { get => _experimentID; set => _experimentID = value; }
        /// <summary>
        /// 实验阶段
        /// </summary>
        public int ExperimentStage { get => _experimentStage; set => _experimentStage = value; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime ExperimentTime { get => _experimentTime; set => _experimentTime = value; }
        /// <summary>
        /// 主机转速
        /// </summary>
        public int MainMotorSpeed { get => _mainMotorSpeed; set => _mainMotorSpeed = value; }
        /// <summary>
        /// 螺杆扭矩
        /// </summary>
        public float ScrewTorque { get => _screwTorque; set => _screwTorque = value; }
        /// <summary>
        /// 喂料电机转速
        /// </summary>
        public int FeedingMotorSpeed { get => _feedingMotorSpeed; set => _feedingMotorSpeed = value; }
        /// <summary>
        /// 机头电机转速
        /// </summary>
        public int NoseMotorSpeed { get => _noseMotorSpeed; set => _noseMotorSpeed = value; }
        /// <summary>
        /// 机头实时位置
        /// </summary>
        public float NosePosition { get => _nosePosition; set => _nosePosition = value; }
        /// <summary>
        /// 机头是否打开
        /// </summary>
        public bool NoseIsOpened { get => _noseIsOpened; set => _noseIsOpened = value; }
        /// <summary>
        /// 料筒实时位置
        /// </summary>
        public float BucketPosition { get => _bucketPosition; set => _bucketPosition = value; }
        /// <summary>
        /// 料筒是否打开
        /// </summary>
        public bool BucketIsOpened { get => _bucketIsOpened; set => _bucketIsOpened = value; }
        /// <summary>
        /// 机头压力
        /// </summary>
        public float NosePressure { get => _nosePressure; set => _nosePressure = value; }
        /// <summary>
        /// 机头温度
        /// </summary>
        public float NoseTemperature { get => _noseTemperature; set => _noseTemperature = value; }
        /// <summary>
        /// 回水温度传感器1值
        /// </summary>
        public float BackWaterTemperature_1 { get => _backWaterTemperature_1; set => _backWaterTemperature_1 = value; }
        /// <summary>
        /// 回水温度传感器2值
        /// </summary>
        public float BackWaterTemperature_2 { get => _backWaterTemperature_2; set => _backWaterTemperature_2 = value; }
        /// <summary>
        /// 称重质量
        /// </summary>
        public int MassValue { get => _massValue; set => _massValue = value; }
        /// <summary>
        /// 切粒速度
        /// </summary>
        public int SlicingSpeed { get => _slicingSpeed; set => _slicingSpeed = value; }
        /// <summary>
        /// 剪切速率
        /// </summary>
        public float ShearRate { get => _shearRate; set => _shearRate = value; }
        /// <summary>
        /// 剪切应力
        /// </summary>
        public float ShearStress { get => _shearStress; set => _shearStress = value; }
        /// <summary>
        /// 剪切粘度
        /// </summary>
        public float ShearViscosity { get => _shearViscosity; set => _shearViscosity = value; }
        #endregion

        #region 根据ID查询实验数据
        /// <summary>
        /// 根据ID查询实验数据
        /// </summary>
        /// <param name="experimentId"></param>
        /// <returns></returns>
        public List<RealTimeData> GetExperimentData(int experimentId)
        {
            List<RealTimeData> datas = new List<RealTimeData>();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                    new OleDbParameter("@ExperimentID",OleDbType.Integer)
            };
            parms[0].Value = ExperimentID;
            //从数据库中查询所有满足条件的实验数据返回
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_EXPERIMENTDATA_BY_EXPERIMENTID, parms))
            {
                while (reader.Read()) //读查询结果
                {
                    RealTimeData data = new RealTimeData();
                    //构造恒温实验参数对象                    
                    data.ExperimentID = Convert.ToInt32(reader["ExperimentID"].ToString());
                    data.ExperimentStage = Convert.ToInt32(reader["ExperimentStage"].ToString());
                    data.ExperimentTime = Convert.ToDateTime(reader["ExperimentTime"].ToString());
                    data.MainMotorSpeed = Convert.ToInt32(reader["MainMotorSpeed"].ToString());
                    data.ScrewTorque = Convert.ToSingle(reader["ScrewTorque"].ToString());
                    data.FeedingMotorSpeed = Convert.ToInt32(reader["FeedingMotorSpeed"].ToString());
                    data.NoseMotorSpeed = Convert.ToInt32(reader["NoseMotorSpeed"].ToString());
                    data.NosePosition = Convert.ToSingle(reader["NosePosition"].ToString());
                    data.NoseIsOpened = Convert.ToBoolean(reader["NoseOpenClose"].ToString());
                    data.BucketPosition = Convert.ToSingle(reader["BucketPosition"].ToString());
                    data.BucketIsOpened = Convert.ToBoolean(reader["BucketOpenClose"].ToString());
                    data.NosePressure = Convert.ToSingle(reader["NosePressure"].ToString());
                    data.NoseTemperature = Convert.ToSingle(reader["NoseTemperature"].ToString());
                    data.BackWaterTemperature_1 = Convert.ToSingle(reader["BackWaterTemperature_1"].ToString());
                    data.BackWaterTemperature_2 = Convert.ToSingle(reader["BackWaterTemperature_2"].ToString());
                    data.MassValue = Convert.ToInt32(reader["MassValue"].ToString());
                    data.SlicingSpeed = Convert.ToInt32(reader["SlicingSpeed"].ToString());                    
                    if (reader["ShearRate"].ToString() != null && reader["ShearRate"].ToString() != "")
                    {
                        data.ShearRate = Convert.ToSingle(reader["ShearRate"].ToString());
                        data.ShearStress = Convert.ToSingle(reader["ShearStress"].ToString());
                        data.ShearViscosity = Convert.ToSingle(reader["ShearViscosity"].ToString());
                    }
                    datas.Add(data);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return datas;
        }
        #endregion

        #region 向数据库中插入一条实验数据记录
        public bool InsertExperimentData(RealTimeData data)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                    new OleDbParameter("@ExperimentID",OleDbType.Integer),
                    new OleDbParameter("@ExperimentStage",OleDbType.Integer),
                    new OleDbParameter("@ExperimentTime",OleDbType.VarChar,255),
                    new OleDbParameter("@MainMotorSpeed",OleDbType.Integer),
                    new OleDbParameter("@ScrewTorque",OleDbType.VarChar,255),
                    new OleDbParameter("@FeedingMotorSpeed",OleDbType.VarChar,255),
                    new OleDbParameter("@NoseMotorSpeed",OleDbType.VarChar,255),
                    new OleDbParameter("@NosePosition",OleDbType.VarChar,255),
                    new OleDbParameter("@NoseOpenClose",OleDbType.VarChar,255),
                    new OleDbParameter("@BucketPosition",OleDbType.VarChar,255),
                    new OleDbParameter("@BucketOpenClose",OleDbType.VarChar,255),
                    new OleDbParameter("@NosePressure",OleDbType.VarChar,255),
                    new OleDbParameter("@NoseTemperature",OleDbType.VarChar,255),
                    new OleDbParameter("@BackWaterTemperature_1",OleDbType.VarChar,255),
                    new OleDbParameter("@BackWaterTemperature_2",OleDbType.VarChar,255),
                    new OleDbParameter("@MassValue",OleDbType.VarChar,255),
                    new OleDbParameter("@SlicingSpeed",OleDbType.VarChar,255),
                    new OleDbParameter("@ShearRate",OleDbType.VarChar,255),
                    new OleDbParameter("@ShearStress",OleDbType.VarChar,255),
                    new OleDbParameter("@ShearViscosity",OleDbType.VarChar,255),                   
            };
            parms[0].Value = data.ExperimentID;
            parms[1].Value = data.ExperimentStage;
            parms[2].Value = data.ExperimentTime.ToString();
            parms[3].Value = data.MainMotorSpeed.ToString();
            parms[4].Value = data.ScrewTorque.ToString();
            parms[5].Value = data.FeedingMotorSpeed.ToString();
            parms[6].Value = data.NoseMotorSpeed.ToString();
            parms[7].Value = data.NosePosition.ToString();
            parms[8].Value = data.NoseIsOpened.ToString();
            parms[9].Value = data.BucketPosition.ToString();
            parms[10].Value = data.BucketIsOpened.ToString();
            parms[11].Value = data.NosePressure.ToString();
            parms[12].Value = data.NoseTemperature.ToString();
            parms[13].Value = data.BackWaterTemperature_1.ToString();
            parms[14].Value = data.BackWaterTemperature_2.ToString();
            parms[15].Value = data.MassValue.ToString();
            parms[16].Value = data.SlicingSpeed.ToString();
            parms[17].Value = data.ShearRate.ToString();
            parms[18].Value = data.ShearStress.ToString();
            parms[19].Value = data.ShearViscosity.ToString();
            if (DbHelperAccess.ExecuteSql(SQL_INSERT_EXPERIMENTDATA, parms) != 0)
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
