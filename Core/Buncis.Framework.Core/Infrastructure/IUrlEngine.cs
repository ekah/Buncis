using System;

namespace Buncis.Framework.Core.Infrastructure
{
	public interface IUrlEngine<T> where T : class
	{
		int ModuleId { get; }
		string GenerateUrl(int id, string title, DateTime date);
		string ResolveUrl(string friendlyUrl);
	}
}
