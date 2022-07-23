using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillLabel : MonoBehaviour
{
	public TextMeshProUGUI SkillName;
	public TextMeshProUGUI SkillLevel;
	public TextMeshProUGUI SkillGroup;
	public Image Circle;

	public void SetSkillLabel(SkillData data)
	{
		SkillName.text = data.Name;
		SkillLevel.text = data.Level.ToString();
		SkillGroup.text = data.Group;

		if (data.Level == 0)
		{
			Circle.color = new Color(1,1,1,0.2f);
			SkillLevel.color = new Color(0,0,0,0.2f);
		}
	}
}
