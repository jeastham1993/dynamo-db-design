using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace online_store.Models
{
    public class Customer
    {
	    protected Customer()
	    {
	    }

	    public Customer(string username, string emailAddress, string name)
	    {
		    this.Username = username;
		    this.EmailAddress = emailAddress;
		    this.Name = name;
		    this.PK = $"CUSTOMER#{username}";
		    this.SK = $"CUSTOMER#{username}";
	    }

		public string PK { get; private set; }

		public string SK { get; private set; }

		public string Username { get; set; }

	    public string EmailAddress { get; set; }

	    public string Name { get; set; }

	    public Dictionary<string, AttributeValue> AsTableItem()
	    {
		    var tableItemRecords = new Dictionary<string, AttributeValue>(4);
			tableItemRecords.Add("PK", new AttributeValue()
			{
				S = this.PK
			});
			tableItemRecords.Add("SK", new AttributeValue()
			{
				S = this.SK
			});
			tableItemRecords.Add("Username", new AttributeValue()
			{
				S = this.Username
			});
			tableItemRecords.Add("EmailAddress", new AttributeValue()
			{
				S = this.EmailAddress
			});
			tableItemRecords.Add("Name", new AttributeValue()
			{
				S = this.Name
			});

			return tableItemRecords;
	    }
    }
}
