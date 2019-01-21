using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS1.Models
{
    public class TelefonsRepository
    {
        private static contactes2Entities dataContext = new contactes2Entities();
        public static List<telefon> GetAllTelefons()
        {
            List<telefon> lc = dataContext.telefon.ToList();
            return lc;
        }

        public static telefon GetTelefon(int contacteID)
        {
            telefon c = dataContext.telefon.Where(x => x.contacteId == contacteID).SingleOrDefault();
            return c;
        }

        public static List<telefon> SearchTelefonByName(string telefon)
        {
            List<telefon> lc = dataContext.telefon.Where(x => x.telefon1.Contains(telefon)).ToList();
            return lc;
        }
        public static telefon InsertTelefon(telefon t)
        {
            try
            {
                dataContext.telefon.Add(t);
                dataContext.SaveChanges();
                return GetTelefon(t.contacteId.Value);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static telefon UpdateTelefon(int id, telefon c)
        {
            try
            {
                telefon c0 = dataContext.telefon.Where(x => x.contacteId == id).SingleOrDefault();
                if (c.telefon1 != null) c0.telefon1 = c.telefon1;
                if (c.tipus != null) c0.tipus = c.tipus;

                dataContext.SaveChanges();
                return GetTelefon(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteTelefon(int id)
        {
            telefon c = dataContext.telefon.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                dataContext.telefon.Remove(c);
                dataContext.SaveChanges();
            }
        }
    }
}