using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterFunctions{

    private void Start(){
        CanControlCamera = true;
    }

    private void Update() {
        if (InputEnabled) {
            //Movement
            if (CanMove) {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");

                var slope = SlopeCheck;
                Movement.CheckSteepness(CheckIfGrounded, PlayerRigidbody, ref slope, GroundMask);
                Movement.MovePlayer(horizontal, vertical, MovementSpeed, slope, PlayerRigidbody);
            }
            
            //Camera Follow
            if (CameraCanFollow) {
                PlayerCamera.FollowTarget(transform);

                //Camera Rotation
                if (CanControlCamera){
                    float horizontal = Input.GetAxisRaw("Mouse X");
                    float vertical = Input.GetAxisRaw("Mouse Y");
                    PlayerCamera.MoveCamera(horizontal, vertical, transform);
                    
                    //Unlocks mouse
                    if (Input.GetKeyDown(KeyCode.Escape)) CanControlCamera = false;

                }
                else if (Input.GetMouseButton(0))
                    CanControlCamera = true;
            }

        }
    
    }

}
