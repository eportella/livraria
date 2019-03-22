namespace Livraria.Autor
{
    using System;
    using System.Linq.Expressions;

    public static class Expression
    {
        public static Expression<Func<EntityFramework.Autor.Model, bool>> NomeHas(string autor) =>
            s => s.Nome == autor;
    }
}
