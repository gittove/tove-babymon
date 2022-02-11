using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent", fileName = "New GameEvent")]
public class GameEvent : ScriptableObject
{
    [HideInInspector] public UnityEvent gameEvent;
    public void AddListener(UnityEvent subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent() => gameEvent?.Invoke();
}