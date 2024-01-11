using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacionMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuPrincipal;
    [SerializeField] private GameObject panelMenuCreditos;

    // Start is called before the first frame update
    void Start()
    {
        MenuPrincipal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void MenuCreditos()
    {
        panelMenuPrincipal.SetActive(false);
        panelMenuCreditos.SetActive(true);
    }

    public void MenuPrincipal()
    {
        panelMenuCreditos.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }

    public void MenuJuego()
    {
        SceneManager.LoadScene("EsquivarCubos");
    }
}
