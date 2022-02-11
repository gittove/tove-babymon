using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : Color", fileName = "New GameEvent Color")]
public class GameEventColor : ScriptableObject
{
    [HideInInspector] public UnityEvent<Color> gameEvent;
    public void AddListener(UnityEvent<Color> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<Color> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(Color value) => gameEvent?.Invoke(value);
}