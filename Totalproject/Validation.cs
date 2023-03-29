using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Totalproject
{
    internal class Validation
    {
        public static bool validLogin(string check)
        {
            bool tf = false;
            if (check == string.Empty) { tf = true; MessageBox.Show("Имеется пустое поле "); }
            else {
                tf = check.Any(x => Char.IsControl(x) || Char.IsWhiteSpace(x) || Char.IsPunctuation(x) || x == '=' || x == '+' || x == '*');
                if (tf == true)
                {
                    MessageBox.Show("Вы использовали запрещенные символы ");


                }
            }
            return tf;
        }
        public static bool validString(string check) {
            bool tf = false;
            if (check == string.Empty) { tf = true; MessageBox.Show("Имеется пустое поле "); }
            else
            {
                tf = check.Any(x => Char.IsControl(x) || Char.IsWhiteSpace(x) || Char.IsPunctuation(x) || Char.IsNumber(x) || x == '=' || x == '+' || x == '*');
                if (tf == true)
                {
                    MessageBox.Show("Вы использовали запрещенные символы ");


                }
            }
            return tf;
        }
        public static bool validInt(string check)
        {
            bool tf = false;
            if (check == string.Empty) { tf = true; MessageBox.Show("Имеется пустое поле "); }
            else
            {

                tf = check.Any(x => Char.IsControl(x) || Char.IsWhiteSpace(x) || Char.IsPunctuation(x) || Char.IsLetter(x) || x == '=' || x == '+' || x == '*');
                if (tf == false)
                {
                    if (Convert.ToInt32(check) < 0) { tf = true; MessageBox.Show("Вы ввели отрицательное число"); }


                }
                else
                {
                    MessageBox.Show("Вы использовали запрещенные символы ");
                }
            }
            return tf;
        }
    
        public static bool validMoney(string check) {
            bool tf = false;
            if (check == string.Empty) { tf = true; MessageBox.Show("Имеется пустое поле "); }
            else
            {
                tf = check.Any(x => Char.IsControl(x) || Char.IsWhiteSpace(x) || Char.IsLetter(x) || x == '=' || x == '+' || x == '*');
                if (tf == false)
                {
                    if (Convert.ToInt32(check) < 0) { tf = true; MessageBox.Show("Вы ввели отрицательное число"); }


                   
                }
                else
                {
                    MessageBox.Show("Вы использовали запрещенные символы ");
                }
            }
            
            return tf;
        }
        
        public static bool validAdress(string check)
        {
            bool tf = false;
            if (check == string.Empty) { tf = true; MessageBox.Show("Имеется пустое поле "); }
            else
            {
                if (Convert.ToInt32(check) < 0) { tf = true; MessageBox.Show("Вы ввели отрицательное число"); }
                else
                {
                    tf = check.Any(x => Char.IsControl(x) || Char.IsWhiteSpace(x) || Char.IsPunctuation(x) || Char.IsLetter(x) || x == '=' || x == '+' || x == '*');
                    if (tf == true)
                    {
                        MessageBox.Show("Вы использовали запрещенные символы ");


                    }
                }
            }
            return tf;
        }
    }
}
