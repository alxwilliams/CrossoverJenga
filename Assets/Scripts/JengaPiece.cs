using TMPro;
using UnityEngine;

public enum PieceType
{
    Nothing,
    Glass,
    Wood,
    Stone
}

public class JengaPiece : MonoBehaviour
{
    [SerializeField] private TMP_Text frontText;
    [SerializeField] private TMP_Text backText;
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private Rigidbody rigidbody;

    private PieceType type = PieceType.Nothing;
    private PieceData data;

    public PieceData Data
    {
        set => data = value;
    }

    public PieceType Type
    {
        get => type;
        set => type = value;
    }

    public Rigidbody Rigidbody
    {
        get => rigidbody;
    }
    public void SetText(string value)
    {
        
        frontText.text = value;
        backText.text = value;
    }

    /// <summary>
    /// Set piece material
    /// </summary>
    public void SetMaterial(Material mat)
    {
        renderer.material = mat;
    }

    /// <summary>
    /// deactivates gameobject and places piece back in objectt pool
    /// </summary>
    public void DeactivatePiece()
    {
        gameObject.SetActive(false);
        transform.parent = StackManager.I.PiecePoolParent;
    }

    /// <summary>
    /// if piece clicked, send data to stackmanager's description text
    /// </summary>
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StackManager.I.SetDescriptionText(data);
        }
    }

}
