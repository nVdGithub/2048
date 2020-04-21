//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static int gridWidth = 4, gridHeight = 4;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    public CFDebug debug;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();

        debug.Add("Current Time", Time.time.ToString(), "currenttime");
    }


    void CheckUserInput()
    {
        bool down = Input.GetKeyDown(KeyCode.DownArrow) , up = Input.GetKeyDown(KeyCode.UpArrow) , left = Input.GetKeyDown(KeyCode.LeftArrow) , right = Input.GetKeyDown(KeyCode.RightArrow);

        if (down || up || left || right)
        {

            if (down) {
                debug.Add("Player Pressed Key", "Down", "checkuserinput");

                GetRandomLocationForNewTile();
            }

            if (up) {
                debug.Add("Player Pressed Key", "Up", "checkuserinput");
            }

            if (left)
            {
                debug.Add("Player Pressed Key", "Left", "checkuserinput");
            }

            if (right)
            {
                debug.Add("Player Pressed Key", "Right", "checkuserinput");
            }

        }

    }



    Vector2 GetRandomLocationForNewTile()
    {
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        for (int j = 0; j<gridWidth; j++)
        {
            for (int i = 0; i < gridHeight; i++)
            {
                if (grid[j,i] == null)
                {
                    x.Add(j);
                    y.Add(i);
                }
            }

        }


        int randIndex = Random.Range(0,x.Count);

        int randX = x.ElementAt(randIndex);
        int randY = y.ElementAt(randIndex);

        debug.Add("New Random Tile Location", randX + "," + randY, "randomlocation");
        


        return new Vector2(randX, randY);

    }





    /// <summary>
    /// Restart Game Play - video #2
    /// </summary>

    public void PlayAgain()
    {

        grid = new Transform[gridWidth, gridHeight];

    }
}
