using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    void Start()
    {
        ServiceLocator.Get<GameManager>().OnDeath += OnDeath;
    }

    public void Restart()
    { 
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDeath(bool isKite)
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().Play("Lose Screen");
    }
}
