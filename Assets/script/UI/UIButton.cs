using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Text _text; 

    private int _score = 0;
    
    public void onButtonClicked()
    {
        _score++;
        _text.text = $"Score : {_score}";
    }
}
