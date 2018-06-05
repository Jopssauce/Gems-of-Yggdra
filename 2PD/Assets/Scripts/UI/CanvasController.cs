﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour {

	GameManager gameManager;

	public TextMeshProUGUI player1Health;
	public TextMeshProUGUI player2Health;
	public Image player1HpBar;
	public Image player2HpBar;

	public TextMeshProUGUI sharedGold;

	public GameObject encyclopedia;

	// Use this for initialization
	void Start () 
	{
		gameManager = UIManager.instance.gameManager;
		foreach (var player in gameManager.playerList)
		{
			player.GetComponent<PlayerStats>().EventOnStatChanged.AddListener(UpdateUIText);
		}
		UpdateUIText();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			encyclopedia.GetComponent<Animator>().SetTrigger("Open");
		}
	}

	
	void UpdateUIText()
	{
		player1Health.text = gameManager.playerList[0].GetComponent<PlayerStats>().hp.ToString();
		sharedGold.text = gameManager.sharedInventory.GetComponent<Currency>().gold.ToString();
		player2Health.text = gameManager.playerList[1].GetComponent<PlayerStats>().hp.ToString();


		
		player1HpBar.fillAmount = gameManager.playerList[0].GetComponent<PlayerStats>().hp / gameManager.playerList[0].GetComponent<PlayerStats>().maxHp;
		player2HpBar.fillAmount = gameManager.playerList[1].GetComponent<PlayerStats>().hp / gameManager.playerList[1].GetComponent<PlayerStats>().maxHp;
	}
}
