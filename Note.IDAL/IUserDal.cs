using Note.Model;

namespace Note.IDAL
{ //인터페이스 모음(느슨한 결합 위해)
    public interface IUserDal
    {
        List<User> GetUserList();
        User GetUser(int userNo);
    }
}