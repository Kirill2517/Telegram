namespace TelegramLib.Share.Models
{
    public abstract class GuidManagerBase : DataBaseController
    {
        protected override string sqlPathFolder => base.sqlPathFolder + "/Guid";
    }
}
