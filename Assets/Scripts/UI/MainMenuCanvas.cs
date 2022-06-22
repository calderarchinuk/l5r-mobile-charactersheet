using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : CanvasBase
{
	public GameObject CharacterPrefab;
	public Transform CharacterListRoot;

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
