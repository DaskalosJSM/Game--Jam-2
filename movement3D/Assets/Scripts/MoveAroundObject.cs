using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 3.0f;
    public Vector3 Posinicial;
    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;
    public Transform _2target;
    public Vector3 selected;
    public bool cameras = false;

    [SerializeField]
    private float _distanceFromTarget;
    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime;

    [SerializeField]
    private Vector2 _rotationXMinMax;
    private float _distanceFromTargetMemory;
    private float _smoothTimeMemory;
    private Vector2 _rotationXMinMaxMemory;

    public GameObject player;
    private void Start()
    {
        _distanceFromTargetMemory = _distanceFromTarget;
        _smoothTimeMemory = _smoothTime;
        _rotationXMinMaxMemory = _rotationXMinMax;
        Posinicial = new Vector3(-9f, 5f, -8f);
        this.transform.position = Posinicial;
    }
    void Update()
    {
        if (cameras == false) Iswalking();
        if (cameras == true) Isshooting();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            cameras = true;  
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)) cameras = false;
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += -mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = selected - transform.forward * _distanceFromTarget;
    }
    void Isshooting()
    {
        IsAiming();
        selected = _2target.transform.position;
        _smoothTime = 0.2f;
        _rotationXMinMax = new Vector2(-10, 40);
        _distanceFromTarget = 3.0f;
    }
    void Iswalking()
    {
        selected = _target.transform.position;
        _smoothTime = _smoothTimeMemory;
        _rotationXMinMax = _rotationXMinMaxMemory;
        _distanceFromTarget = _distanceFromTargetMemory;
    }
    void IsAiming()
    {
        player.transform.rotation = this.transform.rotation;
    }
}