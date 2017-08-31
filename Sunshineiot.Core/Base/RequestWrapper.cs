using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Dynamic;
using System.Security.Principal;
using Sunshineiot.Core;
using Newtonsoft.Json.Linq;

namespace Sunshineiot.Core
{
    public class RequestWrapper
    {

        private NameValueCollection request { get; set; }
        public string this[string name]
        {
            get
            {
                var field = name;
                if (name.IndexOf(".") >= 0)
                    field = name.Split('.')[1];
                return request[field];
            }
            set
            {
                if (name.IndexOf(".") >= 0)
                    name = name.Split('.')[1];
                request[name] = value;
            }
        }

        public bool ContainKey(string name)
        {
            return request.AllKeys.Contains(name);
        }

        public IPrincipal User { get; set; }

        #region 构造函数
        public RequestWrapper(NameValueCollection query)
        {
            this.SetRequestData(query);
        }

        public RequestWrapper()
        {
            this.SetRequestData(new NameValueCollection());
        }

        public static RequestWrapper Instance()
        {
            return new RequestWrapper();
        }

        public static RequestWrapper InstanceFromRequest()
        {
            var request = new NameValueCollection(HttpContext.Current.Request.QueryString);
            return new RequestWrapper(request);
        }
        public RequestWrapper LoadSetting(string tableName)
        {

            return this;
        }

        #endregion

        public RequestWrapper SetRequestData(NameValueCollection values)
        {
            this.request = values;
            return this;
        }

        public RequestWrapper SetRequestData(JToken values)
        {
            if (values != null)
            {
                foreach (JProperty item in values.Children())
                    if (item != null) this[item.Name] = item.Value.ToString();
            }
            return this;
        }

        public RequestWrapper SetRequestData(string name, string value)
        {
            this[name] = value;
            return this;
        }

        public dynamic ToDynamic()
        {
            var expando = (IDictionary<string, object>)new ExpandoObject();
            foreach (string key in this.Except())
                expando.Add(key, this[key]);

            return expando;
        }

        private List<string> ignores = new List<string> { null, "page", "rows", "sort", "order", "format", "FLUENTDATA_ROWNUMBER" };
        private string ignoreStartWith = "_";
        public IEnumerable<string> Except(List<string> keys = null)
        {
            var result = request.AllKeys
                       .Except(ignores)
                       .Except(keys ?? new List<string>())
                       .Where(x => !x.StartsWith(ignoreStartWith));

            return result;
        }

        private string tableName;



        private void parseColumns(Action<string, object> Column)
        {
            foreach (var key in this.Except(ignores))
            {
                Column(key, this[key]);
            }
        }




        #region ToParamQuery
        public ParamQuery ToParamQuery()
        {

            var pQuery = ParamQuery.Instance();

            //获取分页及排序信息
            var page = parseInt(this.request["page"], 1);
            var rows = parseInt(this.request["rows"], 0);
            pQuery.Paging(page, rows);

            return pQuery;
        }

        private int parseInt(string str, int defaults = 0)
        {
            int value;
            if (!int.TryParse(str, out value)) value = defaults;
            return value;
        }
        #endregion

    }
}
