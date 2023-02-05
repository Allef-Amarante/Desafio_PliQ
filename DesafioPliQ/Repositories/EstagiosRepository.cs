using DesafioPliQ.AppDbContext;
using DesafioPliQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPliQ.Repositories
{
    public class EstagiosRepository : IEstagiosRepository
    {
        public readonly EstagiosDbContext _Context;
        public EstagiosRepository(EstagiosDbContext context)
        {
            _Context = context;
        }

        public async Task<EstagiosCRM> Create(EstagiosCRM estagios)
        {
            var checkNome = _Context.Estagios.Any(e => e.Name.ToLower() == estagios.Name.ToLower());
            if (checkNome)
            {
                throw new Exception($"O nome {estagios.Name}, já esta em uso. Adicione outro");
            }
            _Context.Estagios.Add(estagios);
            await _Context.SaveChangesAsync();
            return estagios;
        }

        public async Task<EstagiosCRM> Delete(int id)
        {
            var toDelete = await _Context.Estagios.FindAsync(id);
            if (toDelete == null)
            {
                throw new Exception();
            }
            else
            {
                _Context.Estagios.Remove(toDelete);
                await _Context.SaveChangesAsync();
                return toDelete;
            }
        }

        public async Task<EstagiosCRM> Get(int id)
        {
            return await _Context.Estagios.FindAsync(id);
        }

        public async Task<IEnumerable<EstagiosCRM>> ListOrder()
        {
            return await _Context.Estagios.OrderBy(c => c.Priority).ToListAsync();
        }

        public async Task<EstagiosCRM> Update(EstagiosCRM estagios)
        {
            _Context.Entry(estagios).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return estagios;
        }
    }   
}
