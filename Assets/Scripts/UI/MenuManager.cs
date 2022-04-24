using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Menu[] _menus;
    private Stack<Menu> _menuStack;

    private void Awake()
    {
        _menuStack = new Stack<Menu>();
        _menus = GetComponentsInChildren<Menu>(); // gli altri sono settati a false
        int activeCount = 0;
        foreach(Menu menu in _menus)
        {
            if (menu.gameObject.activeInHierarchy)
            {
                // Only one active
                activeCount++;
                if(activeCount >= 2)
                {
                    menu.gameObject.SetActive(false);
                }
                else
                {
                    _menuStack.Push(menu); // first element / current active menu
                }
            }
        }
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        Menu.OnShowMenu += ForwardMenu;
        Menu.OnBackMenu += BackwardMenu;
    }

    private void OnDisable()
    {
        Menu.OnShowMenu -= ForwardMenu;
        Menu.OnBackMenu -= BackwardMenu;
    }

    private void ForwardMenu(string menuShown)
    {
        foreach(Menu menu in _menus)
        {
            Debug.Log(menu.gameObject.name + " " + menuShown);
            if (!menu.gameObject.name.Equals(menuShown))
            {
                menu.gameObject.SetActive(false); // Hide
            }
            else
            {
                _menuStack.Push(menu);
            }
        }
    }

    private void BackwardMenu()
    {
        if (_menuStack.Count == 1)
            return;  

        Menu oldMenu = _menuStack.Pop(); 
        Menu newMenu = _menuStack.Peek();

        oldMenu.gameObject.SetActive(false);
        newMenu.gameObject.SetActive(true);
    }
}
