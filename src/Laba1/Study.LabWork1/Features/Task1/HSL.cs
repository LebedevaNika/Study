using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class HSL
    {
        private double hue;
        private double saturation;
        private double lightness;

        //оттенок
        public double Hue
        {
            get { return hue; }
            set
            {
                hue = value % 360;
                if (hue < 0)
                    hue += 360;
            }
        }

        //насыщенность
        public double Saturation
        {
            get { return saturation; }
            set
            {
                if (value < 0) saturation = 0;
                else if (value > 100) saturation = 100;
                else saturation = value;
            }
        }

        //светлота
        public double Lightness
        {
            get { return lightness; }
            set
            {
                if (value < 0) lightness = 0;
                else if (value > 100) lightness = 100;
                else lightness = value;
            }
        }

        //конструктор
        public HSL(double h, double s, double l)
        {
            Hue = h;
            Saturation = s;
            Lightness = l;
        }

        public HSL() : this(0, 0, 0)
        {
        }

        // перевод из HSL в RGB
        public (byte R, byte G, byte B) ToRGB()
        {
            double h = Hue / 360.0;
            double s = Saturation / 100.0;
            double l = Lightness / 100.0;

            double r, g, b;

            if (s == 0)
            {
                r = g = b = l;
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;

                r = Convert(p, q, h + 1.0 / 3.0);
                g = Convert(p, q, h);
                b = Convert(p, q, h - 1.0 / 3.0);
            }

            return (
                (byte)(r * 255),
                (byte)(g * 255),
                (byte)(b * 255)
            );
        }

        private double Convert(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;

            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 0.5) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;

            return p;
        }

        // перевод в HEX 
        public string ToHex()
        {
            var rgb = ToRGB();
            return "#" +
                   rgb.R.ToString("X2") +
                   rgb.G.ToString("X2") +
                   rgb.B.ToString("X2");
        }

        //вывод в строку
        public override string ToString()
        {
            return $"hsl({Hue},{Saturation}%,{Lightness}%)";
        }

        //сложение двух цветов
        public static HSL operator +(HSL a, HSL b)
        {
            return new HSL(a.Hue + b.Hue, a.Saturation + b.Saturation, a.Lightness + b.Lightness);
        }

        //вычитание двух цветов
        public static HSL operator -(HSL a, HSL b)
        {
            return new HSL(a.Hue - b.Hue, a.Saturation - b.Saturation, a.Lightness - b.Lightness);
        }

        //умножение на число
        public static HSL operator *(HSL a, double k)
        {
            return new HSL(a.Hue * k, a.Saturation * k, a.Lightness * k);
        }

        //деление на число
        public static HSL operator /(HSL a, double k)
        {
            if (k == 0) throw new Exception("Деление на ноль");
            return new HSL(a.Hue / k, a.Saturation / k, a.Lightness / k);
        }

        //проверка равенства цветов
        public static bool operator ==(HSL a, HSL b)
        {
            return a.Hue == b.Hue &&
                   a.Saturation == b.Saturation &&
                   a.Lightness == b.Lightness;
        }

        //проверка неравенства
        public static bool operator !=(HSL a, HSL b)
        {
            return !(a == b);
        }
    }
}
