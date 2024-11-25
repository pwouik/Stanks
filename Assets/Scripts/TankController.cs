using System;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class TankController : MonoBehaviour
{

    [SerializeField] private GameObject obus;

    [SerializeField] private float player_speed = 1f;
    private Vector2 dir;
    public void SetDir(Vector2 d){
        dir = d * player_speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody brb = GetComponent<Rigidbody>();
        brb.velocity = new Vector3(dir.x,brb.velocity.y,dir.y);
    }
    void Update(){
        if(dir.magnitude>0.001)
            transform.rotation = Quaternion.Euler(0.0f,(float)Math.Atan2(dir.x,dir.y)*180.0f/3.1415926f+180.0f,0.0f);
    }
}
