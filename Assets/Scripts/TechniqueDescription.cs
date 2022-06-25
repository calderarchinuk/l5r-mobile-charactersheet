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
	public TextMeshProUGUI TechActionTitle;
	public TextMeshProUGUI TechEffect;
	public TextMeshProUGUI TechEffectTitle;
	public TextMeshProUGUI TechOpportunity;
	public TextMeshProUGUI TechOpportunityTitle;

	public void SetTechnique(TechniqueData data)
	{
		if (string.IsNullOrEmpty(data.Activation))
		{
			TechActionTitle.gameObject.SetActive(false);
			TechAction.gameObject.SetActive(false);
		}
		if (string.IsNullOrEmpty(data.Effect))
		{
			TechEffectTitle.gameObject.SetActive(false);
			TechEffect.gameObject.SetActive(false);
		}
		if (string.IsNullOrEmpty(data.Opportunity))
		{
			TechOpportunityTitle.gameObject.SetActive(false);
			TechOpportunity.gameObject.SetActive(false);
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
