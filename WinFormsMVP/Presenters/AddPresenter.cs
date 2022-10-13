using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsMVP.Views;

namespace WinFormsMVP.Presenters;

public class AddPresenter
{
    private IAddView _addView;

    public AddPresenter(IAddView addView)
    {
        _addView = addView;

        _addView.SaveEvent += _addView_SaveEvent;
        _addView.CancelEvent += _addView_CancelEvent;
    }

    
    private void _addView_SaveEvent(object? sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        if (!Regex.IsMatch(_addView.FirstName, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{3,}$") || string.IsNullOrWhiteSpace(_addView.FirstName))
            sb.Append("Incorrect Name\n");

        if (!Regex.IsMatch(_addView.LastName, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{3,}$") || string.IsNullOrWhiteSpace(_addView.LastName))
            sb.Append("Incorrect Surname\n");

        if ((DateTime.Now - _addView.BirthDate).Days / 365 < 18)
            sb.Append("Age Doesn't Match\n");

        if (sb.Length > 0)
        {
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ((Form)_addView).DialogResult = DialogResult.OK;
    }

    private void _addView_CancelEvent(object? sender, EventArgs e)=> ((Form)_addView).DialogResult = DialogResult.Cancel;

}
