﻿namespace HotelListing.API.Models.Hotel
{
    public class HotelDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryID { get; set; }
    }
}