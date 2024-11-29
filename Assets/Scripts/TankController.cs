using System;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class TankController : MonoBehaviour
{
    [SerializeField] private float player_speed = 1f;
    private Vector2 dir;
    public void SetDir(Vector2 d){
        dir = d * player_speed;
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 9f);
    }
    void FixedUpdate()
    {
        if(IsGrounded()){
            Rigidbody brb = GetComponent<Rigidbody>();
            var dist = new Vector3(dir.x,brb.velocity.y,dir.y) - brb.velocity;
            brb.velocity += dist/Math.Max(1.0f,dist.magnitude);
        }
    }
    void Update(){
        if(dir.magnitude>0.001)
            transform.rotation = Quaternion.Euler(0.0f,(float)Math.Atan2(dir.x,dir.y)*180.0f/3.1415926f+180.0f,0.0f);
            Rigidbody brb = GetComponent<Rigidbody>();
            brb.angularVelocity = new();

    }
    
}
