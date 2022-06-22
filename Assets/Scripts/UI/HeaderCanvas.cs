using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//name, honor, glory, status

//rings
//fatigue and strife
//void points

public class HeaderCanvas : CanvasBase
{
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Glory;
	public TextMeshProUGUI Honor;
	public TextMeshProUGUI Status;
	public TextMeshProUGUI Vigilance;
	public TextMeshProUGUI Focus;

	public TextMeshProUGUI AirRing;
	public TextMeshProUGUI EarthRing;
	public TextMeshProUGUI FireRing;
	public TextMeshProUGUI WaterRing;
	public TextMeshProUGUI VoidRing;

	public TextMeshProUGUI MaxFatigue;
	public TextMeshProUGUI CurrentFatigue;

	public TextMeshProUGUI MaxStrife;
	public TextMeshProUGUI CurrentStrife;

	public TextMeshProUGUI MaxVoid;
	public TextMeshProUGUI CurrentVoid;

	public override void GameInstance_OnGameStateChanged (GameState state)
	{
		if (state == GameState.CharacterSheet)
		{
			SetVisible(true);
			Name.text = GameInstance.Instance.LoadedCharacterData.Name;
			Glory.text = "Glory: "+GameInstance.Instance.LoadedCharacterData.Glory.ToString();
			Honor.text = "Honor: "+GameInstance.Instance.LoadedCharacterData.Honor.ToString();
			Status.text = "Status: "+GameInstance.Instance.LoadedCharacterData.Status.ToString();
			Vigilance.text = "Vigilance "+GameInstance.Instance.LoadedCharacterData.Vigilance.ToString();
			Focus.text = "Focus: " + GameInstance.Instance.LoadedCharacterData.Focus.ToString();

			AirRing.text = GameInstance.Instance.LoadedCharacterData.AirRing.ToString();
			EarthRing.text = GameInstance.Instance.LoadedCharacterData.EarthRing.ToString();
			FireRing.text = GameInstance.Instance.LoadedCharacterData.FireRing.ToString();
			WaterRing.text = GameInstance.Instance.LoadedCharacterData.WaterRing.ToString();
			VoidRing.text = GameInstance.Instance.LoadedCharacterData.VoidRing.ToString();

			MaxFatigue.text = "/"+GameInstance.Instance.LoadedCharacterData.Endurance.ToString();
			CurrentFatigue.text = GameInstance.Instance.LoadedCharacterData.CurrentFatigue.ToString();

			MaxStrife.text = "/"+GameInstance.Instance.LoadedCharacterData.Composure.ToString();
			CurrentStrife.text = GameInstance.Instance.LoadedCharacterData.CurrentStrife.ToString();

			MaxVoid.text = "/"+GameInstance.Instance.LoadedCharacterData.MaxVoid.ToString();
			CurrentVoid.text = GameInstance.Instance.LoadedCharacterData.CurrentVoid.ToString();
		}
		else
		{
			SetVisible(false);
		}
	}
}
