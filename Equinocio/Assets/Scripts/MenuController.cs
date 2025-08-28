using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
   //[SerializeField] GameObject craditsPainel;
    

    public void Teleport(string tp){
        SceneManager.LoadScene(tp);
    }
    /* Caso queira os créditos;
    public void OpenCreditsBTN(){
        craditsPainel.SetActive(true);
    }

    public void CloseCreditsBTN() {
        craditsPainel.SetActive(false);
    }
    */

    public void Quit() {
        Application.Quit();
        print("Saiu do Jogo");
    }

}
