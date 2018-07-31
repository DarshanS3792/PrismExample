﻿using System;
using Android.App;
using Android.Content;

namespace PrismExample.Droid.CustomRenderers
{
    public class ActivityResultEventArgs : EventArgs
    {
        public int RequestCode { get; set; }
        public Result ResultCode { get; set; }
        public Intent Data { get; set; }

        public ActivityResultEventArgs() : base()
        { }
    }
}