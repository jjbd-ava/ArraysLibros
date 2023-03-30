using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros
{
    class Libro
    {
        private string titulo;
        private string autor;
        private int numPaginas;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int NumPaginas
        {
            get { return numPaginas; }
            set { numPaginas = value; }
        }

        public Libro(string tit, string aut, int npa)
        {
            titulo = tit;
            autor = aut;
            numPaginas = npa;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Autor} - {NumPaginas}";
        }
    }
}
