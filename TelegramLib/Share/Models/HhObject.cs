namespace TelegramLib.Share.Models
{
    public abstract class Object
    {
        public virtual bool IsValid()
        {
            return true;
        }
    }
}
