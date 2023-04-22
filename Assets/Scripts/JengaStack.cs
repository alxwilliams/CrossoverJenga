using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaStack : MonoBehaviour
{
    private List<Piece> pieceList;
    
    private void Start()
    {
        pieceList = new List<Piece>();
    }

    public void AddPiece(Piece piece)
    {
        pieceList.Add(piece);
        piece.transform.parent = transform;
        
        switch (pieceList.Count % 3 )
        {
            case 1:
                piece.transform.position = transform.position - (Vector3.forward * piece.transform.localScale.z);
                break;
            case 2:
                piece.transform.position = transform.position;
                break;
            case 0:
                piece.transform.position = transform.position + (Vector3.forward * piece.transform.localScale.z);
                break;
        }

        piece.transform.position = piece.transform.position + 
                                   Vector3.up * (piece.transform.localScale.y * 
                                   (int)Math.Floor(pieceList.Count / 3f));

        piece.gameObject.SetActive(true);
    }
}
