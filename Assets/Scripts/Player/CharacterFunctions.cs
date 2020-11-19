using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterFunctions : CharacterStats{
    
    //Mechanical Stats
    protected bool InputEnabled {
        get => _inputEnabled;
        set => _inputEnabled = value;
    }
    protected float GroundCheckRayLength {
        get => _groundCheckRayLength;
        set => _groundCheckRayLength = value;
    }
    protected LayerMask GroundMask {
        get => _groundMask;
        set => _groundMask = value;
    }

    //Movement
    protected bool CanMove {
        get => _canMove;
        set => _canMove = value;
    }

    //Dynamic Varaibles
    protected float MovementSpeed {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }
    protected bool Grounded {
        get => _grounded;
        set => _grounded = value;
    }

    //Camera Stats
    protected bool CameraCanFollow {
        get => _cameraCanFollow;
        set => _cameraCanFollow = value;
    }
    protected bool CanControlCamera {
        get => _canControlCamera;
        set { 
            _canControlCamera = value;

            //Locks and Unlocks the Mouse
            if (value){
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    protected CameraFunctions PlayerCamera {
        get => _playerCamera != null ? _playerCamera : _playerCamera = CreateNewCamera();
    }

    //References
    protected Rigidbody PlayerRigidbody {
        get => _playerRigidbody != null ? _playerRigidbody : _playerRigidbody = GetComponent<Rigidbody>();
    }
    protected GameObject SlopeCheck {
        get => _slopeCheck != null ? _slopeCheck : _slopeCheck = transform.Find("Rotation").gameObject;
    }

    //Functions
    private CameraFunctions CreateNewCamera() {
        //Creates a new Camera and gives it to the player
        return null;
    }
    protected RaycastHit CheckIfGrounded { 
        get {

            Vector3 center = transform.position - new Vector3(0, (GetComponent<CapsuleCollider>().height / 2) - 0.5f, 0);

            //Sets the Grounded bool
            Grounded = Physics.SphereCast(center, 0.2f , Vector3.down, out RaycastHit hit, GroundCheckRayLength, GroundMask);

            //Returns the hit information
            return hit;
        }
    }

    private void OnDrawGizmos(){
        Vector3 center = transform.position - new Vector3(0, (GetComponent<CapsuleCollider>().height / 2) - (0.5f), 0);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center, 0.4f);

        Vector3 center2 = transform.position - new Vector3(0, (GetComponent<CapsuleCollider>().height / 2) - (0.5f), 0);
        center2 -= new Vector3(0, GroundCheckRayLength, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center2, 0.4f);
    }
}
