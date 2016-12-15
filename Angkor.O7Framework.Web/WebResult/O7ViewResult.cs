// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Framework.Web.WebResult
{
    public class O7ViewResult : ViewResult
    {
        public O7ViewResult(O7ViewModel viewModel)
        {
            ViewData.Model = viewModel;            
        }
    }
}