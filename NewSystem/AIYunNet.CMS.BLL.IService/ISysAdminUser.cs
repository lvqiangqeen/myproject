using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
	public interface ISysAdminUser
	{
		int AddAdminUser(SysAdminUser sysAdminUser);
        bool ExistUser(string userAccount, string userPwd);
        int UpdateAdminUserPassword(string userAccount, string userPwd);
        List<SysAdminUser> GetSysUserList();
        int UpdateAdminUser(SysAdminUser sysAdminUser);
        SysAdminUser GetSysUserByAccount(string userAccount, string userPwd);
    }
}
