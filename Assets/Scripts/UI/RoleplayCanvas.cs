using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//advantages, disadvantages, anxieties, giri, ninjo
//maybe also list of bushido tenets

public class RoleplayCanvas : CanvasBase
{
	public GameObject DistinctionPrefab;
	public Transform DistinctionRoot;

	public override void GameInstance_OnGameStateChanged (GameState state)
	{
		SetVisible(true);
	}

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		if (!visible){return;}

		DisplayList();
	}

	public void DisplayList()
	{
		var techs = GameInstance.Instance.LoadedCharacterData.Distinctions;

		DistinctionRoot.DestroyChildren();

		foreach(var v in techs)
		{
			var go = Instantiate(DistinctionPrefab,DistinctionRoot);
			go.GetComponent<DistinctionDescription>().SetData(v);
		}
	}
}
