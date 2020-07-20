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
	public int AveragePointValue = 5;
	private int PointValueMultiplier = 5;
	public TMP_Text PointLabel;
	public int PointValue { get; private set; }
	private bool Collected = false;

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
			case TreasureSize.PILE: // PILE
				PileObject.SetActive(true);
				PointValueMultiplier = 10;
				break;
			case TreasureSize.HORDE: // HORDE
				HordeObject.SetActive(true);
				PointValueMultiplier = 50;
				break;
			default: // COINE
				CoinsObject.SetActive(true);
				PointValueMultiplier = 5;
				break;
		}

		// Set the point value based on the treasure size
		int min = Mathf.Max(0, AveragePointValue - 2);
		PointValue = Random.Range(min, AveragePointValue + 2) * PointValueMultiplier;

		// Set the point value label
		PointLabel?.SetText("+" + PointValue);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !Collected)
		{
			Collected = true;
			// Add points
			FindObjectOfType<Game>().SetPoints(FindObjectOfType<Game>().GetPoints() + PointValue);
		}
	}
}
