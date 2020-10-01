using System;
using System.Windows.Forms;

namespace CryptoMoon.Services
{
    public interface INavigationService
    {
        void Navigate<TFrom, TTo>(TFrom fromForm, Type toFormType, bool hideCurrent = false) where TFrom : Form where TTo : Form;

        void Navigate<TFrom, TTo>(TFrom fromForm, Type toFormType, object parameter, bool hideCurrent = false) where TFrom : Form where TTo : Form;
    }

    public class NavigationService : INavigationService
    {
        public void Navigate<TFrom, TTo>(TFrom fromForm, Type toFormType, bool hideCurrent = false) where TFrom : Form where TTo : Form
        {
            if (hideCurrent)
                fromForm.Hide();

            TTo toForm = (TTo)Activator.CreateInstance(toFormType);
            toForm.ShowDialog();

            if (hideCurrent)
                fromForm.Close();
        }

        public void Navigate<TFrom, TTo>(TFrom fromForm, Type toFormType, object parameter, bool hideCurrent = false) where TFrom : Form where TTo : Form
        {
            if (hideCurrent)
                fromForm.Hide();

            TTo toForm = (TTo)Activator.CreateInstance(toFormType, parameter);
            toForm.ShowDialog();

            if (hideCurrent)
                fromForm.Close();
        }
    }
}
