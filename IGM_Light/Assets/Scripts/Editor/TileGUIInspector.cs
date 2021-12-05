using System.Runtime;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTile))]
[CanEditMultipleObjects]
public class TileGUIInspector : Editor {

    private CustomTile _tile;
    public ColorType _colorType;
    public Object spriteDatabase;
    private Portal wPortalObject;
    private Portal bPortalObject;
    
    /*public override void Update()
    {
        if (wPortalObject!=null&&bPortalObject!=null)
        {
            Debug.Log("portal pair");
            wPortalObject.b_PortalPos = bPortalObject.b_PortalPos;
            bPortalObject.w_PortalPos = wPortalObject.w_PortalPos;
        }
    }*/

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
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

            var filter = AssetDatabase.LoadAssetAtPath<Filter>("Assets/Resources/Prefabs/Filters/TestFilter.prefab");
            var filterObject = Instantiate(filter, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.Filter = filterObject.GetComponent<Filter>();
        }

        if (GUILayout.Button("Set Obstacle"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

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
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

            //Instantiate obstacles;
            var WeakTile = AssetDatabase.LoadAssetAtPath<WeakTile>("Assets/Resources/Prefabs/Gimmick/WeakTile.prefab");
            var WeakTileObject = Instantiate(WeakTile, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.wt = WeakTileObject.GetComponent<WeakTile>();
        }

        if (GUILayout.Button("Set IceTile"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

            //Instantiate obstacles;
            var IceTile = AssetDatabase.LoadAssetAtPath<IceTile>("Assets/Resources/Prefabs/Gimmick/IceTile.prefab");
            var IceTileObject = Instantiate(IceTile, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.it = IceTileObject.GetComponent<IceTile>();
        }

        if (GUILayout.Button("Set White Portal"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

            //Instantiate obstacles;
            var wPortal = AssetDatabase.LoadAssetAtPath<Portal>("Assets/Resources/Prefabs/Gimmick/WhitePortal.prefab");
            wPortalObject = Instantiate(wPortal, _tile.transform.position, Quaternion.identity, _tile.transform);

            _tile.index = manager.w_poslist.Count;
            //Debug.Log("w index:::" + _tile.index);
            manager.w_poslist.Add(_tile.transform.position);
            _tile.w_portal = wPortalObject.GetComponent<Portal>();
        }

        if (GUILayout.Button("Set Black Portal"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);

            //Instantiate obstacles;
            var bPortal = AssetDatabase.LoadAssetAtPath<Portal>("Assets/Resources/Prefabs/Gimmick/BlackPortal.prefab");
            bPortalObject = Instantiate(bPortal, _tile.transform.position, Quaternion.identity, _tile.transform);

            //manager.b_pos = _tile.transform.position;
            _tile.index = manager.b_poslist.Count;
            //Debug.Log("b index:::" + _tile.index);
            manager.b_poslist.Add(_tile.transform.position);
            _tile.b_portal = bPortalObject.GetComponent<Portal>();
        }

        if (GUILayout.Button("Clear"))
        {
            DestroyImmediate(_tile.Filter?.gameObject);
            DestroyImmediate(_tile.Obstacle?.gameObject);
            DestroyImmediate(_tile.wt?.gameObject);
            DestroyImmediate(_tile.it?.gameObject);
            DestroyImmediate(_tile.w_portal?.gameObject);
            DestroyImmediate(_tile.b_portal?.gameObject);
            _tile.Filter = null;
        }

    }
}