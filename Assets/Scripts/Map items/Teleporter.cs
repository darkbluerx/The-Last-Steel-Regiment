using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
