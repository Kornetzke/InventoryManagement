﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        InventoryManagementContext Init();
    }
}
