﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDiamondInfuse : BaseBuff {

	public GameObject melee;
    GameObject temp;
    public override void Activate(BuffReceiver receiver)
    {
        base.Activate(receiver);
        receiver.GetComponent<SpriteRenderer>().color = color;
        MeleeCombat combat = receiver.GetComponent<MeleeCombat>();
        if (isActivated == true)
        {
            if(!receiver.GetComponent<MeleeCombat>()) return;
            temp = combat.objPrefab;
            combat.objPrefab = melee;
            Debug.Log("Do" + this.name);
        }
         if (isActivated == false)
        {
            combat.objPrefab = temp;
            temp = null;
            Debug.Log("Undo" + this.name);
        }
    }
}
