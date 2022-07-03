using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReferenceData 
{
	public string Name;
	public Ring Ring;
	public string Description;
	public string Book;

	public ReferenceData (string name, Ring ring, string description)
	{
		Ring = ring;
		Description = description;
		Name = name;
	}
}
