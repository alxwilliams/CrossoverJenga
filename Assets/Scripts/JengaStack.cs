using System;
using System.Collections.Generic;
using UnityEngine;

public class JengaStack : MonoBehaviour
{
    private List<JengaPiece> pieceList;
    
    private void Start()
    {
        pieceList = new List<JengaPiece>();
    }

    public void ResetTowerList()
    {
        pieceList.Clear();
    }

    /// <summary>
    /// Add piece to the stack and determine it's position and rotation
    /// </summary>
    public void AddPiece(JengaPiece jengaPiece)
    {
        pieceList.Add(jengaPiece);
        jengaPiece.transform.parent = transform;
        
        switch (pieceList.Count % 6 )
        {
            //case 1-3 are moved on the z axis. They are the original rotation, so no need to determine a new rotation
            case 1:
                jengaPiece.transform.position = 
                    transform.position - (Vector3.forward * (jengaPiece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                break;
            case 2:
                jengaPiece.transform.position = transform.position;
                break;
            case 3:
                jengaPiece.transform.position = 
                    transform.position + (Vector3.forward * (jengaPiece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                break;
            //case 4-0 need to be rotation 90 degrees and moved on the x axis
            case 4:
                jengaPiece.transform.position = 
                    transform.position - (Vector3.right * (jengaPiece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                jengaPiece.transform.Rotate(Vector3.up*90);
                break;
            case 5:
                jengaPiece.transform.position = transform.position;
                jengaPiece.transform.Rotate(Vector3.up*90);
                break;
            case 0:
                jengaPiece.transform.position = 
                    transform.position + (Vector3.right * (jengaPiece.transform.localScale.z + GameSettings.SPACE_BETWEEN_PIECES));
                jengaPiece.transform.Rotate(Vector3.up*90);
                break;
        }

        jengaPiece.transform.position += Vector3.up * (jengaPiece.transform.localScale.y * 
                                                  (int)Math.Floor((pieceList.Count-1) / 3f));

        jengaPiece.gameObject.SetActive(true);
    }
}
