using DFC.Compui.Cosmos.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DFC.Compui.Sessionstate
{
    public class SessionStateService<TModel> : ISessionStateService<TModel>
        where TModel : class, new()
    {
        private readonly IDocumentService<SessionStateModel<TModel>> documentService;

        public SessionStateService(IDocumentService<SessionStateModel<TModel>> documentService)
        {
            this.documentService = documentService;
        }

        public async Task<SessionStateModel<TModel>> GetAsync(Guid compositeSessionId)
        {
            var sessionStateModel = await documentService.GetByIdAsync(compositeSessionId).ConfigureAwait(false);
            if (sessionStateModel == null)
            {
                sessionStateModel = new SessionStateModel<TModel>
                {
                    Id = compositeSessionId,
                };
            }

            return sessionStateModel;
        }

        public async Task<HttpStatusCode> SaveAsync(SessionStateModel<TModel> sessionStateModel)
        {
            return await documentService.UpsertAsync(sessionStateModel).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid compositeSessionId)
        {
            return await documentService.DeleteAsync(compositeSessionId).ConfigureAwait(false);
        }
    }
}
