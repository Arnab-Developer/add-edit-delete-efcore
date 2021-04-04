# Add edit delete with EF Core.

Save disconnected object with EF Core. The `AddEditDelete` method checks the object status and based
on that it create, update or remove from database. It uses EF Core to check the status of the object.

```csharp
private static void AddEditDelete(Order order)
{
    // code here...
}
```

In `Main` the `AddEditDelete` is called to do different work. For different work different region 
has been created.

* Initial create
* Add order items
* Remove order items
* Work with place
* Delete
