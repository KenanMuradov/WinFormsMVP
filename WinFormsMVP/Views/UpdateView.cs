using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMVP.Views;

public partial class UpdateView : Form, IUpdateView
{
    public UpdateView()
    {
        InitializeComponent();
    }

    public string FirstName 
    {
        get => txtFirstName.Text;
        set => txtFirstName.Text = value;
    }

    public string LastName
    {
        get => txtLastName.Text;
        set => txtLastName.Text = value;
    }

    public decimal Score
    {
        get => numericScore.Value;
        set => numericScore.Value = value;
    }

    public DateTime BirthDate
    {
        get => monthCalendar1.SelectionStart;
        set => monthCalendar1.SelectionStart = value;
    }

    public event EventHandler SaveEvent;
    public event EventHandler CancelEvent;

    private void btnSave_Click(object sender, EventArgs e) => SaveEvent?.Invoke(sender,e);

    private void btnCancel_Click(object sender, EventArgs e) => CancelEvent?.Invoke(sender, e);
}
