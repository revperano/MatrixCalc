﻿using System;
using PropertyChanged;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry
	{
        private Random random = new Random();

		public int Row { get; set; }
		public int Column { get; set; }
        public int LineId { get; set; }


        public InputEntry()
        { 
            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Text = random.Next(1, 999).ToString();
            TextChanged += UpdateResults;
            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public void UpdateResults(object sender, TextChangedEventArgs e)
        {
            if (IsNumeric(e.NewTextValue))
            {
                Text = e.NewTextValue;
                UpdateResultsDelegate.UpdateResults();
            }
            else
            {
                Text = e.OldTextValue;
            }

        }


        public void UpdateFontSize()
        {
            FontSize = Matrix.ChildHeight / 3.5;
        }

        private bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }


        private bool SumMoreZero(string value)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                sum += (int)c;
            }

            if (sum <= 0)
            {
                return false;
            }

            return true;
        }
    }
}

