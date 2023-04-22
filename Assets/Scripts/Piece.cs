using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PieceType
{
    Nothing,
    Glass,
    Wood,
    Stone
}

public class Piece : MonoBehaviour
{
    [SerializeField] private TMP_Text frontText;
    [SerializeField] private TMP_Text backText;
    [SerializeField] private MeshRenderer renderer;
    

    private PieceType type = PieceType.Nothing;

    public PieceType Type
    {
        get => type;
        set => type = value;
    }
    public void SetText(string value)
    {
        
        frontText.text = value;
        backText.text = value;
    }

    public void SetMaterial(Material mat)
    {
        renderer.material = mat;
    }

    public void DeactivatePiece()
    {
        gameObject.SetActive(false);
        transform.parent = StackManager.I.PiecePoolParent;
    }


}
