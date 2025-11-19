using System.Net.Sockets;

public class Customer
{
    private string _name;
    private Address _address = new Address();

    //gettters and setters
    public string GetCustomerName()
    {
        return _name;
    }

    public string GetCustomerAddress()
    {
        return _address.GenerateAddressString();
    }

    //constructers

    public Customer()
    {
        _name = "Enter a name";
        _address = new Address();
    }
    
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    


    public bool American()
    {
        bool american = false;
        if (_address.IsUsa())
        {
            american = true;
        }
        return american; 
    }
}