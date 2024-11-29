using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StickController : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private string controllerBindingDoNotChange = "<Gamepad>/leftStick";
    private InputAction stickAction;
    private TankController tc;
    
    // Start is called before the first frame update
    void Start()
    {
        tc = tank.GetComponent<TankController>();
        stickAction = new InputAction(type: InputActionType.Value, binding: controllerBindingDoNotChange);
        stickAction.Enable();
    }

    void FixedUpdate()
    {
        if(tc != null)
        {
            Vector2 v2 = stickAction.ReadValue<Vector2>();
            tc.SetDir(v2);
        }
    }
}
