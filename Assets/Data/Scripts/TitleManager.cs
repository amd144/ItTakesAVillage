﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

	public InputField text;
	public Button apply;
	public Canvas canvas;
	
	private InputField character;
	private Button save;

	public void NewGame() {
		if (character == null) {
			character = Instantiate (text) as InputField;
			save = Instantiate (apply) as Button;

			character.transform.SetParent(canvas.transform);
			save.transform.SetParent(canvas.transform);

			character.GetComponent<RectTransform>().localPosition = new Vector2(-50, -200);
			save.GetComponent<RectTransform>().localPosition = new Vector2(100, -200);

			save.onClick.AddListener(() => StartGame());
			save.onClick.AddListener(() => GameControl.control.LoadNextScreen("Overworld"));
		}
	}

	public void StartGame() {
		GameControl.control.save_name = character.text;
	}

	/**
	 * Sets the save name and loads that save
	 */
	public void SetSave(Button b) {
		string name = b.GetComponentInChildren<Text>().text;
		if (name != "Empty") {
			GameControl.control.save_name = name;
			GameControl.control.Load ();
		} else { // Prompt name
			NewGame ();
		}
	}
}
