﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TipsJournal : MonoBehaviour {

	public Text textboxTips;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		displayTips ();
	}

	public void displayTips() {
				string tips = File.ReadAllText (/*text file containing NPC dialog*/);
				textboxTips.text = tips + "\r\n";
		}

}
