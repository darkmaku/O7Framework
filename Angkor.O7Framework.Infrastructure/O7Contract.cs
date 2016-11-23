// Create by Felix A. Bueno
namespace Angkor.O7Framework.Infrastructure
{
    public abstract class O7Contract
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage) && ErrorCode != 0;
    }
}