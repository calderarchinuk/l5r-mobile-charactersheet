using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO button to damage/destroy an item

[System.Serializable]
public class ArmorData
{
	public string Name;
	public int Defense;
	public List<string> Keywords;

	public ArmorData(string name, int defense, List<string> keywords)
	{
		Name = name;
		Defense = defense;
		Keywords = keywords;
	}
}
