﻿using System;

namespace PruebaUnitariaBuscaminas
{
    internal class GamerName
    {
        public GamerName()
        {
        }

        internal object Add(string name)
        {
            //Validar el nombre
            if (string.IsNullOrEmpty(name))
                throw new NotImplementedException();

            return name;
        }
    }
}