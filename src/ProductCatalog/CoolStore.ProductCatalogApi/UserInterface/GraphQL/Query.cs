using CoolStore.ProductCatalogApi.Application.UseCase.GetProducts;
using CoolStore.Protobuf.Inventory.V1;
using CoolStore.Protobuf.ProductCatalog.V1;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N8T.Infrastructure.Dapr;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoolStore.ProductCatalogApi.UserInterface.GraphQL
{
    public class Query
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly ILogger<Query> _logger;

        public Query(IMediator mediator
            , IConfiguration config
            , ILogger<Query> logger
            )
        {
            _mediator = mediator;
            _config = config;
            _logger = logger;
        }

        public async Task<IEnumerable<CatalogProductDto>> GetProducts()
        {
            var daprClient = _config.GetDaprClient("inventory-api", true);

            var inventories = await daprClient.InvokeMethodAsync<GetInventoriesRequest, List<InventoryDto>>(
                "inventory-api",
                "GetInventories",
                new GetInventoriesRequest());

            var result = await _mediator.Send(new GetProductsQuery());

            return result.ToList().Select(x =>
            {
                var inv = inventories.FirstOrDefault(i => i.Id == x.InventoryId);
                if (inv == null) return x;
                x.InventoryDescription = inv?.Description;
                x.InventoryLocation = inv?.Location;
                x.InventoryWebsite = inv?.Website;
                return x;
            });
        }
    }
}
