using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS1.Models
{
    public class ContactesRepository
    {
        private static contactes2Entities dataContext = new contactes2Entities();
        public static List<contacte> GetAllContactes()
        {
            List<contacte> lc = dataContext.contacte.ToList();
            return lc;
        }

        public static contacte GetContacte(int contacteID)
        {
            contacte c = dataContext.contacte.Where(x => x.contacteId == contacteID).SingleOrDefault();
            return c;
        }
        public void prueba()
        {
            int a = 0;
        }
        public static List<contacte> SearchContactesByName(string contacteName)
        {
            List<contacte> lc = dataContext.contacte.Where(x => x.nom.Contains(contacteName) || x.cognoms.Contains(contacteName)).ToList();
            return lc;
        }
        public static contacte InsertContacte(contacte c)
        {
            try
            {
                dataContext.contacte.Add(c);
                dataContext.SaveChanges();
                return GetContacte(c.contacteId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static contacte UpdateContacte(int id, contacte c)
        {
            try
            {
                contacte c0 = dataContext.contacte.Where(x => x.contacteId == id).SingleOrDefault();
                if (c.nom != null) c0.nom = c.nom;
                if (c.cognoms != null) c0.cognoms = c.cognoms;

                dataContext.SaveChanges();
                return GetContacte(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteContacte(int id)
        {
            contacte c = dataContext.contacte.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                dataContext.contacte.Remove(c);
                dataContext.SaveChanges();
            }
        }

    }
}