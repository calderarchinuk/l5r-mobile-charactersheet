using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuCanvas : CanvasBase
{
	public GameObject CharacterPrefab;
	public Transform CharacterListRoot;
	public TMP_InputField DownloadInputField;
	public TextMeshProUGUI debuggui;
	public GameObject PathButton;
	public GameObject Particles;

	public override void GameInstance_OnGameStateChanged (GameState state)
	{
		if (state == GameState.Menu)
		{
			SetVisible(true);
			DisplayCharacterList();
		}
		else
		{
			SetVisible(false);
		}
	}

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		Particles.SetActive(visible);
	}

	public void Initialize()
	{
		//get path from preferences (if it exists)
		if (PlayerPrefs.HasKey("characterpath"))
		{
			var savedPath = PlayerPrefs.GetString("characterpath","/sdcard/download/L5R/");
			GameInstance.Instance.SetPath(savedPath);
			PathButton.SetActive(true);
			DownloadInputField.gameObject.SetActive(false);
		}

		debuggui.text = "";
		DownloadInputField.text = GameInstance.Instance.GetPath();
	}

	public void Button_OpenPathInputField()
	{
		PathButton.SetActive(false);
		DownloadInputField.gameObject.SetActive(true);
	}

	public void Button_UpdatePath(string path)
	{
		CharacterListRoot.DestroyChildren();

		if (!System.IO.Directory.Exists(path))
		{
			debuggui.text = "Directory does not exist";
			return;
		}

		GameInstance.Instance.SetPath(path);

		var files = GameInstance.Instance.GetFiles();
		if (files.Length == 0)
		{
			debuggui.text = "No character data at path";
		}
		else
		{
			debuggui.text = "";
			DisplayCharacterList();
			PlayerPrefs.SetString("characterpath",path);
		}
	}

	public void DisplayCharacterList()
	{
		var files = GameInstance.Instance.GetFiles();

		CharacterListRoot.DestroyChildren();

		foreach(var v in files)
		{
			var go = Instantiate(CharacterPrefab,CharacterListRoot);
			go.GetComponent<CharacterSelectButton>().SetSource(v);
		}
	}
}
