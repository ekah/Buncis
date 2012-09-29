using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace Buncis.Web.Open
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProvider" in code, svc and config file together.
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class ServiceProvider : IServiceProvider
	{
		public IEnumerable<Provider> GetProvider(float langitude, float latitude)
		{
			var providers = new List<Provider>();
			providers.Add(new Provider
			{
				ContactName = "John Doe",
				ContactNumber = "0823495",
				Email = "john.doe@blogs.com",
				Langitude = langitude + 2,
				Latitude = latitude + 3,
				ServiceProviderId = 10,
				ServiceProviderName = "Plumbing Limited"
			});
			providers.Add(new Provider
			{
				ContactName = "Arnold Bigs",
				ContactNumber = "0543943",
				Email = "arnold.bigs@gibs.com",
				Langitude = langitude + 4,
				Latitude = latitude + 2,
				ServiceProviderId = 11,
				ServiceProviderName = "Closet Corp"
			});
			providers.Add(new Provider
			{
				ContactName = "Marry Lone",
				ContactNumber = "043643",
				Email = "marry.lone@louds.com",
				Langitude = langitude + 5,
				Latitude = latitude + 7,
				ServiceProviderId = 12,
				ServiceProviderName = "Loud Cleaning Ltd"
			});

			return providers;
		}

		public IEnumerable<ProviderCategory> GetCategories()
		{
			var categories = new List<ProviderCategory>();
			categories.Add(new ProviderCategory
			{
				CategoryId = 1,
				CategoryDescription = "Plumbing"
			});
			categories.Add(new ProviderCategory
			{
				CategoryId = 2,
				CategoryDescription = "Cleaning"
			});
			categories.Add(new ProviderCategory
			{
				CategoryId = 3,
				CategoryDescription = "Automotive"
			});
			categories.Add(new ProviderCategory
			{
				CategoryId = 4,
				CategoryDescription = "Commercial"
			});
			categories.Add(new ProviderCategory
			{
				CategoryId = 5,
				CategoryDescription = "Sales"
			});
			return categories;
		}
	}
}
