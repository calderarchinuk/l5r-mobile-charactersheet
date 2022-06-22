using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillLabel : MonoBehaviour
{
	public TextMeshProUGUI SkillName;
	public TextMeshProUGUI SkillLevel;
	public TextMeshProUGUI SkillGroup;

	public void SetSkillLabel(SkillData data)
	{
		SkillName.text = data.Name;
		SkillLevel.text = data.Level.ToString();
		SkillGroup.text = data.Group;
	}
}
