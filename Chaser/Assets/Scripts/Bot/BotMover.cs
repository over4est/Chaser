using UnityEngine;

[RequireComponent(typeof(DistanceMeter))]
public class BotMover : MonoBehaviour
{
    [SerializeField] private float _slopeLimit;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepOffset;
    [SerializeField] private float _minDistanceToPlayer;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _foots;

    private DistanceMeter _distanceMeter;
    private Rigidbody _rigidbody;
    private float _raycastDistance = 1f;
    private float _smoothFactor = 0.1f;

    private void Awake()
    {
        _distanceMeter = GetComponent<DistanceMeter>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = _distanceMeter.GetSqrDistance(_player.position);

        if (distanceToPlayer <= _minDistanceToPlayer)
            return;

        Vector3 direction = (_player.position - transform.position).normalized;

        TryStep(direction);
        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        if (Physics.Raycast(_foots.position, Vector3.down, out RaycastHit hit, _raycastDistance))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);

            if (angle < _slopeLimit)
            {
                Vector3 newVelocity = direction * _moveSpeed;

                newVelocity.y = _rigidbody.velocity.y;
                _rigidbody.velocity = newVelocity;
            }
        }
    }

    private void TryStep(Vector3 direction)
    {
        if (Physics.Raycast(_foots.position, direction, out RaycastHit hit, _raycastDistance))
        {
            Vector3 stepUp = Vector3.up * _stepOffset;
            Vector3 upperFoots = _foots.position + stepUp;

            if (Physics.Raycast(upperFoots, direction, _raycastDistance) == false)
                _rigidbody.MovePosition(Vector3.Lerp(transform.position, transform.position + stepUp, _smoothFactor));
        }
    }
}