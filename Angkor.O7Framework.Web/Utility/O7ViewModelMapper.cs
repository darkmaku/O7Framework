// Create by Felix A. Bueno

using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Framework.Web.Utility
{
    public abstract class O7ViewModelMapper<TViewModel, TDomainResponse> where TViewModel : O7ViewModel
    {
        public TViewModel MapViewModel(TDomainResponse response)
            => MapperDetail(response);

        protected abstract TViewModel MapperDetail(TDomainResponse response);

    }
}