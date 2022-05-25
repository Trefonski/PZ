using Microsoft.AspNetCore.Identity;

namespace PZ.Models
{
    public class AppUser : IdentityUser
    {
        
    }
    
    public class Orders
    {
        public uint ID_Order {get; set;}
        
        public Clients ID_Client {get; set;}
        [ForeignKey(ID_Client)]
        public Addresses ID_Address {get; set;}
        public OrderDates ID_Date {get; set;}
    }

    public class Clients 
    {
        public uint ID_Client {get; set;}
        public Addresses ID_Address {get; set;}
        public string Login {get; set;}
        public string Name {get; set;}
    }

    public class Addresses
    {
        public byte ID_Address {get; set;}
        public bool Default {get; set;}
        public string City {get; set;}
        public string Voivodeship{get; set;}
        public string County {get; set;}
        public string PostCode {get; set;}
        public string Street {get; set;}
        public ushort BlockNo {get; set;}
        public ushort HouseNo {get; set;}
    }

    public class OrderDates
    {
        public int ID_Date {get; set;}
        public Orders ID_Order {get; set;}
        public Status ID_Status {get; set;}
        public DateTime Date {get; set;}
    }

    public class Status
    {
        public byte ID_Status {get; set;}
        public enum enumStatus {Received, Paid, Packed, Sent, Delivered}
    }

    public class OrderQuantities
    {
        public Orders ID_Order {get; set;}
        public Items ID_Item {get; set;}
        public ushort Quantity {get; set;}
    }

    public class Items
    {
        public string ID_Item {get; set;}
        public Pictures ID_Picture {get; set;}
    }

    public class Pictures
    {

    }
}