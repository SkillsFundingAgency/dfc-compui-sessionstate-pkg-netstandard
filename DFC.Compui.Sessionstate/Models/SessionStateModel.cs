using DFC.Compui.Cosmos.Contracts;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DFC.Compui.Sessionstate
{
    public class SessionStateModel<TModel> : DocumentModel, ISessionStateModel<TModel>
        where TModel : class, new()
    {
        [Required]
        [JsonProperty(Order = -10)]
        public override string? PartitionKey { get; set; } = Constants.DefaultPartitonKey;

        [JsonProperty(PropertyName = "ttl", Order = -10, NullValueHandling = NullValueHandling.Ignore)]
        public int? Ttl { get; set; }

        public TModel? State { get; set; } = new TModel();
    }
}
