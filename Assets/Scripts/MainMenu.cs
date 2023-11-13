using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Game game;

    
    public void PlayGame(int size)
    {
        game.SavedSize = size;
        game.StartGame(size);
    }

    public void Restart()
    {
        GoToMenu();
        PlayGame(game.SavedSize);
    }
    
    public void GoToMenu()
    {
        Destroy(game.InstCube.gameObject);
        Destroy(CubeRotation.Target.gameObject);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
