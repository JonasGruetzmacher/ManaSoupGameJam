using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] GameObject floorPrefab;
    [SerializeField] float tileSize = 10;

    GameObject[,] tiles;

    [SerializeField] int horizontalTileCount;
    [SerializeField] int verticalTileCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    Vector2Int currentTilePosition = new Vector2Int(0,0);
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] Vector2Int playerTilePosition;

    private void Awake()
    {
        tiles = new GameObject[horizontalTileCount, verticalTileCount];
    }

    private void Start()
    {
        UpdateTilesOnScreen();
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerPosition.position.x / tileSize);
        playerTilePosition.y = (int)(playerPosition.position.y / tileSize);

        playerTilePosition.x -= playerPosition.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerPosition.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
        
    }
    void UpdateTilesOnScreen()
    {
        for (int povX = -(fieldOfVisionWidth/2); povX <= fieldOfVisionWidth/2; povX++)
        {
            for (int povY = -(fieldOfVisionHeight/2); povY <= fieldOfVisionHeight/2; povY++)
            {
                int tileToUpdateX = CalculatePositionOnAxis(playerTilePosition.x + povX, true);
                int tileToUpdateY = CalculatePositionOnAxis(playerTilePosition.y + povY, false);

                GameObject tile = tiles[tileToUpdateX, tileToUpdateY];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + povX, playerTilePosition.y + povY);
            }
        }
    }

    Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % horizontalTileCount;
            }
            else
            {
                currentValue += 1;
                currentValue = horizontalTileCount -1 + currentValue % horizontalTileCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % verticalTileCount;
            }
            else
            {
                currentValue += 1;
                currentValue = verticalTileCount -1 + currentValue % verticalTileCount;
            }
        }
        return (int)currentValue;
    }

    public void Add(GameObject gameObject, Vector2Int tilePosition)
    {
        tiles[tilePosition.x, tilePosition.y] = gameObject;
    }

}
