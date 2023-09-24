using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSoft.Shared
{
    public interface IDataAccessProvider
    {
        void AddUserRecord(UserInfo user);
        void UpdateUserRecord(UserInfo user);
        void DeleteUserRecord(string userCode);
        UserInfo GetUserSingleRecord(string userCode);
        List<UserInfo> GetUserRecords();
    }
}
