using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Treasure : MonoBehaviour
{
	public enum TreasureSize
	{
		COINS,
		PILE,
		HORDE
	}

	public TreasureSize Size = TreasureSize.COINS;
	public int PointValue = 5;
	public TMP_Text Label;
	// Physical object selection
	public GameObject CoinsObject;
	public GameObject PileObject;
	public GameObject HordeObject;

	// Start is called before the first frame update
	void Start()
    {
		// Enable the correct treasure size object
		switch (Size)
		{
			case TreasureSize.PILE:
				PileObject.SetActive(true);
				break;
			case TreasureSize.HORDE:
				HordeObject.SetActive(true);
				break;
			default:
				CoinsObject.SetActive(true);
				break;
		}

		 // Set the point value label
		Label?.SetText("+" + PointValue);
    }
}
