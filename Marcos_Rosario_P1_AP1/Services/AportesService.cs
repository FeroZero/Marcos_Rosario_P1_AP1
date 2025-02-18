using Marcos_Rosario_P1_AP1.DAL;
using Marcos_Rosario_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Marcos_Rosario_P1_AP1.Services
{
    public class AportesService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Aportes aporte)
        {
            if (!await Existe(aporte.AporteId))
                return await Insertar(aporte);
            else
                return await Modificar(aporte);
        }

        private async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .AnyAsync(o => o.AporteId == id);
        }

        private async Task<bool> Modificar(Aportes modelo)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(modelo);
            return await contexto.SaveChangesAsync() > 0;
		}

        private async Task<bool> Insertar(Aportes modelos)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Aportes.Add(modelos);
            return await contexto.SaveChangesAsync() > 0;
		}

        public async Task<bool> Eliminar(int id)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .Where(o => o.AporteId == id).ExecuteDeleteAsync() > 0;
		}

        public async Task<Aportes?> Buscar(int id)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .FirstOrDefaultAsync(o  => o.AporteId == id);
		}
        
        public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .Where(criterio)
                .ToListAsync();
		}

        public async Task<bool> Validar(string nombre, int id)
        {
			await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes.AnyAsync(o => o.Personas.ToLower().Equals(nombre.ToLower()) && o.AporteId == id);
		}
    }
}
