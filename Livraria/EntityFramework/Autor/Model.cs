namespace Livraria.EntityFramework.Autor
{
    using System.Collections.Generic;
    public class Model
    {
        internal Model() : base()
        {
            Livro = new HashSet<Livro.Model>();
        }
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro.Model> Livro { get; set; }
    }
}