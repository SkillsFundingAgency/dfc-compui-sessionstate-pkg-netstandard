namespace DFC.Compui.Cosmos.Contracts
{
    public interface ISessionStateModel<TModel>
        where TModel : class
    {
        int? Ttl { get; set; }

        public TModel? State { get; set; }
    }
}
