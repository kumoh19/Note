using Note.IDAL;
using Note.Model;

namespace Note.DAL
{ //DB와 직접통신
    public class UserDal : IUserDal
    {
        public User GetUser(int userNo)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}