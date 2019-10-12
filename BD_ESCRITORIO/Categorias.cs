using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_ESCRITORIO
{
    class Categorias
    {
        private int v;
        private string text;

        public int id { get; set; }
        public String nombretipo { get; set; }
        public String imagen { get; set; }

        public Categorias() { }
        public Categorias(int _id,String _nombretipo, String _imagen) {
            id = _id;
            nombretipo = _nombretipo;
            imagen = _imagen;
        }

        public Categorias(int v, string text)
        {
            this.v = v;
            this.text = text;
        }
    }
}