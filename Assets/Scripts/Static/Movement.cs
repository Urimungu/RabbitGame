using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //Moves the player using a Vector input
    public static void MovePlayer(float hor, float ver, float speed, GameObject slope, Rigidbody rb) {
        //Calculates the Direction
        var newVel = (slope.transform.right * hor) + (slope.transform.forward * ver);
        newVel = newVel.normalized * speed;

        //Changes the y direction
        newVel.y += rb.velocity.y;

        //Sets the movement into the Rigidbody
        rb.velocity = newVel;
    }

    //Checks the steepness of the ground that the player is standing on
    public static void CheckSteepness(RaycastHit hit, Rigidbody rb, ref GameObject slope, LayerMask GroundMask) {
        if (hit.collider == null) return;
        rb.transform.up = hit.normal;
    }

    //Makes the player jump
    public static void Jump(float JumpForce, float jumpDuration, Rigidbody rb) { 
    
    }
}
