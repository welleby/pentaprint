﻿using PentaPrint.Commands;
using PentaPrint.Devices;
using PentaPrint.Mediator;
using PentaPrint.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PentaPrint.ViewModel
{
    class MainwWindowViewModel
    {
        PrintMediator printMediator = PrintMediator.Instance;
        public ObservableCollection<PrintGroup> History { get; set; }
        public CommandGroup PrintAll { get; private set; }
        public ICommand RetrieveHistory { get; private set; }
        public PrintCommand PrintOne { get; private set; }
        public ICommand OpenDialog { get; private set; }

        public MainwWindowViewModel()
        {
            printMediator.SetupTestPrintGroups();
            History = printMediator.History;

            PrintAll = new CommandGroup();
            PrintAll.Commands.Add(new PrintAll(printMediator));
            PrintAll.Commands.Add(new PushAllToHistory(printMediator));
            PrintAll.Commands.Add(new ResetAll(printMediator));

            PrintOne = new PrintCommand(printMediator);

            RetrieveHistory = new RetrieveHistory(printMediator);

            OpenDialog = new OpenDialog();
        }
        
    }
}
