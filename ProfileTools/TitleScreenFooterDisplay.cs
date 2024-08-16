using System;
using UnityEngine;

namespace ProfileTools;

public class TitleScreenFooterDisplay {
    string _currentProfileName;
    string _baseVersionText;

    TitleScreenManager _manager;

    public TitleScreenFooterDisplay() {
        _baseVersionText = "";
        _currentProfileName = "";
    }

    public void Setup(TitleScreenManager manager) {
        _manager = manager;
        _baseVersionText = _manager._gameVersionTextDisplay.text;

        _manager._gameVersionTextDisplay.alignment = TextAnchor.UpperLeft;
        var pos = _manager._gameVersionTextDisplay.rectTransform.anchoredPosition;
        pos.y -= _manager._gameVersionTextDisplay.fontSize / 2f;
        _manager._gameVersionTextDisplay.rectTransform.anchoredPosition = pos;

        UpdateTitleScreenFooter();
    }

    public void SetProfileName(string name) {
        _currentProfileName = name;
        UpdateTitleScreenFooter();
    }

    void UpdateTitleScreenFooter() {
        if (_manager == null) { return; }
        string profileLabel = "Profile";//ProfileTools.Instance.ModHelper.MenuTranslations.GetLocalizedString("Profile");
        _manager._gameVersionTextDisplay.text = _baseVersionText + $"{Environment.NewLine}{profileLabel} : {_currentProfileName}";
    }
}