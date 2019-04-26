using GoodLife_Asp.Models;
using GoodLife_Asp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodLife_Asp.Repository
{
    public class GoodLifeRepository : IGoodLife
    {
        private AppDbContext db;
        public GoodLifeRepository(AppDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<GoodLife> GetMembers => db.GoodLife;

        public void Add(GoodLife _member)
        {
            db.GoodLife.Add(_member);
            db.SaveChanges();
        }

        public GoodLife GetMember(int Id)
        {
            GoodLife dbEntity = db.GoodLife.Find(Id);
            return dbEntity;
        }

        public void remove(int Id)
        {
            GoodLife dbEntity = db.GoodLife.Find(Id);
            db.GoodLife.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
