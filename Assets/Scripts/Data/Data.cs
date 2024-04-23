public static class Data
{
    private static Point _fieldSize = new(10, 10);
    public static Player[] Players { get; } = new Player[2];
    static MapObject _mapObject = new MapObject(_fieldSize,1);
    static MapCoins _mapCoins = new MapCoins(_fieldSize);

    static Data()
    {
        Players[0] = new Player(_fieldSize, _mapObject, _mapCoins, 0);
        Players[1] = new Player(_fieldSize, _mapObject, _mapCoins, 1);
    }
}
