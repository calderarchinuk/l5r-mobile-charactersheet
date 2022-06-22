using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmorDisplay : MonoBehaviour
{
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Defense;
	public TextMeshProUGUI Keywords;

	public void SetData(ArmorData data)
	{
		Name.text = data.Name;
		Defense.text = data.Defense.ToString();
		string s = "";
		for(int i = 0;i<data.Keywords.Count;i++)
		{
			if (i != 0)
			{
				s+=", ";
			}
			s += data.Keywords[i];
		}
		Keywords.text = s;
	}
}
