﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Domain.MapRenderer
{
    public class CustomPin : Pin
    {
        public string Url { get; set; }
        public string MarkerType { get; set; }
    }
}