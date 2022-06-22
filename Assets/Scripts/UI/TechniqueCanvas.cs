using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//collapsable list of techniques
//reference to page and book

//school ability
//action + opportunities
//opportunities

public class TechniqueCanvas : CanvasBase {

	public GameObject TechniquePrefab;
	public Transform TechniqueRoot;

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		if (!visible){return;}

		DisplayList();
	}

	public void DisplayList()
	{
		var techs = GameInstance.Instance.LoadedCharacterData.Techniques;

		TechniqueRoot.DestroyChildren();

		foreach(var v in techs)
		{
			var go = Instantiate(TechniquePrefab,TechniqueRoot);
			go.GetComponent<TechniqueDescription>().SetTechnique(v);
		}
	}
}
