using System.Collections.Generic;
using System.Threading.Tasks;

namespace HhLib.Share.Models
{
    public interface IResult<TError>
        where TError : class
    {
        public bool Successed { get; set; }
        public IEnumerable<TError> Errors { get; set; }
    }
    public class IdentityResult : IResult<ErrorModel>
    {
        public bool Successed { get; set; }
        public IEnumerable<ErrorModel> Errors { get; set; }
        public IdentityResult(IEnumerable<ErrorModel> errors)
        {
            Errors = errors;
        }
        public IdentityResult()
        {

        }
        public static IdentityResult Failed(IEnumerable<ErrorModel> errors)
        {
            return new IdentityResult(errors) { Successed = false };
        }
    }

    public interface IIdentityValidator<in T>
    {
        Task<IdentityResult> ValidateAsync(T item);
    }

    public class ErrorModel : Object
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }
}
