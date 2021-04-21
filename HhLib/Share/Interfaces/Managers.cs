using HhLib.DataBaseImage;
using HhLib.Employer.model;
using HhLib.Share.models;
using HhLib.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Interfaces
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
