using System;
using Xamarin.Forms;

namespace PrismExample.CustomRenderers
{
    public class VoiceButton : Button
    {
        public Action<string> OnTextChanged { get; set; }
    }
}
