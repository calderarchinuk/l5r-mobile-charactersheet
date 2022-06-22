using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//the ui to display the technique data

public class DistinctionDescription : MonoBehaviour
{
	bool collapsed = true;
	public Image frame;

	public Image Ring;
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Description;

	public void SetData(DistinctionData data)
	{
		Name.text = data.Name;
		Description.text = ProjectUtilities.ParseText(data.Description);
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

		float targetSize = 400;
		if (flat)
		{
			targetSize = 160;
		}

		frame.GetComponent<RectTransform>().sizeDelta = new Vector2(1200,targetSize);
	}
}
