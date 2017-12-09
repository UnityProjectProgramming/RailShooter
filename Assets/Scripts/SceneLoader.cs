using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public IEnumerator LoadLevelOne()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1);
    }
}
