﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para RenavamFieldUC.xam
    /// </summary>
    public partial class RenavamFieldUC : UserControl
    {
        private string _text;
        private bool validado = false;

        public string Text
        {
            get
            {
                if (validado)
                {
                    return _text;
                }
                else
                {
                    throw new FieldException("Renavam");
                }
            }
            set
            {
                RenavamTextBox.Text = value;
                validado = true;
            }
        }


        public RenavamFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Task.Run(() =>
            {
                if (RenavamTextBox.Text.Length < 11)
                {
                    return false;
                }
                return true;
            });
        }

        private void RenavamTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}