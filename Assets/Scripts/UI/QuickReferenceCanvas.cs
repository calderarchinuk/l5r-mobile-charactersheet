using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//status effects
//opportunities
//stance bonuses

public class QuickReferenceCanvas : CanvasBase
{
	public GameObject ReferencePrefab;
	public Transform ReferenceRoot;

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
		var references = GameInstance.Instance.GetReferenceData();
		if (references == null){return;}

		ReferenceRoot.DestroyChildren();
		foreach(var v in references)
		{
			var go = Instantiate(ReferencePrefab,ReferenceRoot);
			go.GetComponent<ReferenceDescription>().SetData(v);
		}
	}
}
