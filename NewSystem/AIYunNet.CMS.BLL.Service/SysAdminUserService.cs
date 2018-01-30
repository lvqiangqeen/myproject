using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class SysAdminUserService : ISysAdminUser
    {
        public int AddAdminUser(SysAdminUser sysAdminUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.SysAdminUser.Add(sysAdminUser);
                context.SaveChanges();
                return 1;
            }
        }

        public bool ExistUser(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                SysAdminUser user = context.SysAdminUser.FirstOrDefault(us => us.UserAccount == userAccount && us.UserPassword == userPwd);
                return user != null ? true : false;
            }
        }

        public int UpdateAdminUserPassword(string userAccount, string newUserPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                SysAdminUser user = context.SysAdminUser.FirstOrDefault(us => us.UserAccount == userAccount);
                if (user != null)
                {
                    user.UserPassword = newUserPwd;
                    user.EditOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public List<SysAdminUser> GetSysUserList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.SysAdminUser.Where(su => su.FlagDelete == 0).ToList();
            }
        }

        public int UpdateAdminUser(SysAdminUser newSysAdminUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                SysAdminUser originalUser = context.SysAdminUser.Find(newSysAdminUser.UserID);
                if (originalUser != null)
                {
                    originalUser.UserAccount = newSysAdminUser.UserAccount;
                    originalUser.UserPassword = newSysAdminUser.UserPassword;
                    originalUser.CompanyID = newSysAdminUser.CompanyID;
                    originalUser.CompanyName = newSysAdminUser.CompanyName;
                    originalUser.RoleType = newSysAdminUser.RoleType;
                    originalUser.IsUse = newSysAdminUser.IsUse;
                    originalUser.EditOn = DateTime.Now;
                }
                return 1;
            }
        }

        public SysAdminUser GetSysUserByID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.SysAdminUser.Find(userID);
            }
        }

        public SysAdminUser GetSysUserByAccount(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                SysAdminUser user = context.SysAdminUser.FirstOrDefault(us => us.UserAccount == userAccount && us.UserPassword == userPwd);
                return user;
            }
        }
    }
}
