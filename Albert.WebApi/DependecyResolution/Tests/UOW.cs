using Albert.Common.Interfaces;
using Albert.DataLayer;
using Microsoft.EntityFrameworkCore;
using Yoda.EntityFramework;

namespace Albert.WebApi.DependencyResolution.Tests
{
    public class AlbertUOW : EFUnitOfWork
    {
        private IQuerySpecFactory _qfac = new AlbertQuerySpecFac();

        public AlbertUOW(Microsoft.EntityFrameworkCore.Infrastructure.IDbContextFactory<DbContext> contextFactory) : base(contextFactory) { }

        public override TQuerySpec GetQuerySpec<TQuerySpec>()
        {
            return _qfac.Create<TQuerySpec>(new object[] { this._context as SchoolContext }) as TQuerySpec;
        }
    }

    class AlbertQuerySpecFac : IQuerySpecFactory
    {
        TQuerySpec IQuerySpecFactory.Create<TQuerySpec>(object[] args)
        {
            if (typeof(TQuerySpec) == typeof(IStudentQuerySpec)) return new StudentQuerySpec(args[0] as SchoolContext) as TQuerySpec;
            if (typeof(TQuerySpec) == typeof(ICourseQuerySpec)) return new CourseQuerySpec(args[0] as SchoolContext) as TQuerySpec;
            return default(TQuerySpec);
        }
    }
}