using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStats : MonoBehaviour{

    [Header("Camera Stats")]
    [SerializeField] protected CameraState _currentState;
    [SerializeField] protected bool _rightHanded;
    [SerializeField] protected bool _inverseVertical;
    [SerializeField] protected bool _inverseHorizontal;

    [Header("Dynamic Stats")]
    [SerializeField] protected float _verticalAngle;
    [SerializeField] protected float _horizontalSensitivity;
    [SerializeField] protected float _verticalSensitivity;

    [Header("References")]
    [SerializeField] protected GameObject _cameraPivot;
    [SerializeField] protected GameObject _cameraHolder;

    //Enums
    protected enum CameraState { ThirdPerson, FirstPerson, Nothing}
}
