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
    private readonly IUpdateView _updateView;
    private readonly List<Student> _students;

    public MainPresenter(IMainView mainView, IAddView addView, IUpdateView updateView)
    {
        _mainView = mainView;
        _addView = addView;
        _updateView = updateView;

        _students = new List<Student>()
        {
            new ("Miri","Miri",new DateTime(2003,9,1),8.3f),
            new ("Tural","Tural",new DateTime(2003,9,1),8.3f),
            new ("Kamran","Kamran",new DateTime(2003,9,1),8.3f),
        };

        _bindingSource = new();

        _bindingSource.DataSource = _students;
        _mainView.SetStudentListBindingSource(_bindingSource);
        _mainView.SearchEvent += _mainView_SearchEvent;
        _mainView.DeleteEvent += _mainView_DeleteEvent;
        _mainView.AddEvent += _mainView_AddEvent;
        _mainView.UpdateEvent += _mainView_UpdateEvent;
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
        {
            MessageBox.Show("Select Student To Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _bindingSource.Remove(_bindingSource.Current);
        MessageBox.Show("Successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void _mainView_AddEvent(object? sender, EventArgs e)
    {
        var result = _addView.ShowDialog();

        if (result == DialogResult.Cancel)
            return;

        var student = new Student()
        {
            FirstName = _addView.FirstName,
            LastName = _addView.LastName,
            BirthDate = _addView.BirthDate,
            Score = (float)_addView.Score
        };

        _bindingSource.Add(student);
        MessageBox.Show("Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void _mainView_UpdateEvent(object? sender, EventArgs e)
    {
        var student = _bindingSource.Current as Student;

        if (student is null)
        {
            MessageBox.Show("Select Student To Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _updateView.FirstName = student.FirstName;
        _updateView.LastName = student.LastName;
        _updateView.Score = (decimal)student.Score;
        _updateView.BirthDate = DateTime.Parse(student.BirthDate.ToString());

        var result = _updateView.ShowDialog();

        if (result == DialogResult.Cancel)
            return;

        student.FirstName = _updateView.FirstName;
        student.LastName = _updateView.LastName;
        student.BirthDate = _updateView.BirthDate;
        student.Score = (float)_updateView.Score;

        _bindingSource.ResetCurrentItem();
        MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

}
