﻿namespace Kolloquium.Models
{
    public class AddCustomerViewModel
    {
        public Guid c_id { get; set; }
        public string c_name { get; set; }
        public string c_phone { get; set; }
        public string c_email { get; set; }
        public bool c_newsletter { get; set; }
    }
}
