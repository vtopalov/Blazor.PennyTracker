﻿using System;

using PennyTracker.Web.Data;
using PennyTracker.Web.Services;

namespace PennyTracker.Web.ViewModels
{
    public interface ICreateExpenseViewModel
    {
        Expense Model { get; set; }

        void OnButtonSaveClicked();

        void OnButtonCancelClicked();
    }

    public class CreateExpenseViewModel : ICreateExpenseViewModel
    {
        private readonly IDialogService dialogService;
        private readonly IExpenseService expenseService;

        public Expense Model { get; set; }
    
        public CreateExpenseViewModel(IDialogService dialogService, IExpenseService expenseService)
        {
            this.dialogService = dialogService;
            this.expenseService = expenseService;

            this.Model = new Expense { SpentDate = DateTime.UtcNow };
        }

        public void OnButtonSaveClicked()
        {
            var result = this.expenseService.Add(this.Model);

            this.dialogService.Close(true);
        }

        public void OnButtonCancelClicked() => this.dialogService.Close(false);
    }
}
