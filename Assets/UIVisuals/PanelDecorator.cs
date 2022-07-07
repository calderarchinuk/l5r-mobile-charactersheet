using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DecoratorType
{
	MainMenu = 0,
	Header = 1,
	Glory = 2,
	Techniques = 3,
	Roleplay = 4,
	Skills = 5,
	Reference = 6,
	Items = 7,

	Expandable = 8, //distinctions, techniques, text areas. buttons? white by default
	Text = 9, //name, other text. white by default
	ExpandableText = 10, //text on expandable thigns. black by default
}

public class PanelDecorator : MonoBehaviour
{
	public DecoratorType type;
	void Start()
	{
		var colours = ProjectUtilities.GetPanelColours();

		var image = GetComponent<Image>();
		var text = GetComponent<TMPro.TextMeshProUGUI>();
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
			image.color = colours.Techniques;
			break;
		case DecoratorType.Roleplay:
			image.color = colours.Roleplay;
			break;
		case DecoratorType.Reference:
			image.color = colours.Reference;
			break;
		case DecoratorType.Skills:
			image.color = colours.Skills;
			break;
		case DecoratorType.Items:
			image.color = colours.Items;
			break;
		case DecoratorType.Expandable:
			image.color = colours.Expandable;
			break;
		case DecoratorType.Text:
			text.color = colours.Text;
			break;
		case DecoratorType.ExpandableText:
			text.color = colours.ExpandableText;
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}
	}
}
