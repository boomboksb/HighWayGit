using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private Wheel[] _wheels;

    [SerializeField] private int _motorForce;
    [SerializeField] private int _brakeForce;
    [SerializeField] private float _brakeInput;
    private float _verticalInput;
    private float _horizontalInput;
    private float _speed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }


    private void Update()
    {
        Move();
        Brake();
        CheckInput();
    }
    private void Move()
    {
        _speed = _rb.velocity.magnitude; 
         
        foreach (Wheel wheel in _wheels)
        {
            wheel.WheelCollider.motorTorque = _motorForce * _verticalInput;
            wheel.UpdateMeshPosition();
        }
        Steering();
    }

    private void CheckInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        float movingDirectional = Vector3.Dot(transform.forward, _rb.velocity);
        _brakeInput = (movingDirectional < -0.5f && _verticalInput > 0) || (movingDirectional > 0.5f && _verticalInput < 0) ? Mathf.Abs(_verticalInput) : 0;
        if (Input.GetKey(KeyCode.Space))
        {
            _brakeInput = 5.0f;
        }
        else
        { 
            _brakeInput = 0.0f;
        }
        

    }
    private void Brake()
    {
       /*foreach (Wheel wheel in _wheels)
                wheel.WheelCollider.brakeTorque = _brakeInput * _brakeForce * (wheel.IsForwardWheels ? 0.7f : 0.3f);*/
       
        

        
    }
    private void Steering()
    {
        float steeringAngle = _horizontalInput * 30;

        foreach (Wheel wheel in _wheels)
        {
            if (wheel.IsForwardWheels)
                wheel.WheelCollider.steerAngle = steeringAngle;
        }

    }
}

[System.Serializable]


public struct Wheel
{
    public Transform WheelMesh;
    public WheelCollider WheelCollider;
    public bool IsForwardWheels;

    public readonly void UpdateMeshPosition()
    {
        Vector3 position;
        Quaternion rotation;

        WheelCollider.GetWorldPose(out position, out rotation);

        WheelMesh.position = position;
        WheelMesh.rotation = rotation;

    } 
}