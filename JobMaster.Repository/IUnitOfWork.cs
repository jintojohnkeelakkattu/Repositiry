using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
