public class Product
{
    private string _productName;
    private int _productId;
    private double _price;
    private int _quantity;


    //getters and setters
    public string GetProductName()
    {
        return _productName;
    }


    public int GetProductId()
    {
        return _productId;
    }


    public double GetPrice()
    {
        return _price;
    }


    public int GetQuantity()
    {
        return _quantity;
    }

    //Constructors

    public Product (string product, int productId, double price, int quantity)
    {
        _productName = product;
        _productId = productId;
        _price = price;
        _quantity = quantity; 
    }


}