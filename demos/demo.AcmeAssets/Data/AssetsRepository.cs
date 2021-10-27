using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using demo.Acme;
using demo.Acme.Models;
using demo.Acme.Repositories;
using demo.DataModel;
using Microsoft.Extensions.Logging;
using TetraPak;

namespace demo.AcmeAssets.Data
{
    public class AssetsRepository : SimpleRepository<Asset>
    {
        readonly IDictionary<string, Asset> _assets;

        protected override Asset OnMakeNewItem(Asset source)
        {
            var newId = source.Id ?? new RandomString();
            return new Asset(newId)
            {
                Description = source.Description,
                Url = source.Url
            };
        }

        protected override Task OnUpdateItemAsync(Asset target, Asset source)
        {
            target.UpdateFrom(source);
            return Task.CompletedTask;
        }

        public override Task<Outcome<string>> DeleteAsync(string id, CancellationToken? cancellation = null)
        {
            throw new NotImplementedException();
        }

        public AssetsRepository(ILogger? logger) 
        : base(logger)
        {
            _assets = new Dictionary<string, Asset>();
        }
    }
}