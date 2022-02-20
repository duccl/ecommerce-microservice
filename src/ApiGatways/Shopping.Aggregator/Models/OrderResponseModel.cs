﻿namespace Shopping.Aggregator.Models
{
    public class OrderResponseModel
    {
        public class Order
        {
            public string UserName { get; set; }
            public decimal TotalPrice { get; set; }
            public AddressModel Address { get; set; }
            public PaymentModel Payment { get; set; }
        }
    }

    public class AddressModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class PaymentModel
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}
