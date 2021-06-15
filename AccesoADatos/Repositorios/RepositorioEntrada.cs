﻿using AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class RepositorioEntrada : RepositorioBase<Entrada>
    {
        private readonly MueseoBaseEntities _baseDeDatos = new MueseoBaseEntities();

        public bool ActualizarEntidad(Entrada entidad)
        {
            if (entidad != null)
            {
                var entidadBase = _baseDeDatos.Entrada.FirstOrDefault(x => x.Id == entidad.Id);

                entidad.Id = entidad.Id;

                _baseDeDatos.SaveChanges();
                return true;
            }
            return false;
        }

        public bool BorrarEntidad(Entrada entidad)
        {
            if (entidad != null)
            {
                var entidadBase = _baseDeDatos.Entrada.FirstOrDefault(x => x.Id == entidad.Id);
                _baseDeDatos.Entrada.Remove(entidadBase);
                return true;
            }

            return false;
        }

        public Entrada GuardarEntidad(Entrada entidad)
        {
            if (entidad != null)
            {
                _baseDeDatos.Entrada.Add(entidad);
                _baseDeDatos.SaveChanges();
                return entidad;
            }

            return new Entrada();
        }

        public List<Entrada> Listar()
        {
            return _baseDeDatos.Entrada.ToList();
        }
    }
}
