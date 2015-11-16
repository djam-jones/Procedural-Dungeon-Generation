using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour {

	//Grid System.
	private GridSystem _grid;
	private GridHolder _gridHolder;

	//Prefab for the Floor Tile.
	public Sprite floorTile;
	//Prefab for the Wall Tile.
	public Sprite wallTile;

	//Boolean to check if the script should generate a dungeon when the Scene is initially Loaded.
	public bool generateOnLoad;
	
	//Minimum Size of a Room.
	public int minRoomSize;
	//Maximum Size of a Room.
	public int maxRoomSize;

	private int _roomSize;

	//Minimum Amount of Rooms.
	public int minRoomAmount;
	//Maximum Amount of Rooms.
	public int maxRoomAmount;

	void Awake()
	{
		_grid = GameObject.Find("Grid Manager").GetComponent<GridSystem>();

		if(generateOnLoad == true)
		{
			GenerateNewDungeon();
		}
	}

	void Start()
	{
		_roomSize = Random.Range(minRoomSize, maxRoomSize);
	}

	/// <summary>
	/// Generates a new dungeon.
	/// </summary>
	public void GenerateNewDungeon()
	{
		print("Generating Dungeon...");

		GameObject startTile = _gridHolder.grid[Random.Range(0, _gridHolder.grid.Count)][Random.Range(0, _gridHolder.grid[0].Count)];

		CreateNewRoom(_gridHolder, startTile.GetComponent<Tile>(), _roomSize);
	}

	/// <summary>
	/// Creates a new room.
	/// </summary>
	private void CreateNewRoom(GridHolder gridHolder, Tile startingTile, int roomSize)
	{
		int roomTileSet = 0;
		List<Tile> roomTiles = new List<Tile>();
		List<Tile> currentTileNeighbors = GetNeighbors(gridHolder, startingTile);
		Tile currentNeighbor;

		while(roomTileSet < roomSize)
		{
			for(int i = 0; i < currentTileNeighbors.Count; i++)
			{
				currentNeighbor = currentTileNeighbors[i];
				print("looping through.");
			}
		}
	}

	/// <summary>
	/// Gets the neighbors of a tile.
	/// </summary>
	/// <returns>The neighbors.</returns>
	/// <param name="gridHolder">Grid holder.</param>
	/// <param name="tile">Tile.</param>
	private List<Tile> GetNeighbors(GridHolder gridHolder, Tile tile)
	{
		List<Tile> returningNeighbor = new List<Tile>();

		int x = (int)tile.gridPosition.x;
		int y = (int)tile.gridPosition.y;

		if(gridHolder.GetTile(x - 1, y) != null)
			returningNeighbor.Add(gridHolder.GetTile(x - 1, y));

		if(gridHolder.GetTile(x + 1, y) != null)
			returningNeighbor.Add(gridHolder.GetTile(x + 1, y));

		if(gridHolder.GetTile(x, y - 1) != null)
			returningNeighbor.Add(gridHolder.GetTile(x, y - 1));
		
		if(gridHolder.GetTile(x, y + 1) != null)
			returningNeighbor.Add(gridHolder.GetTile(x, y + 1));

		return returningNeighbor;
	}

}