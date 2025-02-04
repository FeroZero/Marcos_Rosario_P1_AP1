using Marcos_Rosario_P1_AP1.DAL;
using Marcos_Rosario_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Marcos_Rosario_P1_AP1.Services
{
    public class Services(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Modelos modelo)
        {
            return true;
        }

        private async Task<bool> Existe(int id)
        {
            return true;
        }

        private async Task<bool> Modificar(Modelos modelo)
        {
            return true;
        }

        private async Task<bool> Insertar(Modelos modelos)
        {
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

        public async Task<Modelos?> Buscar(int id)
        {
            return null;
        }
        
        public async Task<List<Modelos>> Listar(Expression<Func<Modelos, bool>> criterio)
        {
            return null;
        }
    }
}
