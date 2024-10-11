using System.Collections.Generic;

namespace E2.Interfaces;

public interface IInventario
{
    void AdicionarFilme();
    void RemoverFilme();
    IFilme ConsultarFilme(int filmeId);
    IEnumerable<IFilme> ListarTodosFilmes();
}