﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour 
{
	Animator animator;
	PlayerController playerController;

	void Start()
	{
		animator = GetComponent<Animator> ();
		playerController = GetComponent<PlayerController> ();
		playerController.EventOnMove.AddListener (AnimationTrigger);
	}

	void FixedUpdate()
	{
		animator.SetBool ("IsWalking", false);
		animator.SetFloat ("X", playerController.direction.x);
		animator.SetFloat ("Y", playerController.direction.y);
	}

	void AnimationTrigger()
	{
		animator.SetBool ("IsWalking", true);
	}

}