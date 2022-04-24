using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(ScrollRect))]
public class Menu : MonoBehaviour
{
    public static event Action<string> OnShowMenu;
    public static event Action OnBackMenu;

    [SerializeField]
    private GameObject optionsObject;
    [SerializeField]
    private GameObject optionPrefab;

    private MenuOption[] _menuOptions;
    private MenuInput _menuInput;

    private int _currentIndex;

    private void Awake()
    {
        _menuOptions = optionsObject.GetComponentsInChildren<MenuOption>();
        Debug.Log("[Menu Awake] main options found: "+_menuOptions.Length);

        if(!this.gameObject.transform.parent.TryGetComponent<MenuInput>(out _menuInput))
        {
            _menuInput = GetComponent<MenuInput>();
            if(_menuInput == null)
            {
                Debug.LogError("There must be at least one MenuInput Script attached in the menu structure or in the menu object itself");
                return;
            }
        }
        _currentIndex = 0;
    }

    private void OnEnable() 
    {
        UpdateOptions();
    }

    void Start()
    {
        StartCoroutine(CoOrderOptions());
    }

    void Update()
    {
        if (_menuOptions.Length != 0)
        {
            _menuOptions[_currentIndex].Point();
            if (_menuInput.Down && _currentIndex + 2 < _menuOptions.Length)
            {
                _menuOptions[_currentIndex].RemovePoint();
                _currentIndex += 2;
                if (_currentIndex >= 4)
                {
                    optionsObject.transform.position = new Vector3(optionsObject.transform.position.x,
                                                                    optionsObject.transform.position.y + 100,
                                                                    optionsObject.transform.position.z);
                }
            }
            if (_menuInput.Up && _currentIndex - 2 >= 0)
            {
                _menuOptions[_currentIndex].RemovePoint();
                _currentIndex -= 2;
                if (_currentIndex >= 4 || _currentIndex >= 2)
                {
                    optionsObject.transform.position = new Vector3(optionsObject.transform.position.x,
                                                                    optionsObject.transform.position.y - 100,
                                                                    optionsObject.transform.position.z);
                }
            }
            if (_menuInput.Right && _currentIndex + 1 < _menuOptions.Length)
            {
                _menuOptions[_currentIndex].RemovePoint();
                _currentIndex += 1;
                if (_currentIndex >= 4 && ((_currentIndex - 1) % 2 != 0))
                {
                    optionsObject.transform.position = new Vector3(optionsObject.transform.position.x,
                                                                    optionsObject.transform.position.y + 100,
                                                                    optionsObject.transform.position.z);
                }
            }
            if (_menuInput.Left && _currentIndex - 1 >= 0)
            {
                _menuOptions[_currentIndex].RemovePoint();
                _currentIndex -= 1;
                if ((_currentIndex >= 4 || _currentIndex >= 2) && ((_currentIndex + 1) % 2 == 0))
                {
                    optionsObject.transform.position = new Vector3(optionsObject.transform.position.x,
                                                                    optionsObject.transform.position.y - 100,
                                                                    optionsObject.transform.position.z);
                }
            }

            // Selection
            StartCoroutine(COLateSelectCheck());
        }

        // Back
        if (_menuInput.Back)
        {
            OnBackMenu?.Invoke();
        }
    }

    private IEnumerator COLateSelectCheck()
    {
        yield return new WaitForEndOfFrame();
        if (_menuInput.Select)
        {
            _menuOptions[_currentIndex].Select();
        }
    }

    private IEnumerator CoOrderOptions()
    {
        yield return new WaitForEndOfFrame();
        OrderOptions();
    }
    
    private void OrderOptions()
    {
        IOrderedEnumerable<MenuOption> orderedMainOptions = _menuOptions.OrderByDescending(opt => opt.gameObject.GetComponent<RectTransform>().anchoredPosition.y)
            .ThenBy(opt => opt.gameObject.GetComponent<RectTransform>().anchoredPosition.x);
        _menuOptions = orderedMainOptions.ToArray();
    }

    private void UpdateOptions()
    {
        _menuOptions = optionsObject.GetComponentsInChildren<MenuOption>();
        StartCoroutine(CoOrderOptions());
    }

    public void ShowMenu()
    {
        this.gameObject.SetActive(true);
        if (OnShowMenu == null)
            return;
        OnShowMenu(gameObject.name);
    }

    public void AddMenuOption(string text)
    {
        GameObject newOption = Instantiate(optionPrefab, optionsObject.transform);
        newOption.GetComponent<MenuOption>().SetOptionText(text);
        UpdateOptions();
    }

}
