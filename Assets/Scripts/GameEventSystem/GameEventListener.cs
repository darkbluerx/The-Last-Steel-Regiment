using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEvent gameEvent;
    [SerializeField] UnityEvent response;

    private void OnEnable()
    {
        if (gameEvent != null) gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent != null) gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
