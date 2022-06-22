using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all skills and rank

public class SkillCanvas : CanvasBase
{
	public GameObject SkillPrefab;
	public Transform SkillRoot;

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		if (!visible){return;}

		DisplayList();
	}

	public void DisplayList()
	{
		var skills = GameInstance.Instance.LoadedCharacterData.Skills;

		SkillRoot.DestroyChildren();

		foreach(var v in skills)
		{
			var go = Instantiate(SkillPrefab,SkillRoot);
			go.GetComponent<SkillLabel>().SetSkillLabel(v);
		}
	}
}
