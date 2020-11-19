using UnityEngine;

public class CharacterStats : MonoBehaviour{

    [Header("Mechanical Stats")]
    [SerializeField] protected bool _inputEnabled;
    [SerializeField] protected float _groundCheckRayLength;
    [SerializeField] protected LayerMask _groundMask;


    [Header("Movement")]
    [SerializeField] protected bool _canMove;

    [Header("Dynamic Variables")]
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected bool _grounded;

    [Header("Camera Stats")]
    [SerializeField] protected bool _cameraCanFollow;
    [SerializeField] protected bool _canControlCamera;
    [SerializeField] protected CameraFunctions _playerCamera;

    [Header("References")]
    [SerializeField] protected Rigidbody _playerRigidbody;
    [SerializeField] protected GameObject _slopeCheck;

}
