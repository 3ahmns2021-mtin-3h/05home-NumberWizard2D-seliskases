using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    public GameObject backButton;
    public GameObject inputButtons;
    public TMP_InputField inputMin, inputMax;
    public TextMeshProUGUI textField;

    private int min, max, value;
    private int guess, tempGuess;
    private bool isPlaying;

    //Starts The Round. Refactored in OnEnable and 2 seperate methods to ensure proper code architecture
    private void OnEnable()
    {
        StartRound();
    }

    //Prepares Next Round
    private void StartRound()
    {
        value = Convert.ToInt32(GameManager.rangeIsChanging);
        isPlaying = false;

        inputButtons.SetActive(false);
        inputMin.gameObject.SetActive(true);
        inputMax.gameObject.SetActive(true);

        inputMin.text = "";
        inputMax.text = "";
        textField.text = "";
    }

    //Waits for Input to begin the round 
    private void Update()
    {
        if (!isPlaying && Input.GetKeyDown(KeyCode.Return) && int.TryParse(inputMin.text, out min) && int.TryParse(inputMax.text, out max))
        {
            min = int.Parse(inputMin.text);
            max = int.Parse(inputMax.text);

            inputMin.gameObject.SetActive(false);
            inputMax.gameObject.SetActive(false);
            inputButtons.SetActive(true);

            isPlaying = true;
            NextGuess();
        }
    }

    //Output
    private void WriteMessage(string msg)
    {
        textField.text = msg;
    }

    //Input
    public void Higher()
    {
        min = guess + value;
        NextGuess();
    }

    //Input
    public void Lower()
    {
        max = guess - value;
        NextGuess();
    }

    //Input
    public void Correct()
    {
        StartRound();
        WriteMessage("Brilliant! Let's try again!");
    }

    //Calculates the next guess and checks for contradictions
    private void NextGuess()
    {
        guess = (min + max) / 2;

        if(guess != tempGuess)
        {
            tempGuess = guess;
            WriteMessage("Is your number higher or lower than " + guess + "?");
        }
        else
        {
            StartCoroutine(ContradictionDetected());
        }
    }

    //When contradiction is detected, either restarts the game or closes the executable
    private IEnumerator ContradictionDetected()
    {
        if (GameManager.selfDestruction)
        {
            backButton.SetActive(false);
            inputButtons.SetActive(false);
            WriteMessage("You lied!");

            float time = 6;
            while (true)
            {
                time -= Time.deltaTime;

                if (time <= 6)
                {
                    textField.text = Mathf.FloorToInt(time).ToString();
                }

                if (time == 0)
                {
                    Application.Quit();
                    break;
                }
                yield return null;
            }
        }
        else
        {
            float time = 2;
            WriteMessage("The number isn't within your given Range!");

            while (true)
            {
                time -= Time.deltaTime;

                if(time <= 0)
                {
                    StartRound();
                }
            }
        }

    }
}
