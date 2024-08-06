using System.Collections.Generic;
using E2.Interfaces;

namespace E2.Classes;

public class Inventario: IInventario
{
    public void AdicionarFilme(IFilme filme)
    {
        throw new System.NotImplementedException();
    }

    public void RemoverFilme(int filmeId)
    {
        throw new System.NotImplementedException();
    }

    public IFilme ConsultarFilme(int filmeId)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<IFilme> ListarTodosFilmes()
    {
        throw new System.NotImplementedException();
    }
}