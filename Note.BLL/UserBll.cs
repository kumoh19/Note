using Note.DAL;
using Note.IDAL;
using Note.Model;

namespace Note.BLL
{
    public class UserBll
    {
        //---------------------------------------------------------------
        //이렇게 하면 db를 바꿀때 bll의 코드 수정이 필요하다.
        ////private UserDal _userDal = new UserDal(); //강한 결합 방식

        //private readonly IUserDal _userDal;  //인터페이스


        ///// <summary>
        ///// 생성자를 만들어 DAL로 접근 가능하도록한다.
        ///// 생성자를 이용한 의존성 주입
        ///// </summary>
        ///// <param name="userDal"></param>
        //public UserBll(IUserDal userDal)
        //{
        //    _userDal = userDal;
        //}
        //---------------------------------------------------------------

        private readonly UserDal _userDal;

        public UserBll(UserDal userDal)
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