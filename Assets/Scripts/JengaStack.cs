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
        
        switch (pieceList.Count % 6 )
        {
            case 1:
                piece.transform.position = 
                    transform.position - (Vector3.forward * (piece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                break;
            case 2:
                piece.transform.position = transform.position;
                break;
            case 3:
                piece.transform.position = 
                    transform.position + (Vector3.forward * (piece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                break;
            case 4:
                piece.transform.position = 
                    transform.position - (Vector3.right * (piece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                piece.transform.Rotate(Vector3.up*90);
                break;
            case 5:
                piece.transform.position = transform.position;
                piece.transform.Rotate(Vector3.up*90);
                break;
            case 0:
                piece.transform.position = 
                    transform.position + (Vector3.right * (piece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                piece.transform.Rotate(Vector3.up*90);
                break;
        }

        piece.transform.position += Vector3.up * (piece.transform.localScale.y * 
                                                  (int)Math.Floor((pieceList.Count-1) / 3f));

        piece.gameObject.SetActive(true);
    }
}
