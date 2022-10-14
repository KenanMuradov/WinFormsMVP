using WinFormsMVP.Presenters;
using WinFormsMVP.Repositories;
using WinFormsMVP.Views;

namespace WinFormsMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IMainView mainView = new MainView();
            IAddView addView = new AddView();
            IUpdateView updateView = new UpdateView();
            IStudentRepository studentRepository = new EfStudentRepository();

            new MainPresenter(mainView, addView, updateView, studentRepository);
            new AddPresenter(addView);
            new UpdatePresenter(updateView);

            Application.Run((Form)mainView);
        }
    }
}