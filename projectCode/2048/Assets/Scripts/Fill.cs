using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    public int value;
    [SerializeField] Text valueDisplay;
    [SerializeField] float speed;

    bool hasCombined;

    Image myImage;

    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = value.ToString();

        int colorIndex = GetColorIndex(value);
        myImage = GetComponent<Image>();
        if (colorIndex >= GameController.instance.fillColors.Length)
        {
            myImage.color = GameController.instance.defaultColor;
        }
        else
        {
            myImage.color = GameController.instance.fillColors[colorIndex];
        }
    }

    int GetColorIndex(int valueIn)
    {
        int index = 0;
        while (valueIn != 1)
        {
            index++;
            valueIn /= 2;
        }

        index--;
        return index;
    }

    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            hasCombined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (hasCombined == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombined = true;
        }
    }

    public void Double()
    {
        value *= 2;
        GameController.instance.ScoreUpdate(value);
        valueDisplay.text = value.ToString();

        int colorIndex = GetColorIndex(value);
        if (colorIndex >= GameController.instance.fillColors.Length)
        {
            myImage.color = GameController.instance.defaultColor;
        }
        else
        {
            myImage.color = GameController.instance.fillColors[colorIndex];
        }

        GameController.instance.WinningCheck(value);
    }
}
