using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class TankController : MonoBehaviour
{

    [SerializeField] private GameObject obus;

    [SerializeField] private float player_speed = 1f;
    private Vector2 dir;
    public void SetDir(Vector2 d){
        dir = d;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody brb = GetComponent<Rigidbody>();
        brb.velocity = new Vector3(dir.x,0,dir.y) * player_speed;
    }
}
