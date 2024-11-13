using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StickController : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    private InputAction stickAction;
    private TankController tc;
    // Start is called before the first frame update
    void Start()
    {
        
        stickAction = new InputAction(type: InputActionType.Value, binding: "<Gamepad>/leftStick");
        stickAction.Enable();
        tc = tank.GetComponent<TankController>();
    }

    void FixedUpdate()
    {
        tc.SetDir(stickAction.ReadValue<Vector2>());
    }
}
