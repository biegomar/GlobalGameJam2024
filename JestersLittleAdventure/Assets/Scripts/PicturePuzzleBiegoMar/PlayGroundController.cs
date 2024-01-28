using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PicturePuzzleBiegoMar;
using UnityEngine;
using UnityEngine.UIElements;
using ValidNeighbors = PicturePuzzleBiegoMar.ValidNeighbors;

public class PlayGroundController : MonoBehaviour
{
    [SerializeField] 
    private Vector3 startPosition;
    
    [SerializeField]
    private List<SpriteRenderer> tiles;

    [SerializeField] 
    private int ShuffleRounds;

    private List<TilePositionItem> tileMatrix;
    private List<TilePositionItem> winTileMatrix;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.tileMatrix = new List<TilePositionItem>();
        this.winTileMatrix = new List<TilePositionItem>();
        SpawnTiles();
        
        ShuffleTiles();

        RedrawTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RedrawTiles()
    {
        foreach (var item in tileMatrix)
        {
            if (item.Tile != default)
            {
                var corrector = new Vector3(item.RelativePosition.x, -item.RelativePosition.y, item.RelativePosition.z);
                item.Tile.transform.position = startPosition + corrector;    
            }
        }
    }

    private void SpawnTiles()
    {
        var row = 0f;
        var column = 0f;
        
        foreach (var tile in tiles)
        {
            var newTile = Instantiate(tile, startPosition + new Vector3(column,-row, 0), Quaternion.identity);
            this.tileMatrix.Add(new TilePositionItem() {Tile = newTile, RelativePosition = new Vector3(column, row,0)});
            this.winTileMatrix.Add(new TilePositionItem() {Tile = newTile, RelativePosition = new Vector3(column, row,0)});
            if (column < 3)
            {
                column++;
            }
            else
            {
                row++;
                column = 0;
            }
        }
        this.tileMatrix.Add(new TilePositionItem() {Tile = null, RelativePosition = new Vector3(column, row, 0)});
        this.winTileMatrix.Add(new TilePositionItem() {Tile = null, RelativePosition = new Vector3(column, row, 0)});
    }

    private void ShuffleTiles()
    {
        for (int i = 0; i < this.ShuffleRounds; i++)
        {
            var emptyElement = this.GetEmptyTilePositionItem();
            var validNeighbors = this.GetValidNeighbors(emptyElement);

            var nextMove = this.GetRandomValidNeighbor(validNeighbors);
        
            this.SwapTile(nextMove, emptyElement);    
        }
    }
    
    private TilePositionItem GetEmptyTilePositionItem()
    {
        return this.tileMatrix.SingleOrDefault(x => x.Tile == null);
    }

    private void SwapTile(ValidNeighbors nextPosition, TilePositionItem emptyElement)
    {
        switch (nextPosition)
        {
            case ValidNeighbors.Up: 
                SwapPartner(emptyElement, Vector3.down);
                break;
            case ValidNeighbors.Down:
                SwapPartner(emptyElement, Vector3.up);
                break;
            case ValidNeighbors.Left:
                SwapPartner(emptyElement, Vector3.left);
                break;
            case ValidNeighbors.Right:
                SwapPartner(emptyElement, Vector3.right);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(nextPosition), nextPosition, null);
        }
    }

    private void SwapPartner(TilePositionItem emptyElement, Vector3 direction)
    {
        var swapPartner =
            this.tileMatrix.SingleOrDefault(x => x.RelativePosition == emptyElement.RelativePosition + direction);

        if (swapPartner != default)
        {
            (swapPartner.RelativePosition, emptyElement.RelativePosition) = (emptyElement.RelativePosition, swapPartner.RelativePosition);
        }
    }

    private List<ValidNeighbors> GetValidNeighbors(TilePositionItem emptyElement)
    {
        if (emptyElement != default)
        {
            var result = new List<ValidNeighbors>();
            if (emptyElement.RelativePosition.x is > 0 and < 3)
            {
                result.Add(ValidNeighbors.Left);
                result.Add(ValidNeighbors.Right);
            }
            else if (emptyElement.RelativePosition.x == 0)
            {
                result.Add(ValidNeighbors.Right);
            }
            else if (Math.Abs(emptyElement.RelativePosition.x - 3) < 0.1f)
            {
                result.Add(ValidNeighbors.Left);
            }

            if (emptyElement.RelativePosition.y is > 0 and < 3)
            {
                result.Add(ValidNeighbors.Up);
                result.Add(ValidNeighbors.Down);
            }
            else if (emptyElement.RelativePosition.y == 0)
            {
                result.Add(ValidNeighbors.Down);
            }
            else if (Math.Abs(emptyElement.RelativePosition.y - 3) < 0.1f)
            {
                result.Add(ValidNeighbors.Up);
            }

            return result;
        }

        return Enumerable.Empty<ValidNeighbors>().ToList();
    }
    
    private ValidNeighbors GetRandomValidNeighbor(List<ValidNeighbors> validNeighbors)
    {
        int randomIndex = UnityEngine.Random.Range(0, validNeighbors.Count);
        return validNeighbors[randomIndex];
    }
}
