using System;

namespace Buncis.Services.Url
{
	public interface IUrlEngine<T> where T : class
	{
		int ModuleId { get; }
		string GenerateUrl(int id, string title, DateTime date);
		string ResolveUrl(string friendlyUrl);
	}
}
