using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : string", fileName = "New GameEvent string")]
public class GameEventString : ScriptableObject
{
    [HideInInspector] public UnityEvent<string> gameEvent;
    public void AddListener(UnityEvent<string> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<string> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(string value) => gameEvent?.Invoke(value);
}