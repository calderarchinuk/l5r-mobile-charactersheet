using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//the ui to display the technique data

public class TechniqueDescription : MonoBehaviour
{
	bool collapsed = true;
	public Image frame;

	public Image Ring;
	public TextMeshProUGUI TechName;
	public TextMeshProUGUI TechAction;
	public TextMeshProUGUI TechEffect;
	public TextMeshProUGUI TechOpportunity;

	public void SetTechnique(TechniqueData data)
	{
		if (data.ActionTechnique)
		{
			//display action
		}

		TechName.text = data.Name;
		TechAction.text = ProjectUtilities.ParseText(data.Activation);
		TechEffect.text = ProjectUtilities.ParseText(data.Effect);
		TechOpportunity.text = ProjectUtilities.ParseText(data.Opportunity);
		Ring.sprite = ProjectUtilities.GetRingSprite(data.Ring);
		SetCollapsed(true);
	}

	public void Button_ToggleCollapse()
	{
		collapsed = !collapsed;
		SetCollapsed(collapsed);
	}

	public void SetCollapsed(bool flat)
	{
		//160 collapsed
		//800 uncollapsed

		float targetSize = 800;
		if (flat)
		{
			targetSize = 160;
		}

		frame.GetComponent<RectTransform>().sizeDelta = new Vector2(1200,targetSize);
	}
}
