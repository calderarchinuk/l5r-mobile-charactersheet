using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//collapsable data for all anxieties, advantages, disadvantages
//

public enum DistinctionType
{
	Distinction,
	Adversity,
	Passion,
	Disadvantage,
	NinjoDesire,
	GiriDuty
}

[System.Serializable]
public class DistinctionData 
{
	public string Name;
	//public DistinctionType Type;
	public Ring Ring;
	public string Description;
	//public string Book;

	public DistinctionData(string name, Ring ring, string description, DistinctionType type)
	{
		//Type = type;
		Ring = ring;
		Description = description;
		Name = name;
	}
}
