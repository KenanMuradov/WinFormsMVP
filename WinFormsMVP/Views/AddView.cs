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

public partial class AddView : Form, IAddView
{
    public AddView()
    {
        InitializeComponent();
    }

    public string FirstName => txtFirstName.Text;

    public string LastName => txtLastName.Text;

    public decimal Score => numericScore.Value;

    public DateTime BirthDate => monthCalendar1.SelectionStart;

    public event EventHandler SaveEvent;
    public event EventHandler CancelEvent;

    private void btnSave_Click(object sender, EventArgs e) => SaveEvent?.Invoke(sender, e);

    private void btnCancel_Click(object sender, EventArgs e) => CancelEvent?.Invoke(sender, e);
}
