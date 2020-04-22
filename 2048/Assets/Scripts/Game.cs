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

        GenerateNewTile(2);

    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();

        debug.Add("Current Time", Time.time.ToString(), "currenttime");
    }


    void CheckUserInput()
    {
        bool down = Input.GetKeyDown(KeyCode.DownArrow), up = Input.GetKeyDown(KeyCode.UpArrow), left = Input.GetKeyDown(KeyCode.LeftArrow), right = Input.GetKeyDown(KeyCode.RightArrow);

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


    void GenerateNewTile(int howMany)
    {
        for (int i = 0; i < howMany; ++i)
        {
            Vector2 locationForNewTile = GetRandomLocationForNewTile();

            string tile = "tile_2";

            float chanceOfTwo = Random.Range(0f, 1f);

            if (chanceOfTwo > 0.9f)
            {
                tile = "tile_4";
            }

            GameObject newTile = (GameObject)Instantiate(Resources.Load(tile, typeof(GameObject)), locationForNewTile, Quaternion.identity);

            newTile.transform.parent = transform;
        }

        UpdateGrid();
    }



    void UpdateGrid()
    {

        for (int y = 0; y < gridHeight; ++y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform tile in transform)
        {
            Vector2 v = new Vector2(Mathf.Round(tile.position.x), Mathf.Round(tile.position.y));

            grid[(int)v.x, (int)v.y] = tile;

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
