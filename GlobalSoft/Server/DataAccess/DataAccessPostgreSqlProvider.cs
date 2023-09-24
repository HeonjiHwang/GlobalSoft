using GlobalSoft.Shared;

namespace GlobalSoft.Server.DataAccess
{
    public class DataAccessPostgreSqlProvider : IDataAccessProvider
    {
        private readonly DomainModelPostgreSqlContext _context;

        public DataAccessPostgreSqlProvider(DomainModelPostgreSqlContext context)
        {
            _context = context;
        }

        public void AddUserRecord(UserInfo user)
        {
            _context.UserInfos.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUserRecord(UserInfo user)
        {
            _context.UserInfos.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserRecord(string userCode)
        {
            var entity = _context.UserInfos.First(t => t.UserCode == userCode);
            _context.UserInfos.Remove(entity);
            _context.SaveChanges();
        }

        public UserInfo GetUserSingleRecord(string userCode)
        {
            return _context.UserInfos.First(t => t.UserCode == userCode);
        }

        public List<UserInfo> GetUserRecords()
        {
            return _context.UserInfos.ToList();
        }
    }
}
