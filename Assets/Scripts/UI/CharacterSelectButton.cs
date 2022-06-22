using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectButton : MonoBehaviour
{
	string FileSource;
	public TextMeshProUGUI Text;

	//some event system callback??
	public void SetSource(string source)
	{
		FileSource = source;
		Text.text = System.IO.Path.GetFileNameWithoutExtension(source).Replace("-"," ");
	}

	public void Button_LoadCharacter()
	{
		GameInstance.Instance.LoadCharacter(FileSource);
	}
}
