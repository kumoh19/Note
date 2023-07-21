using Note.IDAL;
using Note.Model;

namespace Note.BLL
{
    public class UserBll
    {
        //private UserDal _userDal = new UserDal(); //강한 결합 방식

        private readonly IUserDal _userDal;  //인터페이스

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(int userNo)
        {
            return _userDal.GetUser(userNo);
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}