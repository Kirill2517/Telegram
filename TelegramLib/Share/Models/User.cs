namespace HhLib.Share.Models
{
    public abstract class User : Object
    {
        public DataUser.model.DataUser DataUser { get; set; }

        public override bool IsValid()
        {
            return DataUserIsValid;
        }

        protected bool DataUserIsValid => DataUser != null && DataUser.IsValid();
    }
}
