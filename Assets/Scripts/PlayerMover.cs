using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidBody;
    private float _vertical;
    private float _horizontal;

    private void Start()
    {
        _rigidBody= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _vertical = Input.GetAxisRaw("Vertical");
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(transform.forward * _vertical * _speed);
    }
}