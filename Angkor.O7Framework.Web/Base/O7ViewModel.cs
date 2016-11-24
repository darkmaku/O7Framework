// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Base
{
    public abstract class O7ViewModel
    {
        protected O7ViewModel()
        {
            ValidationErrorMessages = new List<string>();
        }

        public List<string> ValidationErrorMessages { get; }
        public virtual bool ValidViewModel => true;

        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public bool IsCorrect => !string.IsNullOrEmpty(ErrorMessage) && ErrorCode == 0;
    }
}