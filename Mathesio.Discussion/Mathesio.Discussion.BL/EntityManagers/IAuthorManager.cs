using Mathesio.Discussion.DAL;
using System;

namespace Mathesio.Discussion.BL.EntityManagers
{
    public interface IAuthorManager
    {
        void CreateAuthor(string name, string password);
        void DeleteAuthor(Author author);
        Author GetAuthor(Guid id);
        Author GetAuthor(string name);
        bool UpdateAuthorName(Guid authorID, string password, string newName);
        bool UpdateAuthorPassword(Guid authorID, string password, string newPassword);
        bool VerifyAuthor(string name, string password);
    }
}