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
    [SerializeField]
    private GameObject pivotUi; // ayuda para setear el UI
    #endregion

    #region Unity Methods
    void Start()
    {
        DeactivateAllUi();
        ActivateUI(firstInfoUi);
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
        ActivateUI(selecterLvl);
        
    }
    public void ActivateInfoUI()
    {

        //DeactivateAllUi();
        audioManager.clip = audioList.getFinalAudio(sceneIndex);
        audioManager.Play();
        ActivateUI(InfoUi);
    }
    public void ActivateFinalUI()
    {
        DeactivateAllUi();
        ActivateUI(finalUi);
    }
    public void ActivateUI(GameObject ui)
    {
        DeactivateAllUi();
        ui.SetActive(true);
        Quaternion rotate = pivotUi.transform.rotation;
        Vector3 position = pivotUi.transform.position;
        rotate.x = 0;
        rotate.z = 0;
        position.y = ui.transform.position.y;
        ui.transform.SetPositionAndRotation(position, rotate);
        
    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    #endregion

}
