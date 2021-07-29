using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGo;
    public GameObject scoreUITextGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;

    // Start is called before the first frame update 
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    //Funtion to update the game manager state THIS
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                // Hide game over
                GameOverGo.SetActive(false);

                //Set play button visible
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:
                //Reset the score
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                //hide play button
                playButton.SetActive(false);
                playerShip.GetComponent<Control_Player>().Init();
                enemySpawner.GetComponent<Spawn_enemigo>().ScheduleEnemySpawner();
                break;
            case GameManagerState.GameOver:
                //Stop enemy spawner
                enemySpawner.GetComponent<Spawn_enemigo>().UnscheduleEnemySpawner();

                //Display game over
                GameOverGo.SetActive(true);

                //Change game manager state to Opening state after 8 seconds
                Invoke("ChangeToOpeningState", 4f);

                break;


            
            default:
            break;
        }
    }

    //Funtion to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //Funtion to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

}
