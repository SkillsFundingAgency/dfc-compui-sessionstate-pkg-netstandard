using System;
using System.Net;
using System.Threading.Tasks;

namespace DFC.Compui.Sessionstate
{
    public interface ISessionStateService<TModel>
        where TModel : class, new()
    {
        Task<bool> DeleteAsync(Guid compositeSessionId);

        Task<SessionStateModel<TModel>> GetAsync(Guid compositeSessionId);

        Task<HttpStatusCode> SaveAsync(SessionStateModel<TModel> sessionStateModel);
    }
}