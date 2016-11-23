// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Base
{
    public abstract class O7ViewModel
    {
        protected O7ViewModel()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; }

        public virtual bool ValidViewModel => true;

        public bool IsCorrect => ErrorMessages.Count == 0;
    }
}