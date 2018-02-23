using System;
using System.Collections.Generic;
using System.Linq;
using Angkor.O7Framework.Common.Model;

namespace Angkor.O7Framework.Utility
{
    public class DataTableAjaxPostModel
    {

        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }

        public class Column
        {
            public string data { get; set; }
            public string name { get; set; }
            public bool searchable { get; set; }
            public bool orderable { get; set; }
            public Search search { get; set; }
        }
        public class Search
        {
            public string value { get; set; }
            public string regex { get; set; }
        }
        public class Order
        {
            public int column { get; set; }
            public string dir { get; set; }
        }
    }
    public class PaginationResult
    {

        // properties are not capital due to json mapping
        public object Result { get; set; }
        public int FilteredItems { get; set; }
        public int TotalItems { get; set; }

    }
    public class O7DatatablesManager
    {
        List<T> GetValues<T>(Func<string[], O7Response> method, List<string> parameters, out int totalResultsCount, out int filteredResultsCount)
        {
            object[] args = { parameters.ToArray() };
            var response = (O7Response)method.DynamicInvoke(args);

            var successResponse = response as O7SuccessResponse<PaginationResult>;
            if (successResponse == null)
            {
                var errorResponse = response as O7ErrorResponse;
                var mensaje = errorResponse.Message;
                totalResultsCount = 0;
                filteredResultsCount = 0;
                return new List<T>();
            }
            var paginationresult = successResponse.Value1;
            var result = (List<T>)paginationresult.Result;
            totalResultsCount = paginationresult.TotalItems;
            filteredResultsCount = paginationresult.FilteredItems;

            return result;
        }
        List<T> GetDataFromDbase<T>(Func<string[], O7Response> method, List<string> parameters, out int filteredResultsCount, out int totalResultsCount)
        {

            var result = GetValues<T>(method, parameters, out totalResultsCount, out filteredResultsCount);

            return result;
        }

        public IList<T> SearchValues<T>(Func<string[], O7Response> method, List<string> parameters, DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            if (model.order != null)
            {
                // in this example we just default sort on the 1st column
                sortBy = model.columns[model.order[0].column].data;
                sortDir = model.order[0].dir.ToLower() == "asc";
            }

            // search the dbase taking into consideration table sorting and paging
            parameters.Add(skip.ToString());
            parameters.Add(take.ToString());
            if (searchBy != null)
                parameters.Add(searchBy.ToString());
            else
                parameters.Add("");
            if (sortBy != null)
                parameters.Add(sortBy.ToString());
            else
                parameters.Add("");
            parameters.Add(sortDir.ToString());
            var result = GetDataFromDbase<T>(method, parameters, out filteredResultsCount, out totalResultsCount);
            if (result == null)
            {
                return new List<T>();
            }
            return result;
        }

        
    }
}
