using System.Runtime;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTile))]
[CanEditMultipleObjects]
public class TileGUIInspector : Editor {

    private CustomTile _tile;
    public ColorType _colorType;
    public Object spriteDatabase;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        _tile = (CustomTile)target;

        BoardManager manager = _tile.transform.parent.GetComponent<BoardManager>();

        EditorGUILayout.Space(16);
        
        EditorGUILayout.BeginHorizontal();
        _colorType = (ColorType)EditorGUILayout.EnumPopup(_colorType);

        if(GUILayout.Button("Mod Color"))
        {
            manager.SetTileColor(_tile, _colorType);
        }
        
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Set Filter"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);

            var filter = AssetDatabase.LoadAssetAtPath<Filter>("Assets/Resources/Prefabs/Filters/TestFilter.prefab");
            var filterObject = Instantiate(filter, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.Filter = filterObject.GetComponent<Filter>();
        }

        if (GUILayout.Button("Set Obstacle"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);

            //Instantiate obstacles;
            var obstacle = AssetDatabase.LoadAssetAtPath<Obstacle>("Assets/Resources/Prefabs/Obstacles/Basic.prefab");
            var obstacleObject = Instantiate(obstacle, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.Obstacle = obstacleObject.GetComponent<Obstacle>();
        }

        if (GUILayout.Button("Set WeakTile"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);

            //Instantiate obstacles;
            var obstacle = AssetDatabase.LoadAssetAtPath<WeakTile>("Assets/Resources/Prefabs/Obstacles/WeakTile.prefab");
            var obstacleObject = Instantiate(obstacle, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.wt = obstacleObject.GetComponent<WeakTile>();
        }

        if (GUILayout.Button("Clear"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            _tile.Filter = null;
        }

    }
}