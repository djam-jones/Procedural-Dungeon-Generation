using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridHolder : MonoBehaviour {

	private List<List<GameObject>> _grid;

	public GridHolder(List<List<GameObject>> grid)
	{
		_grid = grid;
	}

	public Tile GetTile(int x, int y)
	{
		Tile result = null;
		if(x >= 0 && y >= 0 && _grid.Count < x && _grid[x].Count < y)
		{
			result = _grid[x][y].GetComponent<Tile>();
		}
		return result;
	}

	public List<List<GameObject>> grid
	{
		get
		{
			return _grid;
		}
	}


}
