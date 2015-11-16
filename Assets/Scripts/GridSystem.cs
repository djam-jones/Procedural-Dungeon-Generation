using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridSystem : MonoBehaviour {

	private GridHolder _gridHolder;

	public GameObject tile;
	private SpriteRenderer _tileSpriteRenderer;

	[HideInInspector]
	public int totalTiles;

	void Awake()
	{
		_tileSpriteRenderer = tile.GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		CreateGrid(30, 30);
		print("Total Amount of Tiles: " + totalTiles);
	}

	public void CreateGrid(int x, int y)
	{
		List<List<GameObject>> grid = new List<List<GameObject>>();

		Vector3 tileSize = _tileSpriteRenderer.bounds.size;
		Vector3 tilePosition = new Vector3(0, 0, 0);

		for(int xRow = 0; xRow < x; xRow++)
		{
			grid.Add(new List<GameObject>());

			for(int yRow = 0; yRow < y; yRow++)
			{
				tilePosition = new Vector3(-((x * tileSize.x) / 2) + xRow * tileSize.x, 
				                           -((y * tileSize.y) / 2) + yRow * tileSize.y, 
				                           0);

				Instantiate(tile, tilePosition, Quaternion.identity);
				tile.GetComponent<Tile>().SetTile(xRow, yRow);
				grid[xRow].Add(tile);

				totalTiles = (x * y);
			}
		}

		_gridHolder = new GridHolder(grid);
	}

 	public GridHolder gridHolder
	{
		get
		{
			return _gridHolder;
		}
	}
}
