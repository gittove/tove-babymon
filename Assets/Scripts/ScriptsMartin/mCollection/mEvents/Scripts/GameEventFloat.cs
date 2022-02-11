using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "GameEvents/New GameEvent : float", fileName = "New GameEvent float")]
public class GameEventFloat : ScriptableObject
{
    [HideInInspector] public UnityEvent<float> gameEvent;
    public void AddListener(UnityEvent<float> subscribedEvent) => gameEvent.AddListener(subscribedEvent.Invoke);
    public void RemoveListener(UnityEvent<float> subscribedEvent) => gameEvent.RemoveListener(subscribedEvent.Invoke);
    public void TriggerEvent(float value) => gameEvent?.Invoke(value);
}