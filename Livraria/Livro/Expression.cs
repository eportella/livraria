namespace Livraria.Livro
{
    using System;
    using System.Linq.Expressions;

    public static class Expression
    {
        public static Expression<Func<EntityFramework.Livro.Model, bool>> ISBNHas(Interface @interface) =>
            s => s.ISBN == @interface.ISBN;
    }
}
