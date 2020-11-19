using System;
using System.Collections;
using UnityEngine;

public class CameraFunctions : CameraStats{
    
    //Stats
    protected CameraState CurrentState {
        get => _currentState;
        set => _currentState = value;
    }
    protected bool RightHanded
    {
        get => _rightHanded;
        set => _rightHanded = value;
    }
    protected bool InverseHorizontal {
        get => _inverseHorizontal;
        set { 
            InverseHorizontal = value;
            HorizontalSensitivity = value ? Mathf.Abs(HorizontalSensitivity) * -1 : Mathf.Abs(HorizontalSensitivity);
        }
    }
    protected bool InverseVertical {
        get => _inverseVertical;
        set { 
            _inverseVertical = value;
            VerticalSensitivity = value ? Mathf.Abs(VerticalSensitivity) : Mathf.Abs(VerticalSensitivity) - 1;
        }
    }

    //Dynamic Stats
    protected float VerticalAngle {
        get => _verticalAngle;
        set => _verticalAngle = value;
    }
    protected float HorizontalSensitivity {
        get => _horizontalSensitivity;
        set => _horizontalSensitivity = value;
    }
    protected float VerticalSensitivity {
        get => _verticalSensitivity;
        set =>_verticalSensitivity = value;
    }

    //References
    protected GameObject CameraPivot {
        get => _cameraPivot != null ? _cameraPivot : _cameraPivot = transform.Find("Pivot").gameObject;
    }
    protected GameObject CameraHolder {
        get => _cameraHolder != null ? _cameraHolder : _cameraHolder = transform.Find("Privot/CameraHolder").gameObject;
    }

    //Functions
    public void InitializeTPSCamera() { 
        //initializes the camera for a third person shooter
    }
    public void InitializeFPSCamera() { 
        //initializes the camera for a first person shooter
    }
    public void FollowTarget(Transform target) {
        transform.position = target.transform.position;
    }
    public void MoveCamera(float hor, float ver, Transform target) {
        //Rotates left and right
        transform.Rotate(transform.up * hor * HorizontalSensitivity);
        target.GetChild(0).Rotate(transform.up * hor * HorizontalSensitivity);

        //Rotates Up and Down
        VerticalAngle = Mathf.Clamp(VerticalAngle + ver * VerticalSensitivity, -90, 90);
        CameraPivot.transform.localRotation = Quaternion.AngleAxis(VerticalAngle, Vector3.right);
    }

}
