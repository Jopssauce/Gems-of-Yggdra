﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class HealingAura : MonoBehaviour 
{
	public bool isActivated;
	public bool autoDeactivate;
	public BaseBuff buff;
	public List<PlayerController> players;

	public UnityEvent EventActivate;
	public UnityEvent EventDeactivate;

	public UnityEvent EventOnActivate;
	public UnityEvent EventOnDeactivate;

	void Start()
	{
		EventActivate.AddListener(Activate);
		EventDeactivate.AddListener(Deactivate);
	}

	void LateUpdate()
	{
		if(isActivated == false) return; 
		foreach (var item in players)
		{
			if(item == null) continue;
			BuffReceiver receiver = item.GetComponent<BuffReceiver>();
			if(receiver.gameObject == null) return;
			if (receiver.buffs.Any(p => p.buffType == buff.buffType) == true)
			{
				if(receiver.gameObject == null) return;
				return;
			}
			if (receiver.buffs.Any(p => p.ID == buff.ID) == false)
			{
				receiver.AddBuff(buff);
			}
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		BuffReceiver receiver = col.GetComponent<BuffReceiver>();
		if(receiver == null) return;
		players.Add(receiver.GetComponent<PlayerController>());
		
	}

	public virtual void OnTriggerExit2D(Collider2D col)
	{
		BuffReceiver receiver = col.GetComponent<BuffReceiver>();
		if(receiver == null) return;
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
		}
		if (players.Count == 0 && autoDeactivate)
		{
			EventDeactivate.Invoke();
		}
		
	}

	public virtual void Activate()
	{
		if (!isActivated)
		{
			isActivated = true;
			EventOnActivate.Invoke();
		}
		
	}

	public virtual void Deactivate()
	{
		if (isActivated)
		{
			isActivated = false;
			EventOnDeactivate.Invoke();
		}
	}
	
	
}
