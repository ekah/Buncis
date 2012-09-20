using System;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.DailyBread;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Repository.DailyBread;
using Buncis.Data.Domain.DailyBread;

namespace Buncis.Services.DailyBread
{
	public class DailyBreadService : BaseService, IDailyBreadService
	{
		private readonly IDailyBreadItemRepository _dailyBreadItemRepository;

		public DailyBreadService(IDailyBreadItemRepository dailyBreadItemRepository)
		{
			_dailyBreadItemRepository = dailyBreadItemRepository;
		}

		public IEnumerable<ViewModelDailyBreadItem> GetAvailableDailyBreadItems(int clientId)
		{
			var raw = _dailyBreadItemRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelDailyBreadItem = new ViewModelDailyBreadItem();
				viewModelDailyBreadItem.InjectFrom(item);
				return viewModelDailyBreadItem;
			}).ToList();

			return converted;
		}

		public ViewModelDailyBreadItem GetDailyBreadItem(int dailyBreadId)
		{
			var raw = _dailyBreadItemRepository.FindBy(o => !o.IsDeleted && o.DailyBreadId == dailyBreadId);

			var viewModelDailyBreadItem = new ViewModelDailyBreadItem();
			viewModelDailyBreadItem.InjectFrom(raw);

			return viewModelDailyBreadItem;
		}

		public ValidationDictionary<ViewModelDailyBreadItem> DeleteDailyBreadItem(int dailyBreadId)
		{
			var raw = _dailyBreadItemRepository.FindBy(o => o.DailyBreadId == dailyBreadId);

			var validator = new ValidationDictionary<ViewModelDailyBreadItem>();

			if (raw != null)
			{
				raw.IsDeleted = true;

				_dailyBreadItemRepository.Update(raw);

				validator.IsValid = true;
			}
			else
			{
				validator.IsValid = false;
				validator.AddError("", "The XX is not available in the database");
			}

			return validator;
		}

		public ValidationDictionary<ViewModelDailyBreadItem> SaveDailyBreadItem(int clientId, ViewModelDailyBreadItem dailyBread)
		{
			var validator = new ValidationDictionary<ViewModelDailyBreadItem>();
			if (dailyBread == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The XX you're trying to save is null");
				return validator;
			}

			// rule based here


			DailyBreadItem dailyBreadItem;

			if (dailyBread.DailyBreadId <= 0)
			{
				dailyBreadItem = new DailyBreadItem();
				dailyBreadItem.InjectFrom(dailyBread);
				dailyBreadItem.DateCreated = DateTime.UtcNow;
				dailyBreadItem.DateLastUpdated = DateTime.UtcNow;
				dailyBreadItem.ClientId = clientId;

				_dailyBreadItemRepository.Add(dailyBreadItem);
			}
			else
			{
				dailyBreadItem = _dailyBreadItemRepository.FindBy(o => !o.IsDeleted && o.DailyBreadId == dailyBread.DailyBreadId);
				if (dailyBreadItem != null)
				{
					var createdDate = dailyBreadItem.DateCreated;
					dailyBreadItem.InjectFrom(dailyBread);
					dailyBreadItem.DateLastUpdated = DateTime.UtcNow;
					dailyBreadItem.DateCreated = createdDate;
					dailyBreadItem.IsDeleted = false;

					_dailyBreadItemRepository.Update(dailyBreadItem);
				}
			}

			var pinged = GetDailyBreadItem(dailyBreadItem.DailyBreadId);
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
		}
	}
}
