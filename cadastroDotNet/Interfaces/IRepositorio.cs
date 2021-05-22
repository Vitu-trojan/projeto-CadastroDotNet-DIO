using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDotNet.Interfaces
{
    public interface IRepositorio<V>
    {
        List<V> Lista();
        V RetornarPorId(int id);
        void Insere(V entidade);
        void Exclui(int id);
        void Atualiza(int id, V entidade);
        int ProximoId();
    }
}
