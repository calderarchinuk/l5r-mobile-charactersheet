using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DecoratorType
{
	MainMenu,
	Header,
	Glory,
	Techniques,
	Roleplay,
	Skills,

	ItemsWeapons,
	ItemsArmour,
	ItemsOther,
	ItemsBackground,

	Expandable, //distinctions, techniques, text areas. buttons? white by default

	Text, //name, other text. white by default
	ExpandableText, //text on expandable thigns. black by default
}

public class PanelDecorator : MonoBehaviour
{
	public PanelColours colours;
	public DecoratorType type;
	void Start()
	{
		//TODO assign all text to some value

		var image = GetComponent<Image>();
		switch (type) {
		case DecoratorType.MainMenu:
			image.color = colours.MainMenu;
			break;
		case DecoratorType.Header:
			image.color = colours.Header;
			break;
		case DecoratorType.Glory:
			image.color = colours.Glory;
			break;
		case DecoratorType.Techniques:
			image.color = colours.Text;
			break;
		case DecoratorType.Roleplay:
			image.color = colours.Roleplay;
			break;
		case DecoratorType.Skills:
			image.color = colours.Skills;
			break;
		case DecoratorType.ItemsWeapons:
			image.color = colours.ItemsWeapons;
			break;
		case DecoratorType.ItemsArmour:
			image.color = colours.ItemsArmour;
			break;
		case DecoratorType.ItemsOther:
			image.color = colours.ItemsOther;
			break;
		case DecoratorType.ItemsBackground:
			image.color = colours.ItemsBackground;
			break;
		case DecoratorType.Expandable:
			
			break;
		case DecoratorType.Text:
			break;
		case DecoratorType.ExpandableText:
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}
	}
}
