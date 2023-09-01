/// <summary>
/// 描述：实验阶段类，用来对实验各阶段的相关参数进行维护
/// 作者：杨慧炯
/// 创建日期：2023/6/24 15:06:00
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
    public class ExperimentStage
    {
        #region 数据库操作SQL语句
        private const string SQL_SELECT_STAGEPARAMETERS_BY_ID = "SELECT ExperimentID,ExperimentStage,MainScrewSpeed," +
                                                          "FeedingScrewSpeed,SlicingSpeed,WeightingCycle" +
                                                          " FROM Rheomoter_ExperimentStageParameter WHERE ExperimentID=@ExperimentID";

        private const string SQL_INSERT_NEWSTAGE = "INSERT INTO Rheomoter_ExperimentStageParameter(ExperimentID,ExperimentStage,MainScrewSpeed," +
                                                        "FeedingScrewSpeed,SlicingSpeed,WeightingCycle)" +
                                                   " VALUES(@ExperimentID,@ExperimentStage,@MainScrewSpeed,@FeedingScrewSpeed,@SlicingSpeed,@WeightingCycle)";

        private const string SQL_UPDATA_STAGEPARAMETER = "UPDATE Rheomoter_ExperimentStageParameter  SET  MainScrewSpeed = @MainScrewSpeed," +
                                                    "FeedingScrewSpeed = @FeedingScrewSpeed,SlicingSpeed=@SlicingSpeed,WeightingCycle=@WeightingCycle" +
                                                    " WHERE ExperimentID=@ExperimentID AND　ExperimentStage＝@ExperimentStage";
        #endregion
        public ExperimentStage(int experimentID) 
        {
            this._experimentID = experimentID;
        }
        #region 字段（成员变量）
        int _experimentID;
        int _stage;
        int _mainScrewSpeed;
        int _feedingScrewSpeed;
        int _slicingSpeed;
        int _weightingCycle;
        #endregion

        #region 属性
        /// <summary>
        /// 实验ID
        /// </summary>
        public int ExperimentID { get => _experimentID; }
        /// <summary>
        /// 阶段
        /// </summary>
        public int Stage { get => _stage; set => _stage = value; }
        /// <summary>
        /// 主螺杆转速
        /// </summary>
        public int MainScrewSpeed { get => _mainScrewSpeed; set => _mainScrewSpeed = value; }
        /// <summary>
        /// 喂料螺杆转速
        /// </summary>
        public int FeedingScrewSpeed { get => _feedingScrewSpeed; set => _feedingScrewSpeed = value; }
        /// <summary>
        /// 切料速度
        /// </summary>
        public int SlicingSpeed { get => _slicingSpeed; set => _slicingSpeed = value; }
        /// <summary>
        /// 称重周期
        /// </summary>
        public int WeightingCycle { get => _weightingCycle; set => _weightingCycle = value; }
        #endregion

        #region 根据实验ID查询该实验所有实验阶段参数
        /// <summary>
        /// 根据实验ID查询该实验所有实验阶段参数
        /// </summary>
        /// <param name="experimentID">实验ID</param>
        /// <returns>实验阶段参数列表</returns>
        public List<ExperimentStage> GetStageList(int experimentID)
        {
            List<ExperimentStage> stageList = new List<ExperimentStage>();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentID",OleDbType.Integer)
            };
            parms[0].Value = experimentID;
            //从数据库中查询各个实验阶段参数并赋值给实验阶段列表属性
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_STAGEPARAMETERS_BY_ID, parms))
            {
                while (reader.Read()) //读查询结果
                {
                    ExperimentStage experimentStage = new ExperimentStage(experimentID);
                    experimentStage.Stage = Convert.ToInt32(reader["ExperimentStage"].ToString());
                    experimentStage.MainScrewSpeed = Convert.ToInt32(reader["MainScrewSpeed"].ToString());
                    experimentStage.FeedingScrewSpeed = Convert.ToInt32(reader["FeedingScrewSpeed"].ToString());
                    experimentStage.SlicingSpeed = Convert.ToInt32(reader["SlicingSpeed"].ToString());
                    experimentStage.WeightingCycle = Convert.ToInt32(reader["WeightingCycle"].ToString());
                    stageList.Add(experimentStage);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return stageList;
        }
        #endregion

        #region 向数据库中插入一条新实验阶段参数
        /// <summary>
        /// 向数据库中插入一条新实验阶段参数
        /// </summary>
        /// <param name="stage">实验阶段参数</param>
        /// <returns>是否成功</returns>
        public bool InsertStage(ExperimentStage stage)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentID",OleDbType.Integer),
                new OleDbParameter("@ExperimentStage",OleDbType.Integer),
                new OleDbParameter("@MainScrewSpeed",OleDbType.Integer),
                new OleDbParameter("@FeedingScrewSpeed",OleDbType.Integer),
                new OleDbParameter("@SlicingSpeed",OleDbType.Integer),
                new OleDbParameter("@WeightingCycle",OleDbType.Integer)                
            };
            parms[0].Value = stage.ExperimentID;
            parms[1].Value = stage.Stage;
            parms[2].Value = stage.MainScrewSpeed;
            parms[3].Value = stage.FeedingScrewSpeed;
            parms[4].Value = stage.SlicingSpeed;
            parms[5].Value = stage.WeightingCycle;            
            if (DbHelperAccess.ExecuteSql(SQL_INSERT_NEWSTAGE, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新实验某个阶段参数信息
        /// <summary>
        /// 更新实验某个阶段参数信息
        /// </summary>
        /// <param name="stage">要更新的恒温实验参数对象</param>
        /// <returns></returns>
        public bool UpdateStage(ExperimentStage stage)
        {
            //构造参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@ExperimentID",OleDbType.Integer),
                new OleDbParameter("@ExperimentStage",OleDbType.Integer),
                new OleDbParameter("@MainScrewSpeed",OleDbType.Integer),
                new OleDbParameter("@FeedingScrewSpeed",OleDbType.Integer),
                new OleDbParameter("@SlicingSpeed",OleDbType.Integer),
                new OleDbParameter("@WeightingCycle",OleDbType.Integer)                
            };
            parms[0].Value = stage.ExperimentID;
            parms[1].Value = stage.Stage;
            parms[2].Value = stage.MainScrewSpeed;
            parms[3].Value = stage.FeedingScrewSpeed;
            parms[4].Value = stage.SlicingSpeed;
            parms[5].Value = stage.WeightingCycle;            
            if (DbHelperAccess.ExecuteSql(SQL_UPDATA_STAGEPARAMETER, parms) != 0)
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
