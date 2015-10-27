using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        InventoryManagementContext dbContext;

        public InventoryManagementContext Init()
        {
            return dbContext ?? (dbContext = new InventoryManagementContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
