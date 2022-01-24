using E_LEARNING.Models;
using E_LEARNING.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LEARNING.Data;

namespace E_LEARNING.Repository
{
    public class CategorieRepo : IRepoCategorie
    {

        private readonly ApplicationDbContext context;

        public CategorieRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(Categorie entity)
        {
            var categ = context.categories.Add(entity);
             return Save();
        }

        public bool Delete(Categorie entity)
        {
            var categ = context.categories.Remove(entity);
            return Save();
        }

        public List<Categorie> GetAll()
        {
            var categ = context.categories.ToList();
            return categ;
        }

        public Categorie GetByid(int id)
        {
            var categ = context.categories.Find(id);
            return categ;
        }

        public bool IsExist(int id)
        {
            var exist = context.categories.Any(c => c.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = context.SaveChanges();
            return changes > 0;
        }

        public bool Update(Categorie entity)
        {
            var categ = context.categories.Update(entity);
            return Save();
        }
    }
}
