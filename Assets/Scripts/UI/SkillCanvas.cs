using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all skills and rank

public class SkillCanvas : CanvasBase
{
	public GameObject SkillPrefab;
	public GameObject SkillSpacerPrefab;
	public Transform SkillRootLeft; //art, social, trade skills
	public Transform SkillRootRight; //martial, scholar skills

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		if (!visible){return;}

		DisplayList();
	}

	public void DisplayList()
	{
		var skills = GameInstance.Instance.LoadedCharacterData.Skills;

		SkillRootLeft.DestroyChildren();
		SkillRootRight.DestroyChildren();

		for (int i = 0;i<13;i++)
		{
			var go = Instantiate(SkillPrefab,SkillRootLeft);
			go.GetComponent<SkillLabel>().SetSkillLabel(skills[i]);
			if (i == 3 || i == 7)
				Instantiate(SkillSpacerPrefab,SkillRootLeft);
		}

		for (int i = 13;i<skills.Count;i++)
		{
			var go = Instantiate(SkillPrefab,SkillRootRight);
			go.GetComponent<SkillLabel>().SetSkillLabel(skills[i]);
			if (i == 18)
				Instantiate(SkillSpacerPrefab,SkillRootRight);
		}
	}
}
