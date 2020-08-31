using Mathesio.Discussion.BL.Security;
using Mathesio.Discussion.DAL;
using System;
using System.Linq;

namespace Mathesio.Discussion.BL.EntityManagers
{
    public class AuthorManager : IAuthorManager
    {
        private readonly DiscussionContext context;
        private readonly IPasswordHasher passwordHasher;

        public AuthorManager(DiscussionContext context, IPasswordHasher hasher)
        {
            this.context = context;
            passwordHasher = hasher;
        }

        public void CreateAuthor(string name, string password)
        {
            var hash = passwordHasher.Hash(password);
            var author = new Author()
            {
                Name = name,
                PasswordHash = hash
            };
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public bool VerifyAuthor(string name, string password)
        {
            var author = GetAuthor(name);
            return passwordHasher.Check(author.PasswordHash, password);
        }

        // Should fail on duplicates
        // TODO document in unit tests
        public Author GetAuthor(string name)
        {
            return context.Authors.SingleOrDefault(a => a.Name == name);
        }

        public Author GetAuthor(Guid id)
        {
            return context.Authors.FirstOrDefault(a => a.ID == id);
        }

        public bool UpdateAuthorName(Guid authorID, string password, string newName)
        {
            var author = GetAuthor(authorID);
            if (!VerifyAuthor(author.Name, password))
            {
                return false;
            }

            author.Name = newName;
            context.Authors.Update(author);
            context.SaveChanges();
            return true;
        }

        public bool UpdateAuthorPassword(Guid authorID, string password, string newPassword)
        {
            var author = GetAuthor(authorID);
            if (!VerifyAuthor(author.Name, password))
            {
                return false;
            }

            var newHash = passwordHasher.Hash(newPassword);
            author.PasswordHash = newHash;
            context.Authors.Update(author);
            context.SaveChanges();
            return true;
        }

        public void DeleteAuthor(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }
}
