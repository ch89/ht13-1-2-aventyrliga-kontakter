using System;
using System.Collections.Generic;

namespace ContactLab.Models.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Contact> GetContacts(int count = 0);
        Contact GetContactById(int id);
        void AddContact(Contact birthday);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        void Save();
    }
}
