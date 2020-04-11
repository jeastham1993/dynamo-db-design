using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace online_store.Models
{
    public class CustomerEmail
    {
	    internal CustomerEmail(
		    string emailAddress)
	    {
		    this.EmailAddress = emailAddress;
		    this.PK = $"CUSTOMEREMAIL#{emailAddress}";
            this.SK = $"CUSTOMEREMAIL#{emailAddress}";
        }
        public string PK { get; private set; }
        public string SK { get; private set; }
        public string EmailAddress { get; private set; }

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
	        tableItemRecords.Add("EmailAddress", new AttributeValue()
	        {
		        S = this.EmailAddress
	        });

	        return tableItemRecords;
        }
	}
}
