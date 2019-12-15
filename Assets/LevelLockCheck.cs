using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLockCheck : MonoBehaviour
{
	public Button myButton;
	public int index; 

	void Start()
	{
		index =  int.Parse (myButton.GetComponentInChildren<Text> ().text);

		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		if (CustomPlayerPrefs.LevelPotence () >= index + 1) {
			SceneManager.LoadScene (index + 2);
		} 
		else {
			myButton.transform.Rotate(new Vector3 (0f, 0f, 360f));
		}
	}
}