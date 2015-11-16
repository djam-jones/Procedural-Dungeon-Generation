using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonGeneratorEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		GUILayout.Space(10);
		if(GUILayout.Button("Generate Dungeon"))
		{
			DungeonGenerator dunGen = (DungeonGenerator)target;

			dunGen.GenerateNewDungeon();
		}
		GUILayout.Space(10);
	}
	
}