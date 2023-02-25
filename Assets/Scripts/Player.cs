using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GrapplingHook _grapplingHook;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _grapplingHook.CreateHook();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _grapplingHook.DisableHook();
        }
    }
}