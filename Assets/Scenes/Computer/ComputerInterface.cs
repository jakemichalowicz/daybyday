﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerInterface : MonoBehaviour
{
    public GameObject mainRoom;
    public GameObject computerScreen;

    public GameObject profilePage;
    public GameObject inboxPage;
    public GameObject assignmentPage;
    public GameObject libraryPage;
    public GameObject blasterPage;
    public GameObject helpPage;
    public GameObject settingsPage;

    public GameObject currentPage;

    // Canvas objects for Assignents page
    public GameObject assmtButton1, assmtButton2, userTypeBox, notesButton;
    // Canvas objects for Inbox apge
    public GameObject inboxAssets;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitComputer();
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void QuitComputer()
    {
        mainRoom.SetActive(true);
        computerScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void CastRay()
    {
        //Casts a ray and calls the ChangePage() method

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
        if (hit)
        {
            currentPage = ChangePage(hit.collider.gameObject.name);
        }
    }

    private GameObject ChangePage(string newName)
    {
        GameObject newPage = null;

        if (newName.Equals("Profile Button"))
        {
            hideAllTabs();
            profilePage.SetActive(true);
        }
        else if (newName.Equals("Inbox Button"))
        {
            hideAllTabs();
            inboxPage.SetActive(true);
            inboxAssets.SetActive(true);
        }
        else if (newName.Equals("Assignments Button"))
        {
            hideAllTabs();
            assignmentPage.SetActive(true);
            assmtButton1.SetActive(true);
            assmtButton2.SetActive(true);
            userTypeBox.SetActive(true);
            notesButton.SetActive(true);
        }
     //   else if (newName.Equals("Library Button"))
     //   {
     //       hideAllTabs();
     //       libraryPage.SetActive(true);
     //   }
        else if (newName.Equals("Blaster Button"))
        {
     //       hideAllTabs();
     //       blasterPage.SetActive(true);
              SceneManager.LoadScene(3);
        }
        else if (newName.Equals("Help Button"))
        {
            hideAllTabs();
            helpPage.SetActive(true);
        }
     //   else if (newName.Equals("Settings Button"))
     //   {
     //       hideAllTabs();
     //       settingsPage.SetActive(true);
     //   }
        currentPage = assignmentPage;

        return newPage;
    }

    private void hideAllTabs()
    {
        profilePage.SetActive(false);
        inboxPage.SetActive(false);
            inboxAssets.SetActive(false);
        assignmentPage.SetActive(false);
            assmtButton1.SetActive(false);
            assmtButton2.SetActive(false);
            userTypeBox.SetActive(false);
            notesButton.SetActive(false);
        //libraryPage.SetActive(false);
        //blasterPage.SetActive(false); 
        helpPage.SetActive(false);
        //settingsPage.SetActive(false);
    }
}
