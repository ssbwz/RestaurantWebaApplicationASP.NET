using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma
{
    public class NormalItemOTD : ItemOTD
    {
        public NormalItemOTD(string name, string description, double price,Category category) : base(name, description, price, category)
        {
        }

        public NormalItemOTD() { }

        public override double Price
        { get => Math.Round(base.Price, 2); set => base.Price = value; }

    }
}
