﻿namespace HotelListing.API.Models
{
    public class QueryParameters
    {
        private int _pageSize = 15;
        public int StartIndex { get; set; }  
        public int PageNumber { get; set; }
        public int Pagesize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}