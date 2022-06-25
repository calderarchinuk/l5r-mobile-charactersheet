using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectUtilities : MonoBehaviour
{
	public TMP_SpriteAsset spriteAsset;

	public Sprite[] ringSprites;

	static ProjectUtilities instance;
	void Start ()
	{
		instance = this;
	}

	public static string ParseText(string inText)
	{
		//replace $earth, $opportunity, $strife, etc with <sprite=2> as necessary

		inText = inText.Replace("$air","<sprite=3>");
		inText = inText.Replace("$earth","<sprite=0>");
		inText = inText.Replace("$fire","<sprite=1>");
		inText = inText.Replace("$water","<sprite=2>");
		inText = inText.Replace("$void","<sprite=7>");
		inText = inText.Replace("$none","<sprite=9>");

		inText = inText.Replace("$success","<sprite=5>");
		inText = inText.Replace("$strife","<sprite=4>");
		inText = inText.Replace("$opportunity","<sprite=6>");
		inText = inText.Replace("$critical","<sprite=8>");
		return inText;
	}

	public static Sprite GetRingSprite(Ring ring)
	{
		switch (ring)
		{
			case Ring.Air:return instance.ringSprites[0];
			case Ring.Earth:return instance.ringSprites[1];
			case Ring.Fire:return instance.ringSprites[2];
			case Ring.Water:return instance.ringSprites[3];
			case Ring.Void:return instance.ringSprites[4];
			case Ring.None:return instance.ringSprites[5];
		}
		return instance.ringSprites[5];
	}
}
