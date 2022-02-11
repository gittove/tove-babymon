using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : Object", fileName = "New GameEvent Object")]
public class GameEventObject : ScriptableObject
{
    [HideInInspector] public UnityEvent<object> gameEvent;
    public void AddListener(UnityEvent<object> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<object> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(object value) => gameEvent?.Invoke(value);
}