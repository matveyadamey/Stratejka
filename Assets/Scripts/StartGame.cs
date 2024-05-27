using UnityEngine;

public class StartGame : MonoBehaviour
{
    private static int _materialsCount = 5;
    public const int Size = 10;
    public const int RadiusAttack = 1;
    public const int PlayersCount = 2;
    public const int ChipsCount = 2;
    public static Material[] Materials;
    public static GameObject CubePrefab;
    public static Transform CubeField;
    public static GameObject CoinPrefab;
    public static Transform CoinParent;
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubeField;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinParent;
    void Awake()
    {
        Materials = _materials;
        CubePrefab = _cubePrefab;
        CubeField = _cubeField;
        CoinPrefab = _coinPrefab;
        CoinParent = _coinParent;

        Field.FieldSpawn();
        MapObject.MakeMapObject();
        MapCoins.MakeMapCoins();
        Field.CoinsSpawn(); // коины спавнятся туда, где они есть в MаpCoins
        PlayersContainer.MakePlayers();

        PlayersContainer.Players[0].SetCoordChip(0, new Point(0, 0));
        PlayersContainer.Players[0].SetCoordChip(1, new Point(Size - 1, Size - 1));
        PlayersContainer.Players[1].SetCoordChip(0, new Point(0, Size - 1));
        PlayersContainer.Players[1].SetCoordChip(1, new Point(Size - 1, 0));
    }

}
