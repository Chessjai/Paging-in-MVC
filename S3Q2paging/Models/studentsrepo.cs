using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3Q2paging.Models
{
    public class studentsrepo
    {
        dbcontext db = new dbcontext();
        Studentmodel std1 = new Studentmodel();

        public List<Studentmodel> GetAllStd()
        {
            List<Studentmodel> Std = new List<Studentmodel>();
            Std = db.models.ToList();
            return Std;
        }
        public void Create(Studentmodel std)
        {
            DateTime Age = std.dob;
            int j = Age.Year;
            DateTime now = DateTime.Now;
            int k = now.Year;
            int age = k - j;
            std.age = age;
            std.created_on = now;
            std.update_on = now;
            db.models.Add(std);
            db.SaveChanges();
        }
        public Studentmodel Edit(Studentmodel std)
        {
            DateTime Age = std.dob;
            int j = Age.Year;
            DateTime now = DateTime.Now;
            int k = now.Year;
            int age = k - j;
            std.age = age;
            std.update_on = now;
            std.created_on = now;
            db.Entry(std).State = EntityState.Modified;
            db.SaveChanges();
            return std;
        }

        public Studentmodel FinedById(int id)
        {
            Studentmodel student = db.models.Find(id);
            return student;
        }
        public Studentmodel Delete(int id)
        {
            Studentmodel student = db.models.Find(id);
            Studentmodel stud = db.models.Remove(student);
            db.SaveChanges();
            return student;
        }

    }
}