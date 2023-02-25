using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    //[SerializeField] private float _sensitivity = 200f;
    //[SerializeField] private Transform _player;

    //private float _mouseX;
    //private float _mouseY;

    [SerializeField] private float _sensitivity = 3;
    [SerializeField] private float _limitX;
    [SerializeField] private Player _player;

    private float _rotationX;
    private float _rotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //_mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        //_mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        //_player.Rotate(_mouseX * new Vector3(0, 1, 0));

        //transform.Rotate(-_mouseY * new Vector3(1, 0, 0));

        _rotationY = _player.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivity;
        _rotationX += Input.GetAxis("Mouse Y") * _sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -_limitX, _limitX);
        transform.localEulerAngles = new Vector3(-_rotationX, 0, 0);
        _player.transform.localEulerAngles = new Vector3(0, _rotationY, 0);
    }
}
