using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{

public class Inventory
{

    public Inventory(){}

   
    public Inventory(int quantity): this()
    {
        this.Quantity = quantity;
    }

    public Inventory(int quantity, int storeId): this(quantity)
    {
        this.StoreId = storeId;
    }

    public Inventory(int quantity, int storeId, int productId): this(quantity, storeId)
    {
        this.ProductId = productId;
    }

    public Inventory(int quantity, int storeId, int productId, int inventId): this(quantity, storeId, productId)
    {
        this.InventoryId = inventId;
    }






    public int InventoryId { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    public int StoreId { get; set; }

    public int ProductId { get; set; }
    
    //[Required]
    public Product Product { get; set; }

    public override string ToString()
{
    return $"StoreID: {this.StoreId} \nInventoryID: {this.InventoryId} \nProductID: {this.ProductId} \nQuantity: {this.Quantity} \n  ";
}
}
}