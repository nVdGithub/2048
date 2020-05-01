using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    public int tileValue;
    public bool mergeThisTurn;


    public Vector2 startingPosition;
    public Vector2 moveToPosition;

    public bool destroyMe = false;

    public Transform collidingTile;

    public bool willMergeWithCollidingTile;


}
