using EmreAydogduoglu.Core.Data.Concrete.EntityFramework;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Data.Concrete.EntityFramework.Context;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person,EmreContext>, IPersonDal
    {
    }
}
