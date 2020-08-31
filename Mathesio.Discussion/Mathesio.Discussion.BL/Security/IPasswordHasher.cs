namespace Mathesio.Discussion.BL.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
