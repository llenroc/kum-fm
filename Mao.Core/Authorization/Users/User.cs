using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace Mao.Core.Authorization.Users
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User : AbpUser<User>
    {
        public const int MinPlainPasswordLength = 6;

        public const int MaxPhoneNumberLength = 24;

        public virtual Guid? ProfilePictureId { get; set; }

        public virtual bool ShouldChangePasswordOnNextLogin { get; set; }

        //Can add application specific user properties here

        public User()
        {
            IsLockoutEnabled = true;
            IsTwoFactorEnabled = true;
        }
        
        /// <summary>
        /// Creates admin <see cref="User"/> for a tenant.
        /// </summary>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="emailAddress">Email address</param>
        /// <param name="password">Password</param>
        /// <returns>Created <see cref="User"/> object</returns>
        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
                   {
                       TenantId = tenantId,
                       UserName = AdminUserName,
                       //Name = AdminUserName,
                       //Surname = AdminUserName,
                       EmailAddress = emailAddress,
                       Password = new PasswordHasher().HashPassword(password)
                   };
        }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public void Unlock()
        {
            AccessFailedCount = 0;
            LockoutEndDateUtc = null;
        }





        //http://www.cnblogs.com/senyier/p/7505323.html

        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string RealName { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>		
        public string NickName { get; set; }




        /// <summary>
        /// 用户编码
        /// </summary>		
        public string EnCode { get; set; }
        /// <summary>
        /// 头像
        /// </summary>		
        public string HeadIcon { get; set; }
        /// <summary>
        /// 快速查询
        /// </summary>		
        public string QuickQuery { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>		
        public string SimpleSpelling { get; set; }
        /// <summary>
        /// 性别
        /// </summary>		
        public int? Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>		
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 手机
        /// </summary>		
        public string Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>		
        public string Telephone { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>		
        public string OICQ { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>		
        public string WeChat { get; set; }
        /// <summary>
        /// MSN
        /// </summary>		
        public string MSN { get; set; }
        /// <summary>
        /// 主管主键
        /// </summary>		
        public string ManagerId { get; set; }
        /// <summary>
        /// 主管
        /// </summary>		
        public string Manager { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>		
        public string OrganizeId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>		
        public string DepartmentId { get; set; }
        /// <summary>
        /// 角色主键
        /// </summary>		
        public string RoleId { get; set; }
        /// <summary>
        /// 岗位主键
        /// </summary>		
        public string DutyId { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>		
        public string DutyName { get; set; }
        /// <summary>
        /// 职位主键
        /// </summary>		
        public string PostId { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>		
        public string PostName { get; set; }
        /// <summary>
        /// 工作组主键
        /// </summary>		
        public string WorkGroupId { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>		
        public int? SecurityLevel { get; set; }
        /// <summary>
        /// 在线状态
        /// </summary>		
        public int? UserOnLine { get; set; }
        /// <summary>
        /// 单点登录标识
        /// </summary>		
        public int? OpenId { get; set; }
        /// <summary>
        /// 密码提示问题
        /// </summary>		
        public string Question { get; set; }
        /// <summary>
        /// 密码提示答案
        /// </summary>		
        public string AnswerQuestion { get; set; }
        /// <summary>
        /// 允许多用户同时登录
        /// </summary>		
        public int? CheckOnLine { get; set; }
        /// <summary>
        /// 允许登录时间开始
        /// </summary>		
        public DateTime? AllowStartTime { get; set; }
        /// <summary>
        /// 允许登录时间结束
        /// </summary>		
        public DateTime? AllowEndTime { get; set; }
        /// <summary>
        /// 暂停用户开始日期
        /// </summary>		
        public DateTime? LockStartDate { get; set; }
        /// <summary>
        /// 暂停用户结束日期
        /// </summary>		
        public DateTime? LockEndDate { get; set; }
        /// <summary>
        /// 第一次访问时间
        /// </summary>		
        public DateTime? FirstVisit { get; set; }
        /// <summary>
        /// 上一次访问时间
        /// </summary>		
        public DateTime? PreviousVisit { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>		
        public DateTime? LastVisit { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>		
        public int? LogOnCount { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>		
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>		
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Description { get; set; }
    }
}