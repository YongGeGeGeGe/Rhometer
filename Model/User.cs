/// <summary>
/// 描述：用户类
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:58:18
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
    public class User
    {
        #region 数据库SQL语句
        private const string SQL_SELECT_USER_FOR_LOGIN = "SELECT UserID,UserName,PassWord,Role FROM Rheometer_UserInfo WHERE UserName=@UserName AND PassWord=@PassWord";
        private const string SQL_SELECT_ADMIN_FOR_LOGIN = "SELECT UserID,UserName,PassWord,Role FROM Rheometer_UserInfo WHERE PassWord=@PassWord";
        private const string SQL_UPDATA_USER = "UPDATE  HFM_UserInfo  SET  [PassWord] = @UserPassWord   WHERE UserName = @UserName";

        private const string SQL_SELECT_USER = "SELECT UserID,UserName,PassWord,Role FROM HFM_UserInfo";
        private const string SQL_SELECT_USER_BY_USERID = "SELECT UserID,UserName,PassWord,Role FROM HFM_UserInfo WHERE UserID=@UserID";
        #endregion

        #region 字段属性
        private int _userId;
        private string _userName;
        private string _passWord;
        private int _role;
        private bool _isOffLine;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get => _userId; set => _userId = value; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get => _userName; set => _userName = value; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get => _passWord; set => _passWord = value; }
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get => _role; set => _role = value; }

        /// <summary>
        /// 当前用户登陆角色
        /// 1:超级管理员，2：普通用户，99：无权限
        /// </summary>
        public static User LandingUser { get; set; }
        /// <summary>
        /// 用户是否进行脱机离线操作
        /// </summary>
        public bool IsOffLine { get => _isOffLine; set => _isOffLine = value; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public User()
        {

        }

        #endregion

        #region 用户登录验证
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public User Login(string userName, string passWord)
        {
            User user = new User();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@UserName",OleDbType.VarChar,255),
                new OleDbParameter("@PassWord",OleDbType.VarChar,255)
            };
            parms[0].Value = userName;
            parms[1].Value = passWord;
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_USER_FOR_LOGIN, parms))
            {
                while (reader.Read())
                {
                    //构造User对象
                    user.UserId = Convert.ToInt32(reader["UserID"].ToString());
                    user.UserName = Convert.ToString(reader["UserName"].ToString());
                    user.PassWord = Convert.ToString(reader["PassWord"].ToString());
                    user.Role = Convert.ToInt32(reader["Role"].ToString());
                    //从reader读出的查询对象添加到List中
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return user;
        }
        #endregion

        #region 管理密码验证
        /// <summary>
        /// 管理密码验证
        /// </summary>       
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public User Login(string passWord)
        {
            User user = new User();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@PassWord",OleDbType.VarChar,255)
            };
            parms[0].Value = passWord;
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_ADMIN_FOR_LOGIN, parms))
            {
                while (reader.Read())
                {
                    //构造User对象
                    user.UserId = Convert.ToInt32(reader["UserID"].ToString());
                    user.UserName = Convert.ToString(reader["UserName"].ToString());
                    user.PassWord = Convert.ToString(reader["PassWord"].ToString());
                    user.Role = Convert.ToInt32(reader["Role"].ToString());
                    //从reader读出的查询对象添加到List中
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return user;
        }
        #endregion

        #region 根据用户ID修改密码
        /// <summary>
        /// 根据用户类的用户名称,修改密码
        /// </summary>
        /// <param name="User">需要修改的用户类</param>
        /// <returns>返回成功
        ///          或失败   </returns>
        public bool ChangePassWord(User user)
        {
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@UserPassWord",OleDbType.VarChar,255),
                new OleDbParameter("@UserName",OleDbType.VarChar,255)
            };
            parms[0].Value = user.PassWord;
            parms[1].Value = user.UserName;
            if (DbHelperAccess.ExecuteSql(SQL_UPDATA_USER, parms) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 从数据库中获得所有用户
        /// <summary>
        /// 从数据库中获得所有用户
        /// </summary>
        /// <returns></returns>
        public IList<User> GetUser()
        {
            IList<User> IUserS = new List<User>();
            //从数据库中查询全部刻度操作记录并赋值给IUserS
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_USER))
            {
                while (reader.Read()) //读查询结果
                {
                    //构造User对象
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserID"].ToString()),
                        UserName = Convert.ToString(reader["UserName"].ToString()),
                        PassWord = Convert.ToString(reader["PassWord"].ToString()),
                        Role = Convert.ToInt32(reader["Role"].ToString())
                    };
                    //从reader读出的查询对象添加到List中
                    IUserS.Add(user);
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            return IUserS;
        }
        #endregion

        #region 从数据库中按照用户ID查询用户信息
        /// <summary>
        /// 从数据库中按照用户ID查询用户信息
        /// </summary>
        /// <param name="userID">用户Id</param>
        /// <returns></returns>
        public User GetUser(int userID)
        {
            User user = new User();
            //构造查询参数
            OleDbParameter[] parms = new OleDbParameter[]
            {
                    new OleDbParameter("@userID",OleDbType.Boolean,2)
            };
            parms[0].Value = userID;
            //从数据库中查询全部刻度操作记录并赋值给IUserS
            using (OleDbDataReader reader = DbHelperAccess.ExecuteReader(SQL_SELECT_USER_BY_USERID, parms))
            {
                while (reader.Read())
                {
                    //构造User对象                
                    user.UserId = Convert.ToInt32(reader["UserID"].ToString());
                    user.UserName = Convert.ToString(reader["UserName"].ToString());
                    user.PassWord = Convert.ToString(reader["PassWord"].ToString());
                    user.Role = Convert.ToInt32(reader["Role"].ToString());
                }
                reader.Close();
                DbHelperAccess.Close();
            }
            //从reader读出的查询对象添加到List中
            return user;
        }
        #endregion
    }
}
