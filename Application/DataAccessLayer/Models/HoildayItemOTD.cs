﻿using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma
{
    public class HoildayItemOTD : ItemOTD
    {
        public HoildayItemOTD( string name, string description, double price, Category category) : base(name, description, price, category)
        {
        }

        public HoildayItemOTD() 
        { }

        public override double Price { get => Math.Round(base.Price, 2); set => base.Price = value; }


    }
}
