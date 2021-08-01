using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image Answer;
    public void ApllyToAnswer(Sprite sprite)
    {
        Answer.sprite = sprite;
    }
}
