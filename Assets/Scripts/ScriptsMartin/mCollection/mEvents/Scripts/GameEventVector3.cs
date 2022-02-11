using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/New GameEvent : Vector3", fileName = "New GameEvent Vector3")]
public class GameEventVector3 : ScriptableObject
{
    [HideInInspector] public UnityEvent<Vector3> gameEvent;
    public void AddListener(UnityEvent<Vector3> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<Vector3> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(Vector3 value) => gameEvent?.Invoke(value);
}