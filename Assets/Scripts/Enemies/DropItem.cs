using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem {

	GameObject theItem;
	float dropRate;

	public DropItem(GameObject theItem, float dropRate){
		this.theItem = theItem;
		this.dropRate = dropRate;
	}
}
