using EventBusFramework;
using UnityEngine;
using Zenject;

namespace SourceCode.Audio
{
    public abstract class MultiAudioSourceBase<TEvent> : PauseableAudioSource, IEventReceiver<TEvent>
        where TEvent : struct, IEvent
    {
        public EventBusReceiverIdentifier EventBusReceiverIdentifier { get; } = new();

        private EventBus _eventBus;
        private AudioClip _audioClip;

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        protected override void OnAwake()
        {
            _audioClip = AudioSource.clip;
            _eventBus.Subscribe(this);
        }
        
        private void OnDestroy()
        {
            _eventBus.UnSubscribe(this);
            OnDestroyEvent();
        }

        protected virtual void OnDestroyEvent() { }
        
        public void OnEvent(TEvent @event) => PlayOneShot();
        
        private void PlayOneShot() => AudioSource.PlayOneShot(_audioClip);
    }
}