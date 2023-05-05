public class User
{
    public string Nickname { get;set; }
    public string Password { get; set; }

    public User(string nickname,string password)
    {
        Nickname = nickname;
        Password = password;
       
    }
}
public class Person
{
    public string Name{get;set; }
    public int Id { get;set; }
    public Person(int id,string name)
    {
        Name = name;
        Id = id;
    }
}
