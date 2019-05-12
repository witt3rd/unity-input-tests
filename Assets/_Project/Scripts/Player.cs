using UnityEngine;
using UnityEngine.Experimental.Input;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const int IsMovingParameterId = 120489994;

    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private float rotationSpeed = 10;
    private InputAction movement;
    [SerializeField] private InputActionAsset playerControls;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        var gameplayActionMap = playerControls.GetActionMap("Gameplay");
        movement = gameplayActionMap.GetAction("Movement");

        movement.performed += OnMovementChanged;
        movement.cancelled += OnMovementChanged;
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        Direction = new Vector3(direction.x, 0, direction.y);
    }

    private void FixedUpdate()
    {
        _animator.SetBool(IsMovingParameterId, IsMoving);

        if (!IsMoving) return;

        transform.position += Direction * movementSpeed * Time.deltaTime;
        transform.rotation = Rotation;
    }

    private bool IsMoving => Direction != Vector3.zero;
    private Vector3 Direction { get; set; }
    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection =>
        Vector3.RotateTowards(
            transform.forward,
            Direction,
            rotationSpeed * Time.deltaTime,
            0);

    private void OnDisable()
    {
        movement.Disable();
    }

    private void OnEnable()
    {
        movement.Enable();
    }
}