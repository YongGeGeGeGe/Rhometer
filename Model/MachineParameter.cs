/// <summary>
/// 描述：设备类，用来对设备参数进行维护（数据库中存储设备初始参数，因而只有其）
/// 作者：杨慧炯
/// 创建日期：2023/6/25 0:01:47
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
    internal class MachineParameter
    {
        #region 数据库SQL语句
        private const string SQL_SELECT_PARAMETER = "SELECT TorqueIAdjustK,TorqueIAdjustB,TorqueAdjustK,TorqueAdjustB,"+
                                                    "PressureRange,PressureIAdjustK,PressureIAdjustB,PressureAdjustK,"+
                                                    "PressureAdjustB,NoseTemperatureIAdjustK,NoseTemperatureIAdjustB,"+
                                                    "NoseTemperatureAdjustK,NoseTemperatureAdjustB,NoseTemperatureOffsetAdjustX,"+
                                                    "BackWaterIAdjustK_1,BackWaterIAdjustB_1,BackWaterAdjustK_1,BackWaterAdjustB_1,"+
                                                    "BackWaterOffsetAdjustX_1,BackWaterIAdjustK_2,BackWaterIAdjustB_2,"+
                                                    "BackWaterAdjustK_2,BackWaterAdjustB_2,BackWaterOffsetAdjustX_2"+
                                                    " FROM Rhemoter_MachineParameter";
        private const string SQL_UPDATA_PARAMETER = "UPDATE Rhemoter_MachineParameter SET TorqueIAdjustK=@TorqueIAdjustK," +
                                                    "TorqueIAdjustB=@TorqueIAdjustB,TorqueAdjustK=@TorqueAdjustK," +
                                                    "TorqueAdjustB=@TorqueAdjustB,PressureRange=@PressureRange," +
                                                    "PressureIAdjustK=@PressureIAdjustK,PressureIAdjustB=@PressureIAdjustB," +
                                                    "PressureAdjustK=,@PressureAdjustK,PressureAdjustB=@PressureAdjustB," +
                                                    "NoseTemperatureIAdjustK=@NoseTemperatureIAdjustK,NoseTemperatureIAdjustB=@NoseTemperatureIAdjustB," +
                                                    "NoseTemperatureAdjustK=@NoseTemperatureAdjustK,NoseTemperatureAdjustB=@NoseTemperatureAdjustB," +
                                                    "NoseTemperatureOffsetAdjustX=@NoseTemperatureOffsetAdjustX,BackWaterIAdjustK_1=@BackWaterIAdjustK_1," +
                                                    "BackWaterIAdjustB_1=@BackWaterIAdjustB_1,BackWaterAdjustK_1=@BackWaterAdjustK_1," +
                                                    "BackWaterAdjustB_1=@BackWaterAdjustB_1,BackWaterOffsetAdjustX_1=@BackWaterOffsetAdjustX_1," +
                                                    "BackWaterIAdjustK_2=@BackWaterIAdjustK_2,BackWaterIAdjustB_2=@BackWaterIAdjustB_2," +
                                                    "BackWaterAdjustK_2=@BackWaterAdjustK_2,BackWaterAdjustB_2=@BackWaterAdjustB_2,BackWaterOffsetAdjustX_2=@BackWaterOffsetAdjustX_2";
        #endregion

        #region 字段（成员变量）
        float _torqueIAdjustK;
        float _torqueIAdjustB;
        float _torqueAdjustK;
        float _torqueAdjustB;
        float _pressureRange;
        float _pressureIAdjustK;
        float _pressureIAdjustB;
        float _pressureAdjustK;
        float _pressureAdjustB;
        float _noseTemperatureIAdjustK;
        float _noseTemperatureIAdjustB;
        float _noseTemperatureAdjustK;
        float _noseTemperatureAdjustB;
        float _noseTemperatureOffsetAdjustX;
        float _backWaterIAdjustK_1;
        float _backWaterIAdjustB_1;
        float _backWaterAdjustK_1;
        float _backWaterAdjustB_1;
        float _backWaterOffsetAdjustX_1;
        float _backWaterIAdjustK_2;
        float _backWaterIAdjustB_2;
        float _backWaterAdjustK_2;
        float _backWaterAdjustB_2;
        float _backWaterOffsetAdjustX_2;
        #endregion

        #region 属性
        /// <summary>
        /// 扭矩电流值校准参数K
        /// </summary>
        public float TorqueIAdjustK { get => _torqueIAdjustK; set => _torqueIAdjustK = value; }
        /// <summary>
        /// 扭矩电流值校准参数B
        /// </summary>
        public float TorqueIAdjustB { get => _torqueIAdjustB; set => _torqueIAdjustB = value; }
        /// <summary>
        /// 扭矩值校准参数K
        /// </summary>
        public float TorqueAdjustK { get => _torqueAdjustK; set => _torqueAdjustK = value; }
        /// <summary>
        /// 扭矩值校准参数B
        /// </summary>
        public float TorqueAdjustB { get => _torqueAdjustB; set => _torqueAdjustB = value; }
        /// <summary>
        /// 压力传感器量程
        /// </summary>
        public float PressureRange { get => _pressureRange; set => _pressureRange = value; }
        /// <summary>
        /// 压力电流值校准参数K
        /// </summary>
        public float PressureIAdjustK { get => _pressureIAdjustK; set => _pressureIAdjustK = value; }
        /// <summary>
        /// 压力电流值校准参数B
        /// </summary>
        public float PressureIAdjustB { get => _pressureIAdjustB; set => _pressureIAdjustB = value; }
        /// <summary>
        /// 压力值校准参数K
        /// </summary>
        public float PressureAdjustK { get => _pressureAdjustK; set => _pressureAdjustK = value; }
        /// <summary>
        /// 压力值校准参数B
        /// </summary>
        public float PressureAdjustB { get => _pressureAdjustB; set => _pressureAdjustB = value; }
        /// <summary>
        /// 机头温度电流值校准K
        /// </summary>
        public float NoseTemperatureIAdjustK { get => _noseTemperatureIAdjustK; set => _noseTemperatureIAdjustK = value; }
        /// <summary>
        /// 机头温度电流值校准B
        /// </summary>
        public float NoseTemperatureIAdjustB { get => _noseTemperatureIAdjustB; set => _noseTemperatureIAdjustB = value; }
        /// <summary>
        /// 机头温度值校准K
        /// </summary>
        public float NoseTemperatureAdjustK { get => _noseTemperatureAdjustK; set => _noseTemperatureAdjustK = value; }
        /// <summary>
        /// 机头温度值校准B
        /// </summary>
        public float NoseTemperatureAdjustB { get => _noseTemperatureAdjustB; set => _noseTemperatureAdjustB = value; }
        /// <summary>
        /// 机头温度偏移值X
        /// </summary>
        public float NoseTemperatureOffsetAdjustX { get => _noseTemperatureOffsetAdjustX; set => _noseTemperatureOffsetAdjustX = value; }
        /// <summary>
        /// 回水温度1电流值校准K
        /// </summary>
        public float BackWaterIAdjustK_1 { get => _backWaterIAdjustK_1; set => _backWaterIAdjustK_1 = value; }
        /// <summary>
        /// 回水温度1电流值校准B
        /// </summary>
        public float BackWaterIAdjustB_1 { get => _backWaterIAdjustB_1; set => _backWaterIAdjustB_1 = value; }
        /// <summary>
        /// 回水温度1值校准K
        /// </summary>
        public float BackWaterAdjustK_1 { get => _backWaterAdjustK_1; set => _backWaterAdjustK_1 = value; }
        /// <summary>
        /// 回水温度1值校准B
        /// </summary>
        public float BackWaterAdjustB_1 { get => _backWaterAdjustB_1; set => _backWaterAdjustB_1 = value; }
        /// <summary>
        /// 回水温度1偏移值X
        /// </summary>
        public float BackWaterOffsetAdjustX_1 { get => _backWaterOffsetAdjustX_1; set => _backWaterOffsetAdjustX_1 = value; }
        /// <summary>
        /// 回水温度2电流值校准K
        /// </summary>
        public float BackWaterIAdjustK_2 { get => _backWaterIAdjustK_2; set => _backWaterIAdjustK_2 = value; }
        /// <summary>
        /// 回水温度2电流值校准B
        /// </summary>
        public float BackWaterIAdjustB_2 { get => _backWaterIAdjustB_2; set => _backWaterIAdjustB_2 = value; }
        /// <summary>
        /// 回水温度2值校准K
        /// </summary>
        public float BackWaterAdjustK_2 { get => _backWaterAdjustK_2; set => _backWaterAdjustK_2 = value; }
        /// <summary>
        /// 回水温度2值校准B
        /// </summary>
        public float BackWaterAdjustB_2 { get => _backWaterAdjustB_2; set => _backWaterAdjustB_2 = value; }
        /// <summary>
        /// 回水温度2偏移值X
        /// </summary>
        public float BackWaterOffsetAdjustX_2 { get => _backWaterOffsetAdjustX_2; set => _backWaterOffsetAdjustX_2 = value; }
        #endregion

        #region 查询设备参数
        /// <summary>
        /// 查询设备参数
        /// </summary>
        /// <returns>设备对象</returns>
        public MachineParameter GetParameter()
        {
            MachineParameter machine = null;
            //从数据库中查询设备参数并赋值给machine
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_PARAMETER))
            {
                while (reader.Read()) //读查询结果
                {
                    //构造User对象
                    machine = new MachineParameter
                    {
                        TorqueIAdjustK = Convert.ToSingle(reader["TorqueIAdjustK"].ToString()),
                        TorqueIAdjustB = Convert.ToSingle(reader["TorqueIAdjustB"].ToString()),
                        TorqueAdjustK = Convert.ToSingle(reader["TorqueAdjustK"].ToString()),
                        TorqueAdjustB = Convert.ToSingle(reader["TorqueAdjustB"].ToString()),
                        PressureRange = Convert.ToInt32(reader["PressureRange"].ToString()),
                        PressureIAdjustK = Convert.ToInt32(reader["PressureIAdjustK"].ToString()),
                        PressureIAdjustB = Convert.ToInt32(reader["PressureIAdjustB"].ToString()),
                        PressureAdjustK = Convert.ToInt32(reader["PressureAdjustK"].ToString()),
                        PressureAdjustB = Convert.ToInt32(reader["PressureAdjustB"].ToString()),
                        NoseTemperatureIAdjustK = Convert.ToInt32(reader["NoseTemperatureIAdjustK"].ToString()),
                        NoseTemperatureIAdjustB = Convert.ToInt32(reader["NoseTemperatureIAdjustB"].ToString()),
                        NoseTemperatureAdjustK = Convert.ToInt32(reader["NoseTemperatureAdjustK"].ToString()),
                        NoseTemperatureAdjustB = Convert.ToInt32(reader["NoseTemperatureAdjustB"].ToString()),
                        NoseTemperatureOffsetAdjustX = Convert.ToInt32(reader["NoseTemperatureOffsetAdjustX"].ToString()),
                        BackWaterIAdjustK_1 = Convert.ToInt32(reader["BackWaterIAdjustK_1"].ToString()),
                        BackWaterIAdjustB_1 = Convert.ToInt32(reader["BackWaterIAdjustB_1"].ToString()),
                        BackWaterAdjustK_1 = Convert.ToInt32(reader["BackWaterAdjustK_1"].ToString()),
                        BackWaterAdjustB_1 = Convert.ToInt32(reader["BackWaterAdjustB_1"].ToString()),
                        BackWaterOffsetAdjustX_1 = Convert.ToInt32(reader["BackWaterOffsetAdjustX_1"].ToString()),
                        BackWaterIAdjustK_2 = Convert.ToInt32(reader["BackWaterIAdjustK_2"].ToString()),
                        BackWaterIAdjustB_2 = Convert.ToInt32(reader["BackWaterIAdjustB_2"].ToString()),
                        BackWaterAdjustK_2 = Convert.ToInt32(reader["BackWaterAdjustK_2"].ToString()),
                        BackWaterAdjustB_2 = Convert.ToInt32(reader["BackWaterAdjustB_2"].ToString()),
                        BackWaterOffsetAdjustX_2 = Convert.ToInt32(reader["BackWaterOffsetAdjustX_2"].ToString())
                    };
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return machine;
        }
        #endregion

        #region 更新设备参数
        /// <summary>
        /// 更新设备参数
        /// </summary>
        /// <param machine>需要更新的设备对象</param>
        /// <returns>返回更新是否成功</returns>
        public bool UpdateParameter(MachineParameter machine)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@TorqueIAdjustK",OleDbType.Single),
                new OleDbParameter("@TorqueIAdjustB",OleDbType.Single),
                new OleDbParameter("@TorqueAdjustK",OleDbType.Single),
                new OleDbParameter("@TorqueAdjustB",OleDbType.Single),
                new OleDbParameter("@PressureRange",OleDbType.Integer),
                new OleDbParameter("@PressureIAdjustK",OleDbType.Single),
                new OleDbParameter("@PressureIAdjustB",OleDbType.Single),
                new OleDbParameter("@PressureAdjustK",OleDbType.Single),
                new OleDbParameter("@PressureAdjustB",OleDbType.Single),
                new OleDbParameter("@NoseTemperatureIAdjustK",OleDbType.Single),
                new OleDbParameter("@NoseTemperatureIAdjustB",OleDbType.Single),
                new OleDbParameter("@NoseTemperatureAdjustK",OleDbType.Single),
                new OleDbParameter("@NoseTemperatureAdjustB",OleDbType.Single),
                new OleDbParameter("@NoseTemperatureOffsetAdjustX",OleDbType.Single),
                new OleDbParameter("@BackWaterIAdjustK_1",OleDbType.Single),
                new OleDbParameter("@BackWaterIAdjustB_1",OleDbType.Single),
                new OleDbParameter("@BackWaterAdjustK_1",OleDbType.Single),
                new OleDbParameter("@BackWaterAdjustB_1",OleDbType.Single),
                new OleDbParameter("@BackWaterOffsetAdjustX_1",OleDbType.Single),
                new OleDbParameter("@BackWaterIAdjustK_2",OleDbType.Single),
                new OleDbParameter("@BackWaterIAdjustB_2",OleDbType.Single),
                new OleDbParameter("@BackWaterAdjustK_2",OleDbType.Single),
                new OleDbParameter("@BackWaterAdjustB_2",OleDbType.Single),
                new OleDbParameter("@BackWaterOffsetAdjustX_2",OleDbType.Single)
            };
            parms[0].Value = machine.TorqueIAdjustK;
            parms[1].Value = machine.TorqueIAdjustB; 
            parms[2].Value = machine.TorqueAdjustK;
            parms[3].Value = machine.TorqueAdjustB;
            parms[4].Value = machine.PressureRange;
            parms[5].Value = machine.PressureIAdjustK;
            parms[6].Value = machine.PressureAdjustK;
            parms[7].Value = machine.PressureAdjustK;
            parms[8].Value = machine.PressureAdjustB;
            parms[9].Value = machine.NoseTemperatureIAdjustK;
            parms[10].Value = machine.NoseTemperatureIAdjustB;
            parms[11].Value = machine.NoseTemperatureAdjustK;
            parms[12].Value = machine.NoseTemperatureAdjustB;
            parms[13].Value = machine.NoseTemperatureOffsetAdjustX;
            parms[14].Value = machine.BackWaterIAdjustK_1;
            parms[15].Value = machine.BackWaterIAdjustB_1;
            parms[16].Value = machine.BackWaterAdjustK_1;
            parms[17].Value = machine.BackWaterAdjustB_1;
            parms[18].Value = machine.BackWaterOffsetAdjustX_1;
            parms[19].Value = machine.BackWaterIAdjustK_2;
            parms[20].Value = machine.BackWaterIAdjustB_2;
            parms[21].Value = machine.BackWaterAdjustK_2;
            parms[22].Value = machine.BackWaterAdjustB_2;
            parms[23].Value = machine.BackWaterOffsetAdjustX_2;

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
    }
}
