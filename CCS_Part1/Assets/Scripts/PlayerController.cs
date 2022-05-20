using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camPos;
    public float forwardSpeed;
    public float turnSmoothTime = 0.1f;

    Vector3 touchBeganPoint;

    CharacterController controller;

    float turnSpeedVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AddScoreItem")
        {
            AddScore();
            FindObjectOfType<CreateScore>().controllerInt -= 1;
            Destroy(other.gameObject);
        }
        else
        {
            return;
        }
    }

    private void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float horizontal = touch.position.x;
            float vertical = touch.position.y;
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (touch.phase == TouchPhase.Began)
            {
                touchBeganPoint = new Vector3(touch.position.x, touch.position.y, 0f);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                float hhorizontal = touch.position.x - touchBeganPoint.x;
                float vvertical = touch.position.y - touchBeganPoint.y;
                Vector3 ddirection = new Vector3(hhorizontal, 0f, vvertical).normalized;

                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(ddirection.x, ddirection.z) * Mathf.Rad2Deg + camPos.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeedVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDirection * forwardSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void AddScore()
    {
        FindObjectOfType<GameManager>().scoreInt += 10;
    }
}

/*
           if (direction.magnitude >= 0.1f)
           {
               float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camPos.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeedVelocity, turnSmoothTime);
               transform.rotation = Quaternion.Euler(0f, angle, 0f);

               controller.Move(direction * forwardSpeed * Time.fixedDeltaTime);
           }*/

/*
        direction.z = forwardSpeed;

        if (Input.GetMouseButton(0))
        {
            controller.Move(direction * Time.fixedDeltaTime);
        }*/