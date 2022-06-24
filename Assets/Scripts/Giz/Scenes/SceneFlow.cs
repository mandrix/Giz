using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFlow : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private Audios audioList; //all audios
    [SerializeField]
    public GameObject firstInfoUi; // esta info estará en simultáneo con el audio del inicio, y tendrá un botón de iniciar actividad
    [SerializeField]
    public GameObject InfoUi; // esta info sera para cada escena por aparte dependiendo del grupo/especie
    [SerializeField]
    public GameObject finalUi; // ui para continuar/reiniciar/salir/menu/selectar un lvl
    [SerializeField]
    public AudioSource audioManager; // el audio el cual le cambiaremos el sonido que ocupemos
    [SerializeField]
    private GameObject selecterLvl; // el ui para selectar un lvl
    [SerializeField]
    private int sceneIndex; // el indice de la escena donde estoy (auxiliar para los audios)
    #endregion

    #region Unity Methods
    void Start()
    {
        DeactivateAllUi();
        firstInfoUi.SetActive(true);
        audioManager.clip = audioList.getFirstAudio(sceneIndex);
        audioManager.Play();        
    }
    #endregion

    #region Custom Methods
    public void DeactivateAllUi()
    {
        selecterLvl.SetActive(false);
        firstInfoUi.SetActive(false);
        InfoUi.SetActive(false);
        finalUi.SetActive(false);
    }
    public void ActivateSelecterLvl()
    {
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    public void ActivateInfoUI()
    {

        //DeactivateAllUi();
        audioManager.clip = audioList.getFinalAudio(sceneIndex);
        audioManager.Play();
        InfoUi.SetActive(true);
    }
    public void ActivateFinalUI()
    {
        DeactivateAllUi();
        finalUi.SetActive(true);
    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    #endregion

}
