using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public int tileValue;
    public bool mergeThisTurn;


    public Vector2 startingPosition;
    public Vector2 startingPositionmoveToPosition;

    public bool destroyMe = false;

    public bool collidingTile;

    public bool willMergeWithCollidingTile;


}
