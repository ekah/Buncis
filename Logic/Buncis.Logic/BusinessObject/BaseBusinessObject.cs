using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Logic.BusinessObject
{
    public abstract class BaseBusinessObject<T> where T : class
    {
        public T ToInsert { get; set; }
        public T Editable { get; set; }
        public int Key { get; set; }
        public int KeyToDelete { get; set; }
        public List<T> List { get; set; }

        public abstract Response<T> Insert();
        public abstract Response<T> Update();
        public abstract Response Delete();

        public abstract Response GetList();
        public abstract Response GetEditableByKey();

        public abstract void SetupNewObjectToInsert();

        public abstract bool ValidateBeforeInsert();
        public abstract bool ValidateBeforeUpdate();
    }
}
