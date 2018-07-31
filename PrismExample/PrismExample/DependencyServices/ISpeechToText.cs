using System;

namespace PrismExample.DependencyServices
{
    public interface ISpeechToText
    {
        void Start();
        void Stop();

        event EventHandler<EventArgsVoiceRecognition> textChanged;
    }
}
