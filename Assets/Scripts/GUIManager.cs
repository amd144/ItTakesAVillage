﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public Text health;
	public Text energy;
	public Text experience;
	public Text label;

	void Update() {
		health.text = "Health: " + GameControl.control.GetHealth();
		energy.text = "Energy: " + GameControl.control.GetEnergy();
		experience.text = "Experience: " + GameControl.control.GetExperience ();
		label.text = GameControl.control.GetLabel ();
	}
}
