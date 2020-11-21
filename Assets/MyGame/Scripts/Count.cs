using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Count : MonoBehaviour
{
    public TMP_InputField inputNumber, inputMin, inputMax;
    public TextMeshProUGUI textField;

    private float number, min, max, range, maxCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (float.TryParse(inputNumber.text, out number) && float.TryParse(inputMin.text, out min) && float.TryParse(inputMax.text, out max))
            {
                number = float.Parse(inputNumber.text);
                min = float.Parse(inputMin.text);
                max = float.Parse(inputMax.text);
                range = max - min;

                if (number >= min && number <= max)
                {
                    if (GameManager.rangeIsChanging)
                    {
                        WriteMessage(CalculateCount(min, max).ToString());
                    }
                    else
                    {
                        WriteMessage(CalculateCount(min, max).ToString());
                    }
                }
                else
                {
                    WriteMessage("The number is not within your given Range!");
                }
            }
            else
            {
                WriteMessage("Input Error");
            }
        }
    }

    private void WriteMessage(string msg)
    {
        textField.text = msg;
    }

    private int CalculateCount(float tempMin, float tempMax)
    {
        float guess;
        int count = 0;
        int value = Convert.ToInt32(GameManager.rangeIsChanging);
        print(value);

        for (int n = 1; n <= CalculateMaxCount(); n++)
        {
            count = n;
            guess = Mathf.FloorToInt((tempMin + tempMax) / 2);

            if (guess > number)
            {
                tempMax = guess - value;
            }

            if (guess < number)
            {
                tempMin = guess + value;
            }

            if (guess == number)
            {
                break;
            }
        }
        return (count);
    }

    private float CalculateMaxCount()
    {
        float maxCount = Mathf.Ceil(Mathf.Log(range, 2));
        return (maxCount);
    }
}
