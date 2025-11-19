using System.Security.Cryptography.X509Certificates;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;


    public Address()
    {
        _streetAddress = "Street Address";
        _city = "City";
        _state = "State";
        _country = "Country";
    }

    public Address(string address, string city, string state, string country)
    {
        _streetAddress = address;
        _city = city;
        _state = state;
        _country = country;
    }
    
    public bool IsUsa()
    {
        bool inUsa = false;

        if (_country.ToUpper() == "USA")
            inUsa = true;
        return inUsa;
    }
    
    public string GenerateAddressString ()
    {
        return $"{_streetAddress}\n{_city}, {_state} {_country}".ToString(); 
    }
}