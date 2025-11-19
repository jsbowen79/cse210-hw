using System.Reflection.Metadata.Ecma335;

public class Order
{
    private List<Product> _productList = new List<Product>();
    private Customer _purchaser = new Customer();

    public Order(List<Product> productList, Customer purchaser)
    {
        _purchaser = purchaser;
        _productList = productList;
    }

    public double CalculateOrderTotal()
    {
        double subtotal = 0;
        foreach (Product item in _productList)
        {

            double lineItem = item.GetPrice() * item.GetQuantity();
            subtotal += lineItem;
        }

        if (_purchaser.American())
        {
            subtotal += 5;
        }
        else
        {
            subtotal += 35;
        }

        return subtotal;
    }

    public string GeneratePackingLabel()
    {
        List<string> packingLabel = new List<string>();
        packingLabel.Add($"\nItems to be packed for {_purchaser.GetCustomerName()}.\n");
        foreach (Product item in _productList)
        {
            packingLabel.Add($" Product ID: {item.GetProductId().ToString()}-");
            packingLabel.Add($"{item.GetProductName()}, Qty: {item.GetQuantity()}\n");

        }
        return string.Join("", packingLabel);
    }

    public string GenerateShippingLabel()
    {
        List<string> shippingLabel = new List<string>();
        shippingLabel.Add("Ship package to:\n");
        shippingLabel.Add($"{_purchaser.GetCustomerName()}\n");
        shippingLabel.Add($"{_purchaser.GetCustomerAddress()}");
        return string.Join(" ", shippingLabel); 
    }
    

    
    
}