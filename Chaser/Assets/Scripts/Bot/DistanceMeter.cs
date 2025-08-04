using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    public float GetSqrDistance(Vector3 targetPosition) => Vector3.SqrMagnitude(targetPosition - transform.position);
}