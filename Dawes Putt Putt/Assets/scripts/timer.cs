    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class timer : MonoBehaviour {

    private float timerOne;
    private int score;
    private bool noTimeLeft;
    public Text timerText;
    public Text scoreText;
    public Text[] textArray;

	// Use this for initialization
	void Start () {

        timerOne = 10;
        score = 0;
        noTimeLeft = false;
		
	}

    public void StartGame()
    {
        Debug.Log("Start Game");
    }

    // Update is called once per frame
    void Update() {
        if(noTimeLeft == false)
        {
            timerOne -= Time.deltaTime;
        }

             if(Mathf.Round(timerOne) % 2 == 0)
        {
            if(noTimeLeft == false)
            {
                score++;
                // scoreText.text = score.ToString();
                textArray[1].text = score.ToString();
            }
          
        }

        // Debug.Log(timerOne);
        if (timerOne <= 0)
        {
            noTimeLeft = true;
            // timerText.text = "OUT OF TIME";
            textArray[0].text = "OUT OF TIME";
        }  
        else
        {
            // timerText.text = timerOne.ToString("0");
            textArray[0].text = timerOne.ToString("0");
        }
		
	}
}
