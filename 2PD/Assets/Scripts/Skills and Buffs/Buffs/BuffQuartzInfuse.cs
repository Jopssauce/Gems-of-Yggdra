﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffQuartzInfuse : BaseBuff 
{
    public float slowModifier = 0.2f;
    public float damageModifier = 0;
    public float tempModifier;
    float speed;
    float tempSpeed;
	public override void Activate(BuffReceiver receiver)
    {
       
        PlayerController player = receiver.GetComponent<PlayerController>();
        base.Activate(receiver);
        if (isActivated == true)
        {
            speed = player.playerSpeed;
            tempSpeed = player.playerSpeed * slowModifier;
            player.playerSpeed = tempSpeed; 
            
            tempModifier = player.GetComponent<PlayerStats>().fireModifier;
            player.GetComponent<PlayerStats>().fireModifier = damageModifier;
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
            player.playerSpeed = speed;
            tempSpeed = 0;
            player.GetComponent<PlayerStats>().fireModifier += tempModifier;
            Debug.Log("Undo" + this.name);
        }
    }
}