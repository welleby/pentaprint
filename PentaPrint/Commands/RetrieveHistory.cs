﻿using PentaPrint.Mediator;
using PentaPrint.Model;
using PentaPrint.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PentaPrint.Commands
{
    class RetrieveHistory : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private PrintMediator printMediator;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void PrintableChanged(string key)
        {
            RaiseCanExecuteChanged();
        }

        public RetrieveHistory(PrintMediator printMediator)
        {
            this.printMediator = printMediator;
        }
       
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            printMediator.SetCurrentPrintGroup((PrintGroup)parameter);
        }
    }
}
