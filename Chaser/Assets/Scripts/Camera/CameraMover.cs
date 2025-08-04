using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField, Range(0, 1)] private float _smoothSpeed;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _player.position + _offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed);

        transform.position = smoothedPostion;
    }
}