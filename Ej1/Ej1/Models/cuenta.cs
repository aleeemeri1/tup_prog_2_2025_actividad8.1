using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.Models
{
    class cuenta: IComparable
    {
        public string nombre { get; set; }
        public int dni { get; set; }
        public double importe {  get; set; }
        public cuenta(string nombre, int dni, double importe)
        {
            this.nombre = nombre ;
            this.dni = dni ;
            this.importe = importe ;

        }
        public override string ToString()
        {
            return $"{nombre} ({dni}) {importe:f2}";
        }
        public int CompareTo(object otherObject)
        {
            cuenta other = otherObject as cuenta;
            if (other != null)
            {
                return this.dni.CompareTo(other.dni);
            }
            return -1;
        }
    }
}
