using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private JengaPiece jengaPiecePrefab;
    
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

    [Header("Description Text")] 
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private TMP_Text descriptionText;

    private AllPieces allDataPieces;
    private List<JengaPiece> glassPieces;
    private List<JengaPiece> pieceGameObjects;
    
    public static StackManager I;

    public Transform PiecePoolParent
    {
        get => piecePoolParent;
    }

    private void Awake()
    {
        if(I == null)
        {
            I = this;
        }else
            Destroy(this);
    }

    /// <summary>
    /// gets all piece data sent from API call 
    /// </summary>
    public void SetAllPieces(AllPieces all)
    {
        allDataPieces = all;
        glassPieces = new List<JengaPiece>();
        pieceGameObjects = new List<JengaPiece>();

        foreach (var piece in allDataPieces.list)
        {
            CreatePiece(piece);
        }
    }

    /// <summary>
    /// grabs piece from object pool and sets it's type accordingly. If no piece is available at the time, it instantiates a new piece.
    /// </summary>
    private void CreatePiece(PieceData pieceData)
    {
        JengaPiece newJengaPiece;
            
        if(piecePoolParent.childCount > 0)
            newJengaPiece = piecePoolParent.GetChild(0).GetComponent<JengaPiece>();
        else
        {
            newJengaPiece = Instantiate(jengaPiecePrefab, piecePoolParent);
        }
        
        switch (pieceData.mastery)
        {
            case 0:
                if(newJengaPiece.Type != PieceType.Glass)
                {
                    newJengaPiece.SetText("");
                    newJengaPiece.Type = PieceType.Glass;
                    newJengaPiece.SetMaterial(glassMat);
                    newJengaPiece.Rigidbody.mass = 0.5f;
                    glassPieces.Add(newJengaPiece); //keep track of all glass pieces
                }
                break;
            case 1:
                if (newJengaPiece.Type != PieceType.Wood)
                {
                    newJengaPiece.SetText("Learned");
                    newJengaPiece.Type = PieceType.Wood;
                    newJengaPiece.Rigidbody.mass = 1f;
                    newJengaPiece.SetMaterial(woodMat);
                }
                break;
            case 2:
                if (newJengaPiece.Type != PieceType.Stone)
                {
                    newJengaPiece.SetText("Mastered");
                    newJengaPiece.Type = PieceType.Stone;
                    newJengaPiece.Rigidbody.mass = 5f;
                    newJengaPiece.SetMaterial(stoneMate);
                }

                break;
        }

        switch (pieceData.grade)
        {
            case Grades.SIXTH_GRADE:
                sixthGradeStack.AddPiece(newJengaPiece);
                break;
            case Grades.SEVENTH_GRADE:
                seventhGradeStack.AddPiece(newJengaPiece);
                break;
            case Grades.EIGH_GRADE:
                eighthGradeStack.AddPiece(newJengaPiece);
                break;
        }
        
        pieceGameObjects.Add(newJengaPiece);
        newJengaPiece.Data = pieceData;
    }

    /// <summary>
    /// Deactivates all glass pieces
    /// </summary>
    public void MakeGlassDisappear()
    {
        foreach (var piece in glassPieces)
        {
            piece.DeactivatePiece();
        }
    }

    /// <summary>
    /// Resets all tower data and  deactivates all pieces on the screen, resetting their velocities as well
    /// </summary>
    public void ResetTowers()
    {
        foreach (var piece in pieceGameObjects)
        {
            piece.gameObject.SetActive(false);
            piece.Rigidbody.velocity = Vector3.zero;
            piece.Rigidbody.angularVelocity = Vector3.zero;
            piece.transform.eulerAngles = Vector3.zero;
            
        }
        
        sixthGradeStack.ResetTowerList();
        seventhGradeStack.ResetTowerList();
        eighthGradeStack.ResetTowerList();
        
        SetAllPieces(allDataPieces);
    }

    /// <summary>
    /// Set the description box at the top left corner of the screen to detail a new piece's data
    /// </summary>
    public void SetDescriptionText(PieceData data)
    {
        descriptionText.text = "<b><size=120%>"+ data.subject + "</b></size> "
                               + "<b><size=110%>"+ data.grade + "</b></size>: " + data.domain
                               + "\n\n" + "<b><size=110%>"+ data.cluster + "</b></size>" +
                               "\n\n" + "<b><size=110%>"+ data.standardid + "</b></size>: " + data.standarddescription;
        
        textGameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TurnTextOff());
    }

    /// <summary>
    /// Turns off the decription box after 6 seconds
    /// </summary>
    private IEnumerator TurnTextOff()
    {
        yield return new WaitForSeconds(GameSettings.DESCRIPTION_TEXT_DISAPPEAR_LENGTH);
        descriptionText.text = "";
        textGameObject.SetActive(false);
    }
    
}
