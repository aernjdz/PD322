using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace Homework_04
{
    class WebSite
    {
        private string name;
        private string url;
        private string description;
        private string ipAddress;
        public void SetName(string newName)
        {
            name = newName;
        }

    public string GetName()
    {
        return name;
    }

    public void SetUrl(string newUrl)
    {
        url = newUrl;
    }

    public string GetUrl()
    {
        return url;
    }

    public void SetDescription(string newDescription)
    {
        description = newDescription;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetIpAddress(string newIpAddress)
    {
        ipAddress = newIpAddress;
    }

    public string GetIpAddress()
    {
        return ipAddress;
    }

    public void InputData()
    {
        Console.Write("Enter the website name: ");
        SetName(Console.ReadLine());

        Console.Write("Enter the website URL: ");
        SetUrl(Console.ReadLine());

        Console.Write("Enter the website description: ");
        SetDescription(Console.ReadLine());

        Console.Write("Enter the website IP address: ");
        SetIpAddress(Console.ReadLine());
    }

    public void DisplayData()
    {
        Console.WriteLine($"Website Name: {GetName()}");
        Console.WriteLine($"Website URL: {GetUrl()}");
        Console.WriteLine($"Website Description: {GetDescription()}");
        Console.WriteLine($"Website IP Address: {GetIpAddress()}");
    }
}
}
