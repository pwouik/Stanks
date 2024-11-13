using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject leftTank, rightTank;
    [SerializeField] private GameObject leftFeedbackFlash, rightFeedbackFlash;
    [SerializeField] private GameObject leftCannonSound, rightCannonSound;

    private float feedbackTimer = 0, flashDuration = .1f, soundDuration = 1f;

    private bool isLeftPlayerShooting = false, isRightPlayerShooting = false;

    void Start()
    {
        leftFeedbackFlash.SetActive(false);
        rightFeedbackFlash.SetActive(false);
        leftCannonSound.SetActive(false);
        rightCannonSound.SetActive(false);
    }

    void Update()
    {
        // PC
        if (Input.GetMouseButtonDown(0))
            HandleInput(Input.mousePosition);

        // Android
        foreach (Touch touch in Input.touches)
            if (touch.phase == TouchPhase.Began)
                HandleInput(touch.position);

        if (feedbackTimer <= soundDuration)
        {
            feedbackTimer += Time.deltaTime;
            if (feedbackTimer >= flashDuration && (isLeftPlayerShooting || isRightPlayerShooting))
            {
                isLeftPlayerShooting = false;
                isRightPlayerShooting = false;
                leftFeedbackFlash.SetActive(false);
                rightFeedbackFlash.SetActive(false);
            }
            else if (feedbackTimer >= soundDuration)
            {
                leftCannonSound.SetActive(false);
                rightCannonSound.SetActive(false);
            }
        }
    }

    private void HandleInput(Vector2 position)
    {
        if (IsInLeftTankFireZone(position))
        {
            Debug.Log("left shoot");
            isLeftPlayerShooting = true;
            Feedback();
        }
        else if (IsInRightTankFireZone(position))
        {
            Debug.Log("right shoot");
            isRightPlayerShooting = true;
            Feedback();
        }
    }

    private bool IsInLeftTankFireZone(Vector2 position)
    {
        return position.x < Screen.width / 2 && position.y < Screen.height / 2;
    }

    private bool IsInRightTankFireZone(Vector2 position)
    {
        return position.x > Screen.width / 2 && position.y > Screen.height / 2;
    }

    private void Feedback()
    {
        feedbackTimer = 0;
        if(isLeftPlayerShooting)
        {
            leftFeedbackFlash.SetActive(true);
            leftCannonSound.SetActive(true);
        }
        else if(isRightPlayerShooting)
        {
            rightFeedbackFlash.SetActive(true);
            rightCannonSound.SetActive(true);
        }

        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif
    }
}
