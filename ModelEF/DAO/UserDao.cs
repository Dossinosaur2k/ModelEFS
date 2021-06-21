using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private DinhTrangContextSV db;
        public UserDao()
        {
            db = new DinhTrangContextSV();
        }
        public int Login (string user,string pass)
        {
            var result = db.Dangnhaps.SingleOrDefault(x => x.users.Contains(user) && x.passwords.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else { return 1; }
        }

    
        public List<Dangnhap> ListAll()
        {
            return db.Dangnhaps.ToList();
        }
        public List<Hangsanxuat> ListAllsp()
        {
            return db.Hangsanxuats.ToList();
        }

        public List<Sanpham> ListAllsp1()
        {
            return db.Sanphams.ToList();
        }
        public IEnumerable<Dangnhap> ListwhereAll(string keysearch,int page ,int pagesize)
        {
            IQueryable<Dangnhap> model = db.Dangnhaps;

            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.users.Contains(keysearch));
            }
            return model.OrderBy(x=>x.users).ToPagedList(page, pagesize);
        }


        public IEnumerable<Sanpham> ListwhereAllsp(string keysearch, int page, int pagesize)
        {
            IQueryable<Sanpham> model = db.Sanphams;
            if (!string.IsNullOrEmpty(keysearch))
               model = model.Where(x => x.Tensp.Contains(keysearch));
            return model.OrderBy(x => x.Masp).ToPagedList(page, pagesize);
        }

        public string Insert(Dangnhap entityDangnhap)
       
        {
            Dangnhap user = new Dangnhap();
            string ten = entityDangnhap.users;
            string mk = entityDangnhap.passwords;
            ten = ten.Trim();
            user.users = ten;
            user.passwords = mk;
            db.Dangnhaps.Add(user);
            db.SaveChanges();
            return user.users;
        }
        public int Insertsp(Sanpham entitySanpham)

        {
            db.Sanphams.Add(entitySanpham);
            db.SaveChanges();
            return entitySanpham.Masp;
        }

        public bool Delete(string username)
        {
            try
            {
                var user = db.Dangnhaps.Find(username);
                db.Dangnhaps.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public Dangnhap Find(string user)
        {
                return db.Dangnhaps.Find(user);
        }

        public Sanpham Find(int id)
        {
            return db.Sanphams.Find(id);
        }
        public object Insert(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
