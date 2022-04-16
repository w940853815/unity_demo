using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtn : MonoBehaviour
{
	// Start is called before the first frame update
	private Button btn;
	void Start()
	{
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		GameObject.Find("Sphere").SendMessage("ResetPoint");
	}

}
