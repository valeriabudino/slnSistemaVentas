﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Cliente : Persona
    {
        public Cliente(int id, string nombre, string apellido, string dni): base(id, nombre, apellido, dni)
        {

        }
    }
}
