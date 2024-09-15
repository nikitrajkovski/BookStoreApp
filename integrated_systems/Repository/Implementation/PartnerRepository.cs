﻿using BookStore.Data;
using Domain.Partner;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class PartnerRepository<T> : IPartnerRepository<T> where T : BaseEntity
    {

        private readonly SecondTeamDbContext context;
        private DbSet<T> entities;

        public PartnerRepository(SecondTeamDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Book))
            {
                return entities
                    .Include(z => ((Book)(object)z).Publisher)
/*                    .Include("Publisher.Name")
*/                    .AsEnumerable();
            }
            return entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
/*            if (typeof(T) == typeof(Book))
            {
                return entities
                    .Include(z => ((Book)(object)z).Authors)
                    .Include(z => ((Book)(object)z).Publisher)
                    .SingleOrDefault(z => z.Id == id);
            }
            if (typeof(T) == typeof(BookInShoppingCart))
            {
                return entities
                    .Include(z => ((BookInShoppingCart)(object)z).Book)
                    .SingleOrDefault(z => z.Id == id);
            }*/
            return entities.SingleOrDefault(z => z.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public List<T> InsertMany(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }
    }
}
