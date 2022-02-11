using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : char", fileName = "New GameEvent char")]
public class GameEventChar : ScriptableObject
{
    [HideInInspector] public UnityEvent<char> gameEvent;
    public void AddListener(UnityEvent<char> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<char> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(char value) => gameEvent?.Invoke(value);
}