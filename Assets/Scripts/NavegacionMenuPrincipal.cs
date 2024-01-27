using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacionMenuPrincipal : MonoBehaviour
{
    public GameObject panelMenuPrincipal;
    public GameObject panelMenuCreditos;
    public GameObject panelMenuTutorial;

    private GameObject[] paneles;

    // Start is called before the first frame update
    void Start()
    {
        paneles = new GameObject[] { panelMenuPrincipal, panelMenuCreditos, panelMenuTutorial };
        MenuPrincipal();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MenuCreditos()
    {
        ActivarPanel(panelMenuCreditos);
        // panelMenuPrincipal.SetActive(false);
        // panelMenuCreditos.SetActive(true);
    }

    public void MenuPrincipal()
    {
        ActivarPanel(panelMenuPrincipal);
        // panelMenuCreditos.SetActive(false);
        // panelMenuPrincipal.SetActive(true);
    }

    public void MenuTutorial()
    {
        ActivarPanel(panelMenuTutorial);
    }

    public void MenuJuego()
    {
        SceneManager.LoadScene("EsquivarCubos");
    }

    private void ActivarPanel(GameObject panel)
    {
        foreach (GameObject p in paneles)
        {
            p.SetActive(false);
        }

        panel.SetActive(true);
    }
}
