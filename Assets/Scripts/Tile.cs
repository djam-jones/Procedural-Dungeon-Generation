using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Tile parentTile;

	private Vector2 _gridPos;

	public void SetTile(int x, int y)
	{
		_gridPos = new Vector2(x, y);
	}

	public Vector2 gridPosition
	{
		get
		{
			return _gridPos;
		}
	}

}
