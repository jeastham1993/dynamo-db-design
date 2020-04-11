
import * as aws from "@pulumi/aws";

// Create an AWS resource (S3 Bucket)
const db = new aws.dynamodb.Table("OnlineStore", {
    attributes: [
        { name: "PK", type: "S"},
    ],
    hashKey: "PK",
    readCapacity: 1,
    writeCapacity: 1
});