using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildShopView
{
    public event Action OnHideViewEvent;
    public void Show();

    public void Hide();
}
