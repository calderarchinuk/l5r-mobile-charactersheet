using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Panel Colours", menuName = "Data/Panel Colours", order = 1)]
public class PanelColours : ScriptableObject
{
	public Color MainMenu;
	public Color Header;
	public Color Glory;
	public Color Techniques;
	public Color Roleplay;
	public Color Skills;
	public Color Items;
	public Color Reference;

	public Color Expandable;

	public Color Text;
	public Color ExpandableText;
}
