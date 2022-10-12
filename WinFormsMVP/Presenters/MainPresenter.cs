using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Models;
using WinFormsMVP.Views;

namespace WinFormsMVP.Presenters;

public class MainPresenter
{
    private readonly BindingSource _bindingSource;
    private readonly IMainView _mainView;
    private readonly IAddView _addView;
    private readonly List<Student> _students;

    public MainPresenter(IMainView mainView, IAddView addView)
    {
        _mainView = mainView;
        _addView = addView;

        _students = new List<Student>()
        {
            new ("Miri","Miri",new DateOnly(2003,9,1),8.3f),
            new ("Tural","Tural",new DateOnly(2003,9,1),8.3f),
            new ("Kamran","Kamran",new DateOnly(2003,9,1),8.3f),
        };

        _bindingSource = new();

        _bindingSource.DataSource = _students;
        _mainView.SetStudentListBindingSource(_bindingSource);
        _mainView.SearchEvent += _mainView_SearchEvent;
        _mainView.DeleteEvent += _mainView_DeleteEvent;
        _mainView.AddEvent += _mainView_AddEvent;
    }

    private void _mainView_SearchEvent(object? sender, EventArgs e)
    {
        var searchValue = _mainView.SearchValue;

        if (!string.IsNullOrWhiteSpace(searchValue))
            _bindingSource.DataSource = _students.Where(s => s.FirstName.ToLower().Contains(searchValue.ToLower()) || s.LastName.ToLower().Contains(searchValue.ToLower())).ToList();
        else
            _bindingSource.DataSource = _students;
    }

    private void _mainView_DeleteEvent(object? sender, EventArgs e)
    {
        if (_bindingSource.Current is null)
            return;

        _bindingSource.Remove(_bindingSource.Current);
    }

    private void _mainView_AddEvent(object? sender, EventArgs e)
    {
        var result = ((Form)_addView).ShowDialog();

        if (result == DialogResult.Cancel)
            return;

        var student = new Student()
        {
            FirstName = _addView.FirstName,
            LastName = _addView.LastName,
            BirthDate = DateOnly.Parse(_addView.BirthDate.ToShortDateString()),
            Score = (float)_addView.Score
        };

        _bindingSource.Add(student);
    }

}
