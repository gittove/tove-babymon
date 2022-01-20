using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : Vector2", fileName = "New GameEvent Vector2")]
public class GameEventVector2 : ScriptableObject
{
    [HideInInspector] public UnityEvent<Vector2> gameEvent;
    public void AddListener(UnityEvent<Vector2> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<Vector2> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(Vector2 value) => gameEvent?.Invoke(value);
}