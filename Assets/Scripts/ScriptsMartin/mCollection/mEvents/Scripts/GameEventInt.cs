using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : int", fileName = "New GameEvent int")]
public class GameEventInt : ScriptableObject
{
    [HideInInspector] public UnityEvent<int> gameEvent;
    public void AddListener(UnityEvent<int> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<int> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(int value) => gameEvent?.Invoke(value);
}