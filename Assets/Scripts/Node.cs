using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Node : MonoBehaviour {
	enum Sex {
		MALE, FEMALE
	};

	//accessible fields
	[SerializeField]
	string personName = "";

	[SerializeField]
	Sex sex = Sex.MALE;

	[SerializeField]
	[TextArea]
	string notes = "";

	//internals
	[Header("Internals")]
	public Sprite maleSprite;
	public Sprite femaleSprite;

	Image sexImage;
	TextMeshProUGUI TMProName;
	TextMeshProUGUI TMProNotes;

	void Awake() {
		sexImage = GetComponent<Image>();

		TMProName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		TMProNotes = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
	}

	void Update() {
		//male sprite
		if (sex == Sex.MALE && sexImage.sprite != maleSprite) {
			sexImage.sprite = maleSprite;
		}

		//female sprite
		if (sex == Sex.FEMALE && sexImage.sprite != femaleSprite) {
			sexImage.sprite = femaleSprite;
		}

		//name
		TMProName.text = personName;

		//notes
		TMProNotes.text = notes;
	}
}