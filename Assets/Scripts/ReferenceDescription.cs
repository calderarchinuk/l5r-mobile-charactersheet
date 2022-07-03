using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//the ui to display the reference data

public class ReferenceDescription : MonoBehaviour
{
	bool collapsed = true;
	public Image frame;

	public Image Ring;
	public TextMeshProUGUI Name;
	public TextMeshProUGUI DescriptionTitle;
	public TextMeshProUGUI Description;

	float preferredHeight;
	[ContextMenu("calculate height")]
	void CalculateHeight()
	{
		float space = 20;

		float preferredChildHeight = 160; //header

		preferredChildHeight += DescriptionTitle.preferredHeight;
		preferredChildHeight += Description.preferredHeight;
		preferredChildHeight += space;

		preferredHeight = preferredChildHeight;
	}

	public void SetData(ReferenceData data)
	{
		Name.text = data.Name;
		Description.text = ProjectUtilities.ParseText(data.Description);
		Ring.sprite = ProjectUtilities.GetRingSprite(data.Ring);
		SetCollapsed(true);
		CalculateHeight();
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

		float targetSize = preferredHeight;
		if (flat)
		{
			targetSize = 160;
		}

		frame.GetComponent<RectTransform>().sizeDelta = new Vector2(1200,targetSize);
	}
}
