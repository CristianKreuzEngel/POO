using System.Collections.Generic;

namespace E2.Interfaces;

public interface IInventario
{
    void AdicionarFilme(IFilme filme);
    void RemoverFilme(int filmeId);
    IFilme ConsultarFilme(int filmeId);
    IEnumerable<IFilme> ListarTodosFilmes();
}