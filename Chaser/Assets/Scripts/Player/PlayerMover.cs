using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private InputReader _inputReader;
    private CharacterController _characterController;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable() => _inputReader.MoveNeeded += Move;

    private void OnDisable() => _inputReader.MoveNeeded -= Move;

    private void Move(Vector3 direction) => _characterController.SimpleMove(direction * _moveSpeed);
}