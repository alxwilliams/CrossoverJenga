using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PieceType
{
    Glass,
    Wood,
    Stone
}

public class Piece : MonoBehaviour
{
    [SerializeField] private TMP_Text frontText;
    [SerializeField] private TMP_Text backText;

    private PieceType type;

    public PieceType Type
    {
        get => type;
        set
        {
            type = value;
            SetType();
        }
    }

    private void SetText(string value)
    {
        
        frontText.text = value;
        backText.text = value;
    }

    private void SetType()
    {
        switch (type)
        {
            case PieceType.Glass:
                SetText("");
                break;
            case PieceType.Wood:
                SetText("Learned");
                break;
            case PieceType.Stone:
                SetText("Mastered");
                break;
        }
    }

}
