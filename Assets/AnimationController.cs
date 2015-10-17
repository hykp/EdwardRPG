﻿using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public bool isIdle;
    bool isMoving;
    bool facingRight;

    // Use this for initialization
    void Start()
    {
        isIdle = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIdle();

        MoveEdward();
        anim.SetBool("isMoving", isMoving);
    }

    void CheckIdle()
    {
        if (GameObject.Find("MovementJoy").GetComponent<JoystickScripts>().GetIsActive())
            isMoving = true;
        else
            isMoving = false;
    }

    void MoveEdward()
    {
        Vector3 moveDir = GameObject.Find("MovementJoy").GetComponent<JoystickScripts>().getDirectionVector(GameObject.Find("MovementJoy").transform.position);
        GameObject.Find("SpriteContainer").transform.position += moveDir * .02f;


        if ((moveDir.x < 0 & facingRight) || (moveDir.x >= 0 & !facingRight))
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = GameObject.Find("SpriteContainer").transform.localScale;
        scale.x *= -1;
        GameObject.Find("SpriteContainer").transform.localScale = scale;
    }
}
