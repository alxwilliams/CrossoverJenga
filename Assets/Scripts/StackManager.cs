using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Piece piecePrefab;
    
    [Header("Stacks")]
    [SerializeField] private JengaStack sixthGradeStack;
    [SerializeField] private JengaStack seventhGradeStack;
    [SerializeField] private JengaStack eighthGradeStack;

    [Header("Materials")] 
    [SerializeField] private Material glassMat;
    [SerializeField] private Material woodMat;
    [SerializeField] private Material stoneMate;

    [Header("Jenga Piece Pool Parent")] 
    [SerializeField] private Transform piecePoolParent;

    private AllPieces allPieces;
    private List<Piece> glassPieces;
    
    public static StackManager I;

    public Transform PiecePoolParent
    {
        get => piecePoolParent;
        set => piecePoolParent = value;
    }

    private void Awake()
    {
        if(I == null)
        {
            I = this;
            glassPieces = new List<Piece>();
        }else
            Destroy(this);
    }

    public void SetAllPieces(AllPieces all)
    {
        allPieces = all;

        foreach (var piece in allPieces.list)
        {
            CreatePiece(piece);
        }
    }

    private void CreatePiece(JengaPiece piece)
    {
        Piece newPiece;
            
        if(piecePoolParent.childCount > 0)
            newPiece = piecePoolParent.GetChild(0).GetComponent<Piece>();
        else
        {
            newPiece = Instantiate(piecePrefab, piecePoolParent);
        }
        
        switch (piece.mastery)
        {
            case 0:
                if(newPiece.Type != PieceType.Glass)
                {
                    newPiece.SetText("");
                    newPiece.Type = PieceType.Glass;
                    newPiece.SetMaterial(glassMat);
                    glassPieces.Add(newPiece);
                }
                break;
            case 1:
                if (newPiece.Type != PieceType.Wood)
                {
                    newPiece.SetText("Learned");
                    newPiece.Type = PieceType.Wood;
                    newPiece.SetMaterial(woodMat);
                }
                break;
            case 2:
                if (newPiece.Type != PieceType.Stone)
                {
                    newPiece.SetText("Mastered");
                    newPiece.Type = PieceType.Stone;
                    newPiece.SetMaterial(stoneMate);
                }

                break;
        }

        switch (piece.grade)
        {
            case Grades.SIXTH_GRADE:
                sixthGradeStack.AddPiece(newPiece);
                break;
            case Grades.SEVENTH_GRADE:
                seventhGradeStack.AddPiece(newPiece);
                break;
            case Grades.EIGH_GRADE:
                eighthGradeStack.AddPiece(newPiece);
                break;
        }

    }
}
