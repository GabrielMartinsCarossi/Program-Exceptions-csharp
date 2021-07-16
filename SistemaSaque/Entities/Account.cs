﻿using System;
using System.Collections.Generic;
using System.Text;
using SistemaSaque.Entities.Exceptions;

namespace SistemaSaque.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds the Withdraw limit.");
            }
            if (amount > Balance)
            {
                throw new DomainException("The amount exceeds account's balance.");
            }

            Balance -= amount;
        }
    }
}
