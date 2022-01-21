using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : bool", fileName = "New GameEvent bool")]
public class GameEventBool : ScriptableObject
{
    [HideInInspector] public UnityEvent<bool> gameEvent;
    public void AddListener(UnityEvent<bool> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<bool> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(bool value) => gameEvent?.Invoke(value);
}