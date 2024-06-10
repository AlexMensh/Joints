using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class CatapultShooter : MonoBehaviour
{
    [SerializeField] private float _minSpring;
    [SerializeField] private float _maxSpring;
    [SerializeField] private Bullet _bulletPrefab;

    private SpringJoint _springJoint;
    private Bullet _bullet;

    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
    }

    private void Start()
    {
        _springJoint.spring = _minSpring;
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Load();
        }
    }

    private void Launch()
    {
        _springJoint.spring = _maxSpring;
    }

    private void Load()
    {
        _springJoint.spring = _minSpring;
        Instantiate(_bulletPrefab, transform.position + Vector3.left + Vector3.up, transform.rotation);
    }
}