public interface IRepository
{
    void AddUser(User user);
    void AddUsers(List<User> userList);
    List<User> GetAllUsers();
    void AddToken(Token token);
    Token GetToken();
    void UpdateToken(Token token);
}