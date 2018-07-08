﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class InteractableAltar : Interactable
{
	public BaseSkill skill;
	public BaseItem item;
	public bool giveToSpecificPlayer;
	public int playerID;

	public Sprite off;
	public Sprite on;
	public UnityEvent EventOnWrongPlayer;
	


	public override void Interact(GameObject obj)
	{
		PlayerController player = obj.GetComponent<PlayerController>();
		SkillActor actor = player.GetComponent<SkillActor>();
		Debug.Log(actor);
		if(!actor.skills.Any(item => item.ID == skill.ID) && !giveToSpecificPlayer) actor.AddSkill(skill);
		if(!actor.skills.Any(item => item.ID == skill.ID) && giveToSpecificPlayer)
		{
			if (player.ID == playerID && !isInteracted)
			{
				actor.AddSkill (skill);
				gameManager.sharedInventory.AddItem(item);
				GetComponent<SpriteRenderer>().sprite = on;
				isInteracted = true;
				EventActivated.Invoke(obj);
				EventInteracted.Invoke(obj);
			} 

			else
			{
				EventOnWrongPlayer.Invoke();
			}
			
		}
	}


	
}
