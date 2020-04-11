using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using online_store.Models;
using online_store.ViewModels;

namespace online_store.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly AmazonDynamoDBClient _client;
		private readonly ILogger<CustomerController> _logger;

		public CustomerController(
			ILogger<CustomerController> logger,
			AmazonDynamoDBClient client)
		{
			this._logger = logger;
			this._client = client;
		}

		[HttpPost]
		public async Task<Customer> Get(
			CustomerDTO inboundCustomer)
		{
			var customer = new Customer(
				inboundCustomer.Username,
				inboundCustomer.EmailAddress,
				inboundCustomer.Name);
			var customerEmail = new CustomerEmail(inboundCustomer.EmailAddress);

			var transactWriteItemRequest = new TransactWriteItemsRequest
			{
				TransactItems = new List<TransactWriteItem>(2)
				{
					new TransactWriteItem
					{
						Put = new Put
						{
							TableName = "OnlineStore-dd006eb",
							ConditionExpression = "attribute_not_exists(PK)",
							Item = customer.AsTableItem()
						}
					},
					new TransactWriteItem
					{
						Put = new Put
						{
							TableName = "OnlineStore-dd006eb",
							ConditionExpression = "attribute_not_exists(PK)",
							Item = customerEmail.AsTableItem()
						}
					}
				}
			};

			var response = await this._client.TransactWriteItemsAsync(transactWriteItemRequest).ConfigureAwait(false);

			return customer;
		}
	}
}