using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Context;

namespace Switch.Infra.Data.Uow
{
    public class Uow : IUow
    {
        private readonly SwitchContext _context;

        public Uow(SwitchContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
