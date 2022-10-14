using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsMVP.Views;

namespace WinFormsMVP.Presenters;

public class UpdatePresenter
{
    private IUpdateView _updateView;


    public UpdatePresenter(IUpdateView updateView)
    {
        _updateView = updateView;

        _updateView.SaveEvent += _updateView_SaveEvent;
        _updateView.CancelEvent += _updateView_CancelEvent;
    }

    private void _updateView_SaveEvent(object? sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        if (!Regex.IsMatch(_updateView.FirstName, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{3,}$") || string.IsNullOrWhiteSpace(_updateView.FirstName))
            sb.Append($"Incorrect {nameof(_updateView.FirstName)}\n");

        if (!Regex.IsMatch(_updateView.LastName, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{3,}$") || string.IsNullOrWhiteSpace(_updateView.LastName))
            sb.Append($"Incorrect {nameof(_updateView.LastName)}\n");

        if ((DateTime.Now.Year - _updateView.BirthDate.Year) < 18)
            sb.Append($"{nameof(_updateView.BirthDate)} Doesn't Match\n");

        if (sb.Length > 0)
        {
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _updateView.DialogResult = DialogResult.OK;
    }


    private void _updateView_CancelEvent(object? sender, EventArgs e) => ((Form)_updateView).DialogResult = DialogResult.Cancel;

}
