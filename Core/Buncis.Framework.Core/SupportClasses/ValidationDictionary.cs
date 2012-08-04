using System.Collections.Generic;
using System.Text;

namespace Buncis.Framework.Core.SupportClasses
{
    public class ValidationDictionary<TObjectType> where TObjectType : class
    {
        private readonly Dictionary<string, string> _validationSummary;
        public Dictionary<string, string> ValidationSummary
        {
            get
            {
                return _validationSummary;
            }
        }
        public bool IsValid { get; set; }
        public TObjectType RelatedObject { get; set; }

        public ValidationDictionary()
        {
            _validationSummary = new Dictionary<string, string>();
        }

        public void AddError(string key, string message)
        {
            _validationSummary.Add(key, message);
        }

        public string ValidationSummaryToString()
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var item in _validationSummary)
            {
                sb.AppendFormat("<li>{0}</li>", item.Value);

            }
            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}
