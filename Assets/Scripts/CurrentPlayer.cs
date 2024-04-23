using UnityEngine;

public static class CurrentPlayer
{
    public static int CurrentPlayerNumber { get; private set; } = 0;
    private static int playersCount=2;
    public static void NextPlayer()
    {
        CurrentPlayerNumber = (CurrentPlayerNumber + 1) % playersCount;
        Debug.Log("сейчас ходит игрок " + CurrentPlayerNumber);
    }
}
