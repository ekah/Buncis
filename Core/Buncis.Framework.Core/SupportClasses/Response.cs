using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.SupportClasses
{
	public class Response
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }

        public Response(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public Response()
        {

        }
	}

	public class Response<T> : Response where T : class
	{
		public T ResponseObject { get; set; }
	}
}
