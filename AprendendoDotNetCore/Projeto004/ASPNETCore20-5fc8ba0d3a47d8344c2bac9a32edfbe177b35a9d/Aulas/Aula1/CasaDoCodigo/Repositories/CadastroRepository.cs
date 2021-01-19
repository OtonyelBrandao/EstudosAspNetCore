using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int CadastroId, Cadastro novoCadastro);
    }
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(AplicationContext context) : base(context)
        {
        }

        public Cadastro Update(int CadastroId, Cadastro novoCadastro)
        {
            var cadastroDB =
                dbSet.Where(c => c.Id == CadastroId)
                .SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            context.SaveChanges();
            return cadastroDB;
        }
    }
}
