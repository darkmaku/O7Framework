// Create by Felix A. Bueno

using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Framework.Web.Utility
{
    public abstract class O7ViewModelMapper<TViewModel> : O7Mapper<O7Response, TViewModel>
        where TViewModel : O7ViewModel
    {

    }
}