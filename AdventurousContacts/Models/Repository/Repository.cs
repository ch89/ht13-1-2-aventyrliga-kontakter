using ContactLab.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactLab.Models.Repository
{
    public class Repository : IRepository
    {
        private Entities entities = new Entities();

        public IEnumerable<Contact> GetContacts(int count = 0)
        {
            if (count == 0)
            {
                return entities.Contacts.ToList();
            }

            return entities.Contacts.OrderByDescending(m => m.ContactID).Take(count);
        }

        public void AddContact(Contact contact)
        {
            entities.Contacts.Add(contact);
        }

        public Contact GetContactById(int id)
        {
            return entities.Contacts.Find(id);
        }

        public void UpdateContact(Contact contact)
        {
            entities.Entry(contact).State = EntityState.Modified;
        }

        public void DeleteContact(int id)
        {
            entities.Contacts.Remove(entities.Contacts.Find(id));
        }

        public void Save()
        {
            entities.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}