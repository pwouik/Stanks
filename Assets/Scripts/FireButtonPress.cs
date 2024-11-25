using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class FireButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject leftTank, rightTank;
    [SerializeField] private GameObject joyStickLeft, joyStickRight;
    [SerializeField] private GameObject leftCannonSound, rightCannonSound;
    [SerializeField] private GameObject obusPrefab;

    private float feedbackTimer = 0, flashDuration = .1f, soundDuration = 1f;

    private bool isLeftPlayerShooting = false, isRightPlayerShooting = false;

    void Start()
    {

        leftCannonSound.SetActive(false);
        rightCannonSound.SetActive(false);
        Debug.Log("Start");
    }

    void Update()
    {
        if (feedbackTimer <= soundDuration)
        {
            feedbackTimer += Time.deltaTime;
            if (feedbackTimer >= flashDuration && (isLeftPlayerShooting || isRightPlayerShooting))
            {
                isLeftPlayerShooting = false;
                isRightPlayerShooting = false;
            }
            else if (feedbackTimer >= soundDuration)
            {
                leftCannonSound.SetActive(false);
                rightCannonSound.SetActive(false);
            }
        }
    }

    public void LeftClick()
    {
        Debug.Log("left shoot");
        isLeftPlayerShooting = true;
        Feedback();
    }

    private void Feedback()
    {
        feedbackTimer = 0;
        if(isLeftPlayerShooting)
        {
            leftCannonSound.SetActive(true);
        }
        else if(isRightPlayerShooting)
        {
            rightCannonSound.SetActive(true);
        }

        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif
    }
}
