https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.CoreComponents.html

DynamoDB supports two different kinds of primary keys:

- **Partition key** – A simple primary key, composed of one attribute known as the _partition key_.
    
    DynamoDB uses the partition key's value as input to an internal hash function. The output from the hash function determines the partition (physical storage internal to DynamoDB) in which the item will be stored.
    
    In a table that has only a partition key, no two items can have the same partition key value.
    
    The _People_ table described in [Tables, items, and attributes](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.CoreComponents.html#HowItWorks.CoreComponents.TablesItemsAttributes) is an example of a table with a simple primary key (_PersonID_). You can access any item in the _People_ table directly by providing the _PersonId_ value for that item.
    
- **Partition key and sort key** – Referred to as a _composite primary key_, this type of key is composed of two attributes. The first attribute is the _partition key_, and the second attribute is the _sort key_.
    
    DynamoDB uses the partition key value as input to an internal hash function. The output from the hash function determines the partition (physical storage internal to DynamoDB) in which the item will be stored. All items with the same partition key value are stored together, in sorted order by sort key value.
    
    In a table that has a partition key and a sort key, it's possible for multiple items to have the same partition key value. However, those items must have different sort key values.
    
    The _Music_ table described in [Tables, items, and attributes](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.CoreComponents.html#HowItWorks.CoreComponents.TablesItemsAttributes) is an example of a table with a composite primary key (_Artist_ and _SongTitle_). You can access any item in the _Music_ table directly, if you provide the _Artist_ and _SongTitle_ values for that item.
    
    A composite primary key gives you additional flexibility when querying data. For example, if you provide only the value for _Artist_, DynamoDB retrieves all of the songs by that artist. To retrieve only a subset of songs by a particular artist, you can provide a value for _Artist_ along with a range of values for _SongTitle_.