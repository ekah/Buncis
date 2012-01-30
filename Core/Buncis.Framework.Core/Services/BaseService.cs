using System;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Framework.Core.Services
{
    public class BaseService
    {
        protected BaseService()
        {
        }

        protected void UsingTransaction(Action action)
        {
            using (IUnitOfWork unitOfWork = IoC.Resolve<IUnitOfWork>())
            {
                unitOfWork.Begin();
                try
                {
                    action();
                    unitOfWork.Commit();
                }
                catch
                {
                    unitOfWork.Rollback();
                }
            }
        }
    }
}