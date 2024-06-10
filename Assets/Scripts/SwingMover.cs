using UnityEngine;

[RequireComponent (typeof(HingeJoint))]
public class SwingMover : MonoBehaviour
{
    [SerializeField] private float _motorSpeed;
    [SerializeField] private float _motorForce;

    private HingeJoint _hingeJoint;
    private JointMotor _jointMotor;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void Start()
    {
        _jointMotor = _hingeJoint.motor;
        _jointMotor.force = _motorForce;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jointMotor.targetVelocity = _motorSpeed;
            _hingeJoint.motor = _jointMotor;
            _hingeJoint.useMotor = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _hingeJoint.useMotor = false;
        }
    }
}