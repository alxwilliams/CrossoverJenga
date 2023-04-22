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
    [SerializeField] private JengaStack seventthGradeStack;
    [SerializeField] private JengaStack eighthGradeStack;
}
