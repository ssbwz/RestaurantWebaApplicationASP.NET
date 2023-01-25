using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma
{
    public class SummerItemOTD : ItemOTD
    {
        public SummerItemOTD(string name, string description, double price,Category category) : base(name, description, price,category)
        {
        }

        public SummerItemOTD() 
        { }
        public override double Price { get => Math.Round(base.Price,2); set => base.Price = value ; }
        }
    }


