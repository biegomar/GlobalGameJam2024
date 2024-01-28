using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PicturePuzzleBiegoMar;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private float timeLimit;
    
    [SerializeField]
    private TextMeshProUGUI TimerText;

    private List<TilePositionItem> tileMatrix;
    private List<TilePositionItem> winTileMatrix;

    private float waitTimer;
    private bool isShuffeld;
    private Camera camera;
    
    private void Start()
    {
        this.camera = Camera.main;
        this.waitTimer = 0;
        this.isShuffeld = false;
        this.tileMatrix = new List<TilePositionItem>();
        this.winTileMatrix = new List<TilePositionItem>();
        SpawnTiles();
        
        ShuffleTiles();

        RedrawTiles();
    }

    private void FixedUpdate()
    {
        this.waitTimer += Time.deltaTime;

        TimerText.text = $"Time left: {(int)(this.timeLimit - this.waitTimer)} sec.";
        
        if (waitTimer > timeLimit)
        {
            SceneManager.LoadScene(7);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var emptyTile = GetEmptyTilePositionItem();
                
            Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit)
            {
                var selectedTile = hit.collider.gameObject;
                var selectedTilePositionItem = this.tileMatrix.SingleOrDefault(x => !string.IsNullOrEmpty(x.Tag) && selectedTile.CompareTag(x.Tag));
                if (selectedTilePositionItem != default && this.IsSwapAllowed(emptyTile, selectedTilePositionItem))
                {
                    this.SwapPartner(emptyTile, selectedTilePositionItem);
                    RedrawTiles();
                }
            }
        }

        if (IsGameWon())
        {
            GameManager.Instance.picturepuzzleCompleted = true;
            SceneManager.LoadScene(8);
        }
    }

    private bool IsGameWon()
    {
        foreach (var positionItem in this.tileMatrix)
        {
            var winItem = this.winTileMatrix.SingleOrDefault(x =>
                x.Tag == positionItem.Tag && x.RelativePosition == positionItem.RelativePosition);
            if (winItem == default)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsSwapAllowed(TilePositionItem emptyElement, TilePositionItem swapPartner)
    {
        var validNeighbors = GetValidNeighbors(emptyElement);

        foreach (var validNeighbor in validNeighbors)
        {
            TilePositionItem neighbor;
            switch (validNeighbor)
            {
                case ValidNeighbors.Up: 
                    neighbor = GetPartner(emptyElement, Vector3.down);
                    break;
                case ValidNeighbors.Down:
                    neighbor = GetPartner(emptyElement, Vector3.up);
                    break;
                case ValidNeighbors.Left:
                    neighbor = GetPartner(emptyElement, Vector3.left);
                    break;
                case ValidNeighbors.Right:
                    neighbor = GetPartner(emptyElement, Vector3.right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(validNeighbor), validNeighbor, null);
            }

            if (neighbor.Tag == swapPartner.Tag)
            {
                return true;
            }
        }

        return false;
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
            this.tileMatrix.Add(new TilePositionItem() {Tag = newTile.tag, Tile = newTile, RelativePosition = new Vector3(column, row,0)});
            this.winTileMatrix.Add(new TilePositionItem() {Tag = newTile.tag, Tile = newTile, RelativePosition = new Vector3(column, row,0)});
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
        this.tileMatrix.Add(new TilePositionItem() {Tag = string.Empty, Tile = null, RelativePosition = new Vector3(column, row, 0)});
        this.winTileMatrix.Add(new TilePositionItem() {Tag = string.Empty, Tile = null, RelativePosition = new Vector3(column, row, 0)});
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

        this.isShuffeld = true;
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
    
    private TilePositionItem GetPartner(TilePositionItem emptyElement, Vector3 direction)
    {
        var swapPartner =
            this.tileMatrix.SingleOrDefault(x => x.RelativePosition == emptyElement.RelativePosition + direction);
        
        return swapPartner;
    }

    private void SwapPartner(TilePositionItem emptyElement, TilePositionItem swapPartner)
    {
        if (emptyElement != default && swapPartner != default)
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
