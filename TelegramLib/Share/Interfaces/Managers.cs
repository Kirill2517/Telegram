using TelegramLib.Share.Models;
using System.Threading.Tasks;

namespace TelegramLib.Share.Interfaces
{
    public interface IStore<TObject>
        where TObject : Models.Object
    {
        TObject GetModelById(object id);
        TObject[] GetAllModels();
    }

    public interface IUserStore<TUser> : IStore<TUser>
        where TUser : User
    {
        Task<DataUser.model.DataUser> GetDataUserAsync();
    }

    public interface IErrorStore : IStore<ErrorModel>
    {
        ErrorModel[] GetUserErrors(string email);
    }

    public interface IStoreUsers
    {
        IUserStore<Applicant.model.Applicant> Applicants { get; set; }
        IUserStore<Employer.model.Employer> Empoyers { get; set; }
    }
}
