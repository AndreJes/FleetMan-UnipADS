using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Usuarios.Permissoes;

namespace Modelo.Classes.Usuarios
{
    class UsuarioFunc : Usuario
    {
        Permissoes.Permissoes Permissoes { get; set; }
    }
}
